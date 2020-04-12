using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    class GlassFilter:Filter
    {
        Random rand;
        public GlassFilter()
        {
            rand = new Random();
        }
        protected override Color calcPixelColor(Bitmap img, int x, int y)
        {
            int resX = (int)(x + (rand.NextDouble() - 0.5) * 10);
            int resY = (int)(y + (rand.NextDouble() - 0.5) * 10);
            Color resultColor = img.GetPixel(Clamp(resX, 0, img.Width - 1), Clamp(resY, 0, img.Height - 1));
            return resultColor;
        }
    }
}
