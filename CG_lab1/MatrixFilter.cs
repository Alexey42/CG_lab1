﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    class MatrixFilter:Filter
    {
        protected float[,] kernel = null;
        protected MatrixFilter() { }
        public MatrixFilter(float[,] k)
        {
            this.kernel = k;
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
            return Color.FromArgb(Clamp((int)resR, 0, 255), Clamp((int)resG, 0, 255), Clamp((int)resB, 0, 255));
        }
    }
}
