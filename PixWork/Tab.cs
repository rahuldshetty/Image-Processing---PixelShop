using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PixWork
{
    class Tab
    {
        public PictureBox pictureBox;
        public string filepath;
        public string filename;
        public TabPage tab;
        public Bitmap bitmap;
        public int width, height,currentBrightness;

        private bool isChangesSaved, textAlreadyChanged;
        private bool isGray;

        public int currentContrast { get; private set; }
        System.Windows.Forms.DataVisualization.Charting.Chart chart1;

        Stack<Bitmap> stack=new Stack<Bitmap>();


        public Tab(System.Windows.Forms.DataVisualization.Charting.Chart  chart)
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
            currentBrightness = 0;
            currentContrast = 0;
            chart1 = chart;
        }

        public void loadImage(Bitmap image)
        {
            bitmap = image;

            pictureBox.Image = image;
            width = bitmap.Width;
            height = bitmap.Height;
            findHistoGraph(bitmap);
            stack.Push(bitmap);
        }

        public void preSave()
        {
            stack.Push(bitmap);
            bitmap = new Bitmap(pictureBox.Image);
        }

        public void saveImage(string path)
        {
            preSave();
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
            preSave();
            Bitmap temp = new Bitmap(width, height);
            Bitmap bmp = bitmap;
            unsafe
            {
                LockBitmap lockBitmap = new LockBitmap(bmp);
                lockBitmap.LockBits();

                LockBitmap lockBitmap2 = new LockBitmap(temp);
                lockBitmap2.LockBits();

                for (int y = 0; y < lockBitmap.Height; y++)
                {
                    for (int x = 0; x < lockBitmap.Width; x++)
                    {
              
                        Color pixel = lockBitmap.GetPixel(x, y);
                        int grayscale = (int)(pixel.R * 0.3) + (int)(pixel.G * 0.59) + (int)(pixel.B * 0.11);
                        lockBitmap2.SetPixel(x, y, Color.FromArgb((int)(grayscale), (int)(grayscale), (int)(grayscale)));

                    }
                }
                lockBitmap2.UnlockBits();
                lockBitmap.UnlockBits();
                pictureBox.Image = temp;
            }
            isGray = true;
            updateChange(temp);
        }

        public void flipHorizontal()
        {
            preSave();
            Bitmap temp = new Bitmap(width, height);
            Bitmap bmp = bitmap;
            unsafe
            {
                LockBitmap lockBitmap = new LockBitmap(bmp);
                lockBitmap.LockBits();

                LockBitmap lockBitmap2 = new LockBitmap(temp);
                lockBitmap2.LockBits();

                for (int y = 0; y < lockBitmap.Height; y++)
                {
                    for (int x = 0; x < lockBitmap.Width; x++)
                    {

                        Color pixel = lockBitmap.GetPixel( width - x -1, y);
                      
                        lockBitmap2.SetPixel(x, y, pixel);

                    }
                }
                lockBitmap2.UnlockBits();
                lockBitmap.UnlockBits();
                pictureBox.Image = temp;
            }
            updateChange(temp);


        }

        public void invert()
        {
            preSave();
            Bitmap temp = new Bitmap(width, height);
            Bitmap bmp = bitmap;
            unsafe
            {
                LockBitmap lockBitmap = new LockBitmap(bmp);
                lockBitmap.LockBits();

                LockBitmap lockBitmap2 = new LockBitmap(temp);
                lockBitmap2.LockBits();

                for (int y = 0; y < lockBitmap.Height; y++)
                {
                    for (int x = 0; x < lockBitmap.Width; x++)
                    {

                        Color pixel = lockBitmap.GetPixel(x , y);
                        Color newPixel = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                        lockBitmap2.SetPixel(x, y, newPixel);

                    }
                }
                lockBitmap2.UnlockBits();
                lockBitmap.UnlockBits();
                pictureBox.Image = temp;
            }
            updateChange(temp);
        }


        public void flipVertical()
        {
            preSave();
            Bitmap temp = new Bitmap(width, height);
            Bitmap bmp = bitmap;
            unsafe
            {
                LockBitmap lockBitmap = new LockBitmap(bmp);
                lockBitmap.LockBits();

                LockBitmap lockBitmap2 = new LockBitmap(temp);
                lockBitmap2.LockBits();

                for (int y = 0; y < lockBitmap.Height; y++)
                {
                    for (int x = 0; x < lockBitmap.Width; x++)
                    {

                        Color pixel = lockBitmap.GetPixel(x, height - y - 1);

                        lockBitmap2.SetPixel(x, y, pixel);

                    }
                }
                lockBitmap2.UnlockBits();
                lockBitmap.UnlockBits();
                pictureBox.Image = temp;
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
            findHistoGraph(bitmap);
        }

        internal void undo()
        {
            if (stack.Count != 0)
            {
                Bitmap top = stack.Pop();
                updateChange(top);
            }
        }

        public void rotateImage90CCW()
        {
            preSave();
            Bitmap temp = new Bitmap(height, width);
            Bitmap bmp = bitmap;
            unsafe
            {
                LockBitmap lockBitmap = new LockBitmap(bmp);
                lockBitmap.LockBits();

                LockBitmap lockBitmap2 = new LockBitmap(temp);
                lockBitmap2.LockBits();

                for (int y = 0; y < lockBitmap.Height; y++)
                {
                    for (int x = 0; x < lockBitmap.Width; x++)
                    {
                        Color pixel = lockBitmap.GetPixel(x, y);
                        lockBitmap2.SetPixel(y, x, pixel);
                    }
                }
                lockBitmap2.UnlockBits();
                lockBitmap.UnlockBits();
                pictureBox.Image = temp;
            }
            updateChange(temp);
            flipVertical();


        }

        internal void rotateImage90CW()
        {
            preSave();
            Bitmap temp = new Bitmap(height, width);
            Bitmap bmp = bitmap;
            unsafe
            {
                LockBitmap lockBitmap = new LockBitmap(bmp);
                lockBitmap.LockBits();

                LockBitmap lockBitmap2 = new LockBitmap(temp);
                lockBitmap2.LockBits();

                for (int y = 0; y < lockBitmap.Height; y++)
                {
                    for (int x = 0; x < lockBitmap.Width; x++)
                    {
                        Color pixel = lockBitmap.GetPixel(x, y);
                        lockBitmap2.SetPixel(y, x, pixel);
                    }
                }
                lockBitmap2.UnlockBits();
                lockBitmap.UnlockBits();
                pictureBox.Image = temp;
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

        public void performHisto()
        {
            preSave();
            Bitmap temp =  HistEq(bitmap);      

            updateChange(temp);

        }

        public Bitmap HistEq(Bitmap img)
        {

            int w = img.Width;
            int h = img.Height;
            BitmapData sd = img.LockBits(new Rectangle(0, 0, w, h),
            ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int bytes = sd.Stride * sd.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];
            Marshal.Copy(sd.Scan0, buffer, 0, bytes);
            img.UnlockBits(sd);
            int current = 0;
            double[] pn = new double[256];
            for (int p = 0; p < bytes; p += 4)
            {
                pn[buffer[p]]++;
            }
            for (int prob = 0; prob < pn.Length; prob++)
            {
                pn[prob] /= (w * h);
            }
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    current = y * sd.Stride + x * 4;
                    double sum = 0;
                    for (int i = 0; i < buffer[current]; i++)
                    {
                        sum += pn[i];
                    }
                    for (int c = 0; c < 3; c++)
                    {
                        result[current + c] = (byte)Math.Floor(255 * sum);
                    }
                    result[current + 3] = 255;
                }
            }
            Bitmap res = new Bitmap(w, h);
            BitmapData rd = res.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(result, 0, rd.Scan0, bytes);
            res.UnlockBits(rd);
            return res;
        }

        internal void findHistoGraph(Bitmap img)
        {
          
            chart1.Series["Series1"].Points.Clear();
            BitmapData sd = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),
            ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int bytes = sd.Stride * sd.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];
            Marshal.Copy(sd.Scan0, buffer, 0, bytes);
            img.UnlockBits(sd);

            int current = 0;
            double[] pn = new double[256];
            for (int p = 0; p < bytes; p += 4)
            {
                pn[buffer[p]]++;
            }

            for(int i=0;i<256;i++)
            {
                chart1.Series["Series1"].Points.AddXY(i, pn[i]);
            }
           
        }

        Bitmap applyKernal(int[,] kernel, float div)
        {
            preSave();
            Bitmap bmp = bitmap;
            unsafe
            {
                int kernelWidth = kernel.GetLength(0);
                int kernelHeight = kernel.Length / kernelWidth;
                LockBitmap lockBitmap = new LockBitmap(bmp);
                lockBitmap.LockBits();
                for (int y = 0; y < lockBitmap.Height; y++)
                {
                    for (int x = 0; x < lockBitmap.Width; x++)
                    {
                        int avgR = 0;
                        int avgB = 0;
                        int avgG = 0;

                        for (int i = -1; i < kernelWidth - 1; i++)
                            for (int j = -1; j < kernelHeight - 1; j++)
                            {
                                if (x + i >= 0 && x + i < width && y + j >= 0 && y + j < height)
                                {
                                    Color c = lockBitmap.GetPixel(x + i, y + j);
                                    avgR += kernel[i + 1, j + 1] * c.R;
                                    avgG += kernel[i + 1, j + 1] * c.G;
                                    avgB += kernel[i + 1, j + 1] * c.B;
                                }

                            }

                        if (avgB < 0) avgB = 0;
                        if (avgR < 0) avgR = 0;
                        if (avgG < 0) avgG = 0;
                        double R = (avgR * 1.0) / div;
                        double G = (avgG * 1.0) / div;
                        double B = (avgB * 1.0) / div;
                        if (R > 255) R = 255;
                        if (G > 255) G = 255;
                        if (B > 255) B = 255;
                        lockBitmap.SetPixel(x, y, Color.FromArgb((int)(R), (int)(G), (int)(B)));

                    }
                }
                lockBitmap.UnlockBits();
            }
                return bmp;
     
        }

        internal void prewittHorizontal()
        {
            Bitmap blur;

            int[,] kernal = new int[3, 3]
            {
                {1,0,-1},
                {1,0,-1},
                {1,0,-1}
            };

            blur = applyKernal(kernal, 1);
            updateChange(blur);
        }


        internal void prewittVertical()
        {
            Bitmap blur;

            int[,] kernal = new int[3, 3]
            {
                {1,1,1},
                {0,0,0},
                {-1,-1,-1}
            };

            blur = applyKernal(kernal, 1);
            updateChange(blur);
        }

        internal void updateBrightness(int value)
        {
            Bitmap backup = new Bitmap( width,height);
            Bitmap bmp = bitmap;
            currentBrightness = value;
            unsafe
            {
                LockBitmap lockBitmap = new LockBitmap(bmp);
                lockBitmap.LockBits();

                LockBitmap lockBitmap2 = new LockBitmap(backup);
                lockBitmap2.LockBits();

                for (int y = 0; y < lockBitmap.Height; y++)
                {
                    for (int x = 0; x < lockBitmap.Width; x++)
                    {
                        Color c = lockBitmap.GetPixel(x , y );
                        int avgR = c.R + value;
                        int avgB = c.B + value;
                        int avgG = c.G + value;

                    

                        if (avgB < 0) avgB = 1;
                        if (avgR < 0) avgR = 1;
                        if (avgG < 0) avgG = 1;
                        if (avgB > 255) avgB = 255;
                        if (avgR > 255) avgR = 255;
                        if (avgG > 255) avgG = 255;

                        lockBitmap2.SetPixel(x, y, Color.FromArgb((int)(avgR), (int)(avgG), (int)(avgB)));

                    }
                }
                lockBitmap2.UnlockBits();
                lockBitmap.UnlockBits();
                pictureBox.Image = backup;
                findHistoGraph(backup);
            }
           

        }

        internal void updateContrast(int value)
        {
            Bitmap backup = new Bitmap(width, height);
            Bitmap bmp = bitmap;
            currentContrast = value;
            double contrast = (100.0 + value) / value;
            unsafe
            {
                LockBitmap lockBitmap = new LockBitmap(bmp);
                lockBitmap.LockBits();

                LockBitmap lockBitmap2 = new LockBitmap(backup);
                lockBitmap2.LockBits();

                for (int y = 0; y < lockBitmap.Height; y++)
                {
                    for (int x = 0; x < lockBitmap.Width; x++)
                    {
                        Color c = lockBitmap.GetPixel(x, y);

                        double R = c.R / 255.0;
                        R -= 0.5;
                        R *= contrast;
                        R += 0.5;
                        R *= 255.0;
                        if (R < 0) R = 0;
                        if (R > 255) R = 255;


                        double G = c.G / 255.0;
                        G -= 0.5;
                        G *= contrast;
                        G += 0.5;
                        G *= 255.0;
                        if (G < 0) G = 0;
                        if (G > 255) G = 255;


                        double B = c.B / 255.0;
                        B -= 0.5;
                        B *= contrast;
                        B += 0.5;
                        B *= 255.0;
                        if (B < 0) B = 0;
                        if (B > 255) B = 255;

                        lockBitmap2.SetPixel(x, y, Color.FromArgb((int)(R), (int)(G), (int)(B)));

                    }
                }
                lockBitmap2.UnlockBits();
                lockBitmap.UnlockBits();
                pictureBox.Image = backup;
            }
            findHistoGraph(new Bitmap(pictureBox.Image));
        }

        internal void dilation(int kernelWidth, int kernelHeight )
        {
            preSave();
            Bitmap backup = new Bitmap(width, height);
            Bitmap bmp = bitmap;
            unsafe
            {         
                LockBitmap lockBitmap = new LockBitmap(bmp);
                lockBitmap.LockBits();

                LockBitmap lockBitmap2 = new LockBitmap(backup);
                lockBitmap2.LockBits();

                for (int y = 0; y < lockBitmap.Height; y++)
                {
                    for (int x = 0; x < lockBitmap.Width; x++)
                    {
                        Color c = lockBitmap.GetPixel(x, y);

                        int maxR = -1;
                        int maxG = -1;
                        int maxB = -1;

                        for (int i = -1; i < kernelWidth - 1; i++)
                            for (int j = -1; j < kernelHeight - 1; j++)
                            {
                                if (x + i >= 0 && x + i < width && y + j >= 0 && y + j < height)
                                {
                                    Color c1 = lockBitmap.GetPixel(x + i, y + j);

                                    if (c1.R > maxR) maxR = c1.R;
                                    if (c1.G > maxG) maxG = c1.G;
                                    if (c1.B > maxB) maxB = c1.B;

                                }

                            }


                        lockBitmap2.SetPixel(x, y, Color.FromArgb((int)(maxR), (int)(maxG), (int)(maxB)));

                    }
                }
                lockBitmap2.UnlockBits();
                lockBitmap.UnlockBits();
                pictureBox.Image = backup;
            }

        }

        internal void erosion(int kernelWidth, int kernelHeight)
        {
            preSave();
            Bitmap backup = new Bitmap(width, height);
            Bitmap bmp = bitmap;
            unsafe
            {
                LockBitmap lockBitmap = new LockBitmap(bmp);
                lockBitmap.LockBits();

                LockBitmap lockBitmap2 = new LockBitmap(backup);
                lockBitmap2.LockBits();

                for (int y = 0; y < lockBitmap.Height; y++)
                {
                    for (int x = 0; x < lockBitmap.Width; x++)
                    {
                        Color c = lockBitmap.GetPixel(x, y);

                        int maxR = 257;
                        int maxG = 257;
                        int maxB = 257;

                        for (int i = -1; i < kernelWidth - 1; i++)
                            for (int j = -1; j < kernelHeight - 1; j++)
                            {
                                if (x + i >= 0 && x + i < width && y + j >= 0 && y + j < height)
                                {
                                    Color c1 = lockBitmap.GetPixel(x + i, y + j);

                                    if (c1.R < maxR) maxR = c1.R;
                                    if (c1.G < maxG) maxG = c1.G;
                                    if (c1.B < maxB) maxB = c1.B;

                                }

                            }


                        lockBitmap2.SetPixel(x, y, Color.FromArgb((int)(maxR), (int)(maxG), (int)(maxB)));

                    }
                }
                lockBitmap2.UnlockBits();
                lockBitmap.UnlockBits();
                pictureBox.Image = backup;
            }

        }



        internal void LGauss()
        {
            Bitmap blur;

            int[,] kernal = new int[5, 5]
            {
                {0,0,-1,0,0},
                {0,-1,-2,-1,0},
                {-1,-2,16,-2,-1},
                {0,-1,-2,-1,0},
                {0,0,-1,0,0 }
            };


            blur = applyKernal(kernal, 1);
            updateChange(blur);
        }

        internal void laplacian()
        {
            Bitmap blur;

            int[,] kernal = new int[3, 3]
            {
                {0,-1,0},
                {-1,4,-1},
                {0,-1,0}
            };


            blur = applyKernal(kernal, 1);
            updateChange(blur);
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
