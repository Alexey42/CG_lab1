using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    class Dilatation:Filter
    {
        int[,] kernel;

        public Dilatation(int[,] _kernel)
        {
            kernel = _kernel;
        }

        protected override Color calcPixelColor(Bitmap sourceImage, int x, int y)
        {
            float resR = 0; float resG = 0; float resB = 0;

            for (int j = -1; j <= 1; j++)
                for (int i = -1; i <= 1; i++)
                {
                    int idX = Clamp(x + i, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                    if (kernel[i + 1, j + 1] == 1)
                    {
                        resR = Math.Max(sourceImage.GetPixel(idX, idY).R, resR);
                        resG = Math.Max(sourceImage.GetPixel(idX, idY).G, resG);
                        resB = Math.Max(sourceImage.GetPixel(idX, idY).B, resB);
                    }
                }

            return Color.FromArgb(Clamp((int)resR, 0, 255), Clamp((int)resG, 0, 255), Clamp((int)resB, 0, 255));
        }
    }
}
