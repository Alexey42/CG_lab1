using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    class WaveFilter:Filter
    {
        protected override Color calcPixelColor(Bitmap img, int x, int y)
        {
            int resX = (int)(x + 20*Math.Sin(2*Math.PI*y/60));
            Color resultColor = img.GetPixel(Clamp(resX, 0, img.Width-1), Clamp(y, 0, img.Height-1));
            return resultColor;
        }
    }
}
