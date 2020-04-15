using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    class TopHat:Filter
    {
        int[,] kernel;

        public TopHat(int[,] _kernel)
        {
            kernel = _kernel;
        }
        protected override Color calcPixelColor(Bitmap sourceImage, int x, int y)
        {
            return sourceImage.GetPixel(x, y);
        }

        public override Bitmap processImg(Bitmap img, BackgroundWorker worker)
        {
            float resR; float resG; float resB;
            Filter filter = new Erosion(kernel);
            Bitmap res = filter.processImg(img, worker);

            for (int i = 0; i < img.Width; i++)
                for (int j = 0; j < img.Height; j++)
                {
                    resR = img.GetPixel(i, j).R - res.GetPixel(i, j).R;
                    resG = img.GetPixel(i, j).G - res.GetPixel(i, j).G;
                    resB = img.GetPixel(i, j).B - res.GetPixel(i, j).B;
                    res.SetPixel(i, j, Color.FromArgb(Clamp((int)resR, 0, 255), Clamp((int)resG, 0, 255), Clamp((int)resB, 0, 255)));
                }

            return res;
        }
    }
}
