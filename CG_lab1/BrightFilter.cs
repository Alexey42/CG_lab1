using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class BrightFilter:Filter
    {
        protected override Color calcPixelColor(Bitmap img, int x, int y)
        {
            Color sourceColor = img.GetPixel(x, y);
            var c = 30;
            Color res = Color.FromArgb(Clamp(sourceColor.R+c, 0, 255), Clamp(sourceColor.G + c, 0, 255), Clamp(sourceColor.B + c, 0, 255));
            return res;
        }
    }
}
