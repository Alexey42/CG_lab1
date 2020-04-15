using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    class Opening:Filter
    {
        int[,] kernel;

        public Opening(int[,] _kernel)
        {
            kernel = _kernel;
        }
        protected override Color calcPixelColor(Bitmap sourceImage, int x, int y)
        {
            return sourceImage.GetPixel(x, y);
        }

        public override Bitmap processImg(Bitmap img, BackgroundWorker worker)
        {
            Filter filter1 = new Erosion(kernel);
            Bitmap res = filter1.processImg(img, worker);
            Filter filter2 = new Dilatation(kernel);
            res = filter2.processImg(res, worker);

            return res;
        }
    }
}
