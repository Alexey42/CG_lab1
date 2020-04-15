using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    class GistogramFilter : Filter
    {
        Tuple<float, float> tmp = null;

        protected override Color calcPixelColor(Bitmap img, int x, int y)
        {
            if (tmp == null) tmp = calcMaxMinBrightness(img);  

            float maxBr = tmp.Item1;
            float minBr = tmp.Item2;           
            Color sourceColor = img.GetPixel(x, y);

            int brightnessChange = (int)((sourceColor.GetBrightness() - minBr) * (255 / (maxBr - minBr)));
            
            Color resultColor = Color.FromArgb(Clamp(sourceColor.R + brightnessChange, 0, 255), Clamp(sourceColor.G + brightnessChange, 0, 255), Clamp(sourceColor.B + brightnessChange, 0, 255));
            
            
            return resultColor;

        }
    }
}

