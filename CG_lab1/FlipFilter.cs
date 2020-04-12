using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class FlipFilter:Filter
    {
        protected override Color calcPixelColor(Bitmap img, int x, int y)
        {
            int resX = (int)((x - img.Width / 2) * Math.Cos(-100) - (y - img.Height / 2) * Math.Sin(-100) + img.Width / 2);
            int resY = (int)((x - img.Width / 2) * Math.Sin(-100) + (y - img.Height / 2) * Math.Cos(-100) + img.Height / 2);
            Color resultColor;
            if (resX >= img.Width || resY >= img.Height || resY < 0)
                resultColor = Color.FromArgb(0, 0, 0);
            else 
                resultColor = img.GetPixel(Math.Abs(resX), Math.Abs(resY));
            return resultColor;
        }
    }
}
