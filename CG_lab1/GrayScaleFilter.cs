using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class GrayScaleFilter:Filter
    {
        protected override Color calcPixelColor(Bitmap img, int x, int y)
        {
            Color sourceColor = img.GetPixel(x, y);
            var i = (int)(0.299 * sourceColor.R) + (int)(0.587 * sourceColor.R) + (int)(0.114 * sourceColor.R);
            Color res = Color.FromArgb(i, i, i);
            return res;
        }
    }
}
