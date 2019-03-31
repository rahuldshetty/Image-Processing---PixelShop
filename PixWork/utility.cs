using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixWork
{
    class utility
    {

        public static Bitmap getRComponent(Bitmap img)
        {
            Bitmap temp = new Bitmap(img.Width, img.Height);
            LockBitmap input = new LockBitmap(img);
            LockBitmap output = new LockBitmap(temp);

            input.LockBits();
            output.LockBits();
            for (int y = 0; y < input.Height; y++)
            {
                for (int x = 0; x < input.Width; x++)
                {
                    Color c = input.GetPixel(x, y);
                    Color newpix = Color.FromArgb(0, 0, c.R);
                    output.SetPixel(x, y, newpix);
                }
            }
            input.UnlockBits();
            output.UnlockBits();
            return temp;
        }

        public static Bitmap getGComponent(Bitmap img)
        {
            Bitmap temp = new Bitmap(img.Width, img.Height);
            LockBitmap input = new LockBitmap(img);
            LockBitmap output = new LockBitmap(temp);

            input.LockBits();
            output.LockBits();
            for (int y = 0; y < input.Height; y++)
            {
                for (int x = 0; x < input.Width; x++)
                {
                    Color c = input.GetPixel(x, y);
                    Color newpix = Color.FromArgb(0, 0, c.G);
                    output.SetPixel(x, y, newpix);
                }
            }
            input.UnlockBits();
            output.UnlockBits();
            return temp;
        }

        public static Bitmap getBComponent(Bitmap img)
        {
            Bitmap temp = new Bitmap(img.Width, img.Height);
            LockBitmap input = new LockBitmap(img);
            LockBitmap output = new LockBitmap(temp);

            input.LockBits();
            output.LockBits();
            for (int y = 0; y < input.Height; y++)
            {
                for (int x = 0; x < input.Width; x++)
                {
                    Color c = input.GetPixel(x, y);
                    Color newpix = Color.FromArgb(0, 0, c.B);
                    output.SetPixel(x, y, newpix);
                }
            }
            input.UnlockBits();
            output.UnlockBits();
            return temp;
        }


    }

}
