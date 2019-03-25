using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PixWork
{
    class Tab
    {
        public PictureBox pictureBox;
        public string filepath;
        public TabPage tab;
        public Bitmap bitmap;
        public int width, height;

        private bool isChangesSaved, textAlreadyChanged;
        private bool isGray;

        public Tab()
        {
            tab = new TabPage();
            pictureBox = new PictureBox();
            pictureBox.Parent = tab;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.BringToFront();
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            tab.AutoScroll = true;
            isChangesSaved = true;
            textAlreadyChanged = false;
            isGray = false;


        }

        public void loadImage(Bitmap image)
        {
            bitmap = image;

            pictureBox.Image = image;
            width = bitmap.Width;
            height = bitmap.Height;
        }


        public void saveImage(string path)
        {
            filepath = path;
            tab.Text = path;
            bitmap.Save(path);
            isChangesSaved = true;
            tab.Text = filepath;
        }

        public bool getChangeState()
        {
            return isChangesSaved;
        }

        public void convertToGray()
        {

            Bitmap temp = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    Color pixel = bitmap.GetPixel(i, j);
                    int grayscale = (int)(pixel.R * 0.3) + (int)(pixel.G * 0.59) + (int)(pixel.B * 0.11);
                    Color newpixel = Color.FromArgb(grayscale, grayscale, grayscale);
                    temp.SetPixel(i, j, newpixel);

                }
            isGray = true;


            updateChange(temp);




        }

        public void flipHorizontal()
        {
            Bitmap temp = new Bitmap(width, height);

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    temp.SetPixel(i, j, bitmap.GetPixel(width - i - 1, j));
                }

            updateChange(temp);
        }

        public void invert()
        {
            Bitmap temp = new Bitmap(width, height);

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    Color pixel = bitmap.GetPixel(i, j);
                    Color newPixel = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                    temp.SetPixel(i, j, newPixel);
                }

            updateChange(temp);
        }


        public void flipVertical()
        {
            Bitmap temp = new Bitmap(width, height);

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    temp.SetPixel(i, j, bitmap.GetPixel(i, height - j - 1));
                }

            updateChange(temp);
        }


        public void updateChange(Bitmap temp)
        {
            isChangesSaved = false;
            if (textAlreadyChanged == false)
            {
                textAlreadyChanged = true;
                tab.Text += "*";
            }

            bitmap = temp;
            pictureBox.Image = bitmap;
            width = bitmap.Width;
            height = bitmap.Height;
        }

        public void rotateImage90CCW()
        {
            Bitmap temp = new Bitmap(height, width);
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    temp.SetPixel(i, j, bitmap.GetPixel(j, i));

                }
            updateChange(temp);
            flipVertical();


        }

        internal void rotateImage90CW()
        {
            Bitmap temp = new Bitmap(height, width);
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    temp.SetPixel(i, j, bitmap.GetPixel(j, i));

                }
            updateChange(temp);
            flipHorizontal();
        }

        internal void meanBlur()
        {
            Bitmap blur;

            int[,] kernal = new int[3, 3]
            {
                {1,1,1},
                {1,1,1},
                {1,1,1}
            };



            blur = applyKernal(kernal, 9);
            updateChange(blur);
        }



        Bitmap applyKernal(int[,] kernel, float div)
        {
            Bitmap res = new Bitmap(width, height);

            int kernelWidth = kernel.GetLength(0);
            int kernelHeight = kernel.Length / kernelWidth;


            System.Console.WriteLine(kernelHeight + "sas");
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int avgR = 0, avgG = 0, avgB = 0;

                    for (int x = -1; x < kernelWidth - 1; x++)
                        for (int y = -1; y < kernelHeight - 1; y++)
                        {
                            if (x + i >= 0 && x + i < width && y + j >= 0 && y + j < height)
                            {


                                avgR += kernel[x + 1, y + 1] * bitmap.GetPixel(x + i, y + j).R;
                                avgG += kernel[x + 1, y + 1] * bitmap.GetPixel(x + i, y + j).G;
                                avgB += kernel[x + 1, y + 1] * bitmap.GetPixel(x + i, y + j).B;
                            }

                        }
                    if (avgB < 0) avgB = 0;
                    if (avgR < 0) avgR = 0;
                    if (avgG < 0) avgG = 0;

                    double R = (avgR*1.0)/ div;
                    double G = (avgG * 1.0) / div;
                    double B = (avgB * 1.0) / div;

                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;

                   ;

                  
                    res.SetPixel(i, j, Color.FromArgb((int)(R), (int)(G), (int)(B)));

                }

            }

            return res;
        }

        internal void emobss()
        {
            Bitmap blur;

            int[,] kernal = new int[3, 3]
            {
                {-2,-1,0},
                {-1,1,1},
                {0,1,2}
            };


            blur = applyKernal(kernal, 1);
            updateChange(blur);
        }

        internal void sharpenHigh()
        {
            Bitmap blur;

            int[,] kernal = new int[3, 3]
            {
                {1,1,1},
                {1,-7,1},
                {1,1,1}
            };


            blur = applyKernal(kernal, 1);
            updateChange(blur);
        }

        internal void sharpenMed()
        {
            Bitmap blur;

            int[,] kernal = new int[3, 3]
            {
                {-1,-1,-1},
                {-1,9,-1},
                {-1,-1,-1}
            };


            blur = applyKernal(kernal, 1);
            updateChange(blur);
        }

        internal void sobelVertical()
        {
            Bitmap blur;

            int[,] kernal = new int[3, 3]
            {
                {-1,0,1},
                {-2,0,2},
                {-1,0,1}
            };


            blur = applyKernal(kernal, 1);
            updateChange(blur);
        }

        internal void sobelHorizontal()
        {
            Bitmap blur;

            int[,] kernal = new int[3, 3]
            {
                {-1,-2,-1},
                {0,0,0},
                {1,2,1}
            };


            blur = applyKernal(kernal, 1);
            updateChange(blur);
        }

        internal void findEdgeLow()
        {
            Bitmap blur;

            int[,] kernal = new int[3, 3]
            {
                {1,0,-1},
                {0,0,0},
                {-1,0,1}
            };


            blur = applyKernal(kernal, 1);
            updateChange(blur);
        }

        internal void findEdgeMedium()
        {
            Bitmap blur;

            int[,] kernal = new int[3, 3]
            {
                {0,1,0},
                {1,-4,1},
                {0,1,0}
            };


            blur = applyKernal(kernal, 1);
            updateChange(blur);
        }

        internal void findEdgeHigh()
        {
            Bitmap blur;

            int[,] kernal = new int[3, 3]
            {
                {-1,-1,-1},
                {-1,8,-1},
                {-1,-1,-1}
            };


            blur = applyKernal(kernal, 1);
            updateChange(blur);
        }

        internal void gaussBlur()
        {
            Bitmap blur;

            int[,] kernal = new int[3, 3]
            {
                {1,2,1},
                {2,4,2},
                {1,2,1}
            };


            blur = applyKernal(kernal, 16);
            updateChange(blur);
        }

        internal void gaussBlurHigh()
        {
            Bitmap blur;

            int[,] kernal = new int[5, 5]
            {
                {1,4,6,4,1},
                {4,16,24,16,4},
                { 6,24,36,24,6},
               {4,16,24,16,4},
               {1,4,6,4,1}
            };


            blur = applyKernal(kernal, 256);
            updateChange(blur);
        }

        internal void sharpen()
        {

            Bitmap blur;

            int[,] kernal = new int[3, 3]
            {
                {0,-1,0},
                {-1,5,-1},
                {0,-1,0}
            };


            blur = applyKernal(kernal, 1);
            updateChange(blur);
        }


    }
}
