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
        public int width, height, currentBrightness;

        Boolean alreadyComputed = false;

        double[] histoR = new double[256];
        double[] histoG = new double[256];
        double[] histoB = new double[256];

        Bitmap balancedR, balancedG, balancedB;

        private bool isChangesSaved, textAlreadyChanged;


        public int currentContrast { get; private set; }
        System.Windows.Forms.DataVisualization.Charting.Chart chartr=null,chartg=null,chartb=null;

        Stack<Bitmap> stack = new Stack<Bitmap>();
        Stack<Boolean> grayscaleList = new Stack<Boolean>();

        public bool redOn, blueOn, greenOn;


        public Tab(System.Windows.Forms.DataVisualization.Charting.Chart chart1, System.Windows.Forms.DataVisualization.Charting.Chart chart2, System.Windows.Forms.DataVisualization.Charting.Chart chart3)
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

            currentBrightness = 0;
            currentContrast = 0;
            chartr = chart1;
            chartg = chart2;
            chartb = chart3;



            redOn = false;
            blueOn = false;
            greenOn = false;
        }

        public Boolean IsGray()
        {
            if(grayscaleList.Count!=0)
            {
                return grayscaleList.Peek();
            }
            return false;
        }

        public void loadImage(Bitmap image)
        {
            bitmap = image;

            pictureBox.Image = image;
            width = bitmap.Width;
            height = bitmap.Height;
            updateHistographh();
            stack.Push(bitmap);
            grayscaleList.Push(false);
        }

        public void preSave()
        {
            stack.Push(bitmap);
            grayscaleList.Push(grayscaleList.Peek());
            bitmap = new Bitmap(pictureBox.Image);
        }

        public void saveImage(string path)
        {
            preSave();
            filepath = path;
            tab.Text = path;
            bitmap.Save(path);
            isChangesSaved = true;
            filename = System.IO.Path.GetFileName(filepath);
            tab.Text = filename;
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
            grayscaleList.Push(true);
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

                        Color pixel = lockBitmap.GetPixel(width - x - 1, y);

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

                        Color pixel = lockBitmap.GetPixel(x, y);
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
            alreadyComputed = false;
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
            updateHistographh();
        }

        internal void undo()
        {
            if (stack.Count != 0)
            {
                Bitmap top = stack.Pop();
                updateChange(top);

                if (grayscaleList.Count != 1)
                    grayscaleList.Pop();

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

        public void performHisto(Boolean status)
        {
            preSave();
            Bitmap temp;
            if (status)
                temp = colorHisto(bitmap);
            else
                temp = HistEq(bitmap);
            updateChange(temp);
            updateHistographh();
        }

        
        
        public Bitmap colorHisto(Bitmap bitmap)
        {
            Bitmap rImage = utility.getRComponent(bitmap);
            Bitmap gImage = utility.getGComponent(bitmap);
            Bitmap bImage = utility.getBComponent(bitmap);

            Bitmap balancedR = HistEq(rImage);
            Bitmap balancedG = HistEq(gImage);
            Bitmap balancedB = HistEq(bImage);

            Bitmap res1 = new Bitmap(width, height);

            LockBitmap result = new LockBitmap(res1);
            LockBitmap resultR = new LockBitmap(balancedR);
            LockBitmap resultG = new LockBitmap(balancedG);
            LockBitmap resultB = new LockBitmap(balancedB);
            result.LockBits();
            resultR.LockBits();
            resultG.LockBits();
            resultB.LockBits();
            for (int y=0;y<result.Height;y++)
                for(int x=0;x<result.Width;x++)
                {
                    Color c = Color.FromArgb( resultR.GetPixel(x,y).B , resultG.GetPixel(x,y).B , resultB.GetPixel(x,y).B);
                    result.SetPixel(x, y, c);

                }
            result.UnlockBits();
            resultR.UnlockBits();
            resultG.UnlockBits();
            resultB.UnlockBits();


            return res1;
        }



        public Bitmap HistEq(Bitmap img)
        {

            Bitmap temp =(Bitmap)img.Clone();

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

        internal void findHistoGraph(Bitmap imgr,Bitmap imgg,Bitmap imgb)
        {
            unsafe
            {
                chartr.Series["Series1"].Points.Clear();
                chartg.Series["Series1"].Points.Clear();
                chartb.Series["Series1"].Points.Clear();
                if (!alreadyComputed)
                {
                   
                    histoR = new double[256];
                    histoG = new double[256];
                    histoB = new double[256];
                   
                    BitmapData sd = imgr.LockBits(new Rectangle(0, 0, imgr.Width, imgr.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                    int bytes = sd.Stride * sd.Height;
                    byte[] buffer = new byte[bytes];
                    byte[] result = new byte[bytes];
                    Marshal.Copy(sd.Scan0, buffer, 0, bytes);
                    imgr.UnlockBits(sd);
                    int current = 0;

                    for (int p = 0; p < bytes; p += 4)
                    {
                        histoR[buffer[p]]++;
                    }

                    sd = imgg.LockBits(new Rectangle(0, 0, imgg.Width, imgg.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                    bytes = sd.Stride * sd.Height;
                    buffer = new byte[bytes];
                    result = new byte[bytes];
                    Marshal.Copy(sd.Scan0, buffer, 0, bytes);
                    imgg.UnlockBits(sd);
                    current = 0;
                 
                    for (int p = 0; p < bytes; p += 4)
                    {
                        histoG[buffer[p]]++;
                    }
                    sd = imgb.LockBits(new Rectangle(0, 0, imgb.Width, imgb.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                    bytes = sd.Stride * sd.Height;
                    buffer = new byte[bytes];
                    result = new byte[bytes];
                    Marshal.Copy(sd.Scan0, buffer, 0, bytes);
                    imgb.UnlockBits(sd);

                    current = 0;
                    
                    for (int p = 0; p < bytes; p += 4)
                    {
                        histoB[buffer[p]]++;
                    }


                }

                for (int i = 0; i < 256; i++)
                {
                    chartr.Series["Series1"].Points.AddXY(i, histoR[i]);
                }

                for (int i = 0; i < 256; i++)
                {
                    chartg.Series["Series1"].Points.AddXY(i, histoG[i]);
                }

                for (int i = 0; i < 256; i++)
                {
                    chartb.Series["Series1"].Points.AddXY(i, histoB[i]);
                }
                alreadyComputed = true;
            }

        }


        internal void updateHistographh()
        {
            Bitmap temp = new Bitmap( pictureBox.Image );
            if (!alreadyComputed)
            {
                Bitmap rImage = utility.getRComponent(temp);
                Bitmap gImage = utility.getGComponent(temp);
                Bitmap bImage = utility.getBComponent(temp);

            
                balancedR = HistEq(rImage);
                balancedG = HistEq(gImage);
                balancedB = HistEq(bImage);
            }

            findHistoGraph(balancedR, balancedG, balancedB);

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

            Bitmap backup = new Bitmap(width, height);
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
                        Color c = lockBitmap.GetPixel(x, y);
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
                updateHistographh();
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
            updateHistographh();
        }

        internal void dilation(int kernelWidth, int kernelHeight)
        {
            preSave();
            bitmap = Dilation(bitmap, kernelWidth, kernelHeight);
            pictureBox.Image = bitmap;
            updateChange(bitmap);
        }

        internal Bitmap Dilation(Bitmap bitmap, int kernelWidth, int kernelHeight)
        {
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
            }
            return backup;
        }

        internal Bitmap Erosion(Bitmap bitmap, int kernelWidth, int kernelHeight)
        {

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

            }
            return backup;
        }


        internal void erosion(int kernelWidth, int kernelHeight)
        {
            preSave();
            bitmap = Erosion(bitmap, kernelWidth, kernelHeight);
            pictureBox.Image = bitmap;
            updateChange(bitmap);
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

            int[,] kernal = new int[5, 5]
            {
                {0,-1,1,-1,0},
                 {-1,2,-4,2,-1},
                 {-1,-4,13,-4,-1},
                 {-1,-2,4,-2,-1},
                 {0,-1,1,-1,0}

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



        internal void findEdgeMedium()
        {
            Bitmap blur;

            int[,] kernal = new int[3, 3]
            {
                {-1,-2,-1},
                {-2,13,-2},
                {-1,-2,-1}
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

        internal Bitmap operation(Bitmap a,Bitmap b,int operation)
        {
            Bitmap backup = new Bitmap(width, height);
            Bitmap bmp = a;
            Bitmap bmp2 = b;
            unsafe
            {
                LockBitmap lockBitmap = new LockBitmap(bmp);
                lockBitmap.LockBits();

                LockBitmap lockBitmap2 = new LockBitmap(backup);
                lockBitmap2.LockBits();

                LockBitmap lockBitmap3 = new LockBitmap(bmp2);
                lockBitmap3.LockBits();


                for (int y = 0; y < lockBitmap.Height; y++)
                {
                    for (int x = 0; x < lockBitmap.Width; x++)
                    {
                        Color c1 = lockBitmap.GetPixel(x, y);
                        Color c2 = lockBitmap3.GetPixel(x, y);

                        int R=0, G=0, B=0;

                        switch(operation)
                        {
                            case '+':
                                R = c1.R + c2.R;
                                G = c1.G + c2.G;
                                B = c1.B + c2.B;
                                break;

                            case '-':
                                R = c1.R - c2.R;
                                G = c1.G - c2.G;
                                B = c1.B - c2.B;
                                break;

                            case '^':
                                R = c1.R ^ c2.R;
                                G = c1.G ^ c2.G;
                                B = c1.B ^ c2.B;
                                break;

                            case '&':
                                R = c1.R & c2.R;
                                G = c1.G & c2.G;
                                B = c1.B & c2.B;
                                break;

                            case '|':
                                R = c1.R | c2.R;
                                G = c1.G | c2.G;
                                B = c1.B | c2.B;
                                break;
                        }

                        if (R < 0) R = 0;
                        if (G < 0) G = 0;
                        if (B < 0) B = 0;
                        if (R > 255) R = 255;
                        if (G > 255) G = 255;
                        if (B > 255) B = 255;

                        lockBitmap2.SetPixel(x, y, Color.FromArgb(R, G, B) );

                    }
                }
                lockBitmap2.UnlockBits();
                lockBitmap.UnlockBits();
                lockBitmap3.UnlockBits();
            }
            return backup;

        }

        internal void perimeter()
        {
             Bitmap temp = Dilation(bitmap, 3, 3);
            temp = operation(bitmap, temp, '^');
            updateChange(temp);

        }

        internal void updateComponent(Boolean status,Boolean status2,Boolean status3)
        {

            redOn = status;
            greenOn = status2;
            blueOn = status3;

            Bitmap temp = new Bitmap(width, height);
            LockBitmap output = new LockBitmap(temp);
            LockBitmap input = new LockBitmap(bitmap);
            unsafe
            {
                output.LockBits();
                input.LockBits();
                for (int y = 0; y < output.Height; y++)
                {
                    for (int x = 0; x < output.Width; x++)
                    {
                        Color c = input.GetPixel(x,y);
                        int r=0, g=0, b=0;
                        if (status == true)
                        {
                            r = c.R;
                        }
                        if(status2==true)
                        {
                            g = c.G;
                        }
                        if(status3==true)
                        {
                            b = c.B;
                        }
                        Color newpix = Color.FromArgb(r, g, b);
                        output.SetPixel(x, y, newpix);
                    }
                }
                input.UnlockBits();
                output.UnlockBits();
            }
            
            pictureBox.Image = temp;
            updateHistographh();
        }

    }
}
