using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class SepiaFilter : Filter
    {
        protected override Color calcPixelColor(Bitmap img, int x, int y)
        {
            Color sourceColor = img.GetPixel(x, y);
            var i = (int)(0.299 * sourceColor.R) + (int)(0.587 * sourceColor.R) + (int)(0.114 * sourceColor.R);
            var k = 50;
            Color res = Color.FromArgb(Clamp(i+2*k, 0 , 255), Clamp((int)(i+0.5*k), 0, 255), Clamp(i-k, 0, 255));
            return res;
        }
    }
}
