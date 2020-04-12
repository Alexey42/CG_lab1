using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_lab1
{
    public partial class Form1 : Form
    {
        Bitmap img = null;
        Stack<Bitmap> history = new Stack<Bitmap>();

        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Image Files|*.png;*.jpg;*.bmp|All Files(*.*)|*.*";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                img = new Bitmap(fd.FileName);
                pictureBox1.Image = img;
                pictureBox1.Refresh();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            history.Push(img);
            Bitmap res = ((Filter)e.Argument).processImg(img, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true) img = res;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = img;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (history.Any())
            {
                img = history.Pop();
                pictureBox1.Image = img;
                pictureBox1.Refresh();
            }
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        
        private void гауссToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void полутонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new BrightFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void собельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new SharpFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new EmbossingFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new FlipFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new WaveFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void стеклоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new GlassFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void движениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new MotionBlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void щаррToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new SharrFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void прюиттToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new PrewittFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void медианныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new PrewittFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void влевоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new MoveLeftFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void отражательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) return;
            Filter filter = new PerfectReflectorFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}
