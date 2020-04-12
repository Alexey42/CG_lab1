using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class InvertFilter:Filter
    {
        protected override Color calcPixelColor(Bitmap img, int x, int y)
        {
            Color sourceColor = img.GetPixel(x, y);
            Color res = Color.FromArgb(255-sourceColor.R, 255-sourceColor.G, 255-sourceColor.B);
            return res;
        }
    }
}
