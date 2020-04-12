using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    class PerfectReflectorFilter:Filter
    {
        float maxR=0, maxG=0, maxB=0;

        public override Bitmap processImg(Bitmap img, BackgroundWorker worker)
        {
            Bitmap res = new Bitmap(img.Width, img.Height);

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    if (img.GetPixel(i, j).R > maxR) maxR = img.GetPixel(i, j).R;
                    if (img.GetPixel(i, j).G > maxG) maxG = img.GetPixel(i, j).G;
                    if (img.GetPixel(i, j).B > maxB) maxB = img.GetPixel(i, j).B;
                }
            }

            for (int i = 0; i < img.Width; i++)
            {
                worker.ReportProgress((int)((float)i / res.Width * 100));
                if (worker.CancellationPending) return null;

                for (int j = 0; j < img.Height; j++)
                    res.SetPixel(i, j, calcPixelColor(img, i, j));
            }

            return res;
        }
        protected override Color calcPixelColor(Bitmap img, int x, int y)
        {
            Color sourceColor = img.GetPixel(x, y);
            Color res = Color.FromArgb(Clamp((int)(sourceColor.R*255/maxR), 0, 255), Clamp((int)(sourceColor.G * 255 / maxG), 0, 255), Clamp((int)(sourceColor.B * 255 / maxB), 0, 255));
            return res;
        }
    }
}
