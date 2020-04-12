using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class EmbossingFilter : MatrixFilter
    {
        public EmbossingFilter()
        {
            kernel = new float[3, 3] { { 0, 1, 0 }, { 1, 0, -1 }, { 0, -1, 0 } };           
        }

        protected override Color calcPixelColor(Bitmap img, int x, int y)
        {
            int radX = kernel.GetLength(0) / 2;
            int radY = kernel.GetLength(1) / 2;
            float resR = 0;
            float resG = 0;
            float resB = 0;
            for (int l = -radY; l <= radY; l++)
                for (int k = -radX; k <= radX; k++)
                {
                    int idX = Clamp(x + k, 0, img.Width - 1);
                    int idY = Clamp(y + l, 0, img.Height - 1);
                    Color neighborColor = img.GetPixel(idX, idY);
                    resR += neighborColor.R * kernel[k + radX, l + radY];
                    resG += neighborColor.G * kernel[k + radX, l + radY];
                    resB += neighborColor.B * kernel[k + radX, l + radY];
                }

            return Color.FromArgb(Clamp((int)((resR+255)/2), 0, 255), Clamp((int)((resG + 255) / 2), 0, 255), Clamp((int)((resB + 255) / 2), 0, 255));
        }
    }
}
