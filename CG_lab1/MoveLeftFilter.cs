using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class MoveLeftFilter:Filter
    {
         protected override Color calcPixelColor(Bitmap img, int x, int y)
        {
            Color resultColor;
            if (x > img.Width - 50)
                resultColor = Color.FromArgb(0, 0, 0);
            else
                resultColor = img.GetPixel(Clamp(x + 50, 0, img.Width - 1), y);
            return resultColor;
        }
    }
}
