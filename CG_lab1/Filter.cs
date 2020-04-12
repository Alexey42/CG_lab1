using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace CG_lab1
{
    abstract class Filter
    {
        public virtual Bitmap processImg(Bitmap img, BackgroundWorker worker)
        {
            Bitmap res = new Bitmap(img.Width, img.Height);

            for (int i = 0; i < img.Width; i++)
            {
                worker.ReportProgress((int)((float)i / res.Width * 100));
                if (worker.CancellationPending) return null;

                for (int j = 0; j < img.Height; j++)
                    res.SetPixel(i, j, calcPixelColor(img, i, j));
            }

            return res; 
        }

        public int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        protected abstract Color calcPixelColor(Bitmap img, int x, int y);
    }
}
