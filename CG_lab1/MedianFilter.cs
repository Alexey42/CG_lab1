using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class MedianFilter:MatrixFilter
    {
        const int size = 3;
        protected override Color calcPixelColor(Bitmap sourceImage, int x, int y)
        {
            int[] medR = new int[size * size];
            int[] medG = new int[size * size];
            int[] medB = new int[size * size];

            int radius = size / 2;
            int i = 0;
            for (int l = -radius; l <= radius; l++)
                for (int k = -radius; k <= radius; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);

                    medR[i] = sourceImage.GetPixel(idX, idY).R;
                    medG[i] = sourceImage.GetPixel(idX, idY).G;
                    medB[i] = sourceImage.GetPixel(idX, idY).B;
                    i++;
                }
            Array.Sort(medR); Array.Sort(medG); Array.Sort(medB);

            return Color.FromArgb(
                Clamp(medR[size * size / 2], 0, 255),
                Clamp(medG[size * size / 2], 0, 255),
                Clamp(medB[size * size / 2], 0, 255));
        }

    }
}
