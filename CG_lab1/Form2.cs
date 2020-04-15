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
    public partial class Form2 : Form
    {
        string name;

        public Form2(string _name)
        {
            InitializeComponent();
            name = _name;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            int[,] k = new int[3,3];

            int.TryParse(textBox1.Text, out k[0, 0]);
            int.TryParse(textBox2.Text, out k[0, 1]);
            int.TryParse(textBox3.Text, out k[0, 2]);
            int.TryParse(textBox4.Text, out k[1, 0]);
            int.TryParse(textBox5.Text, out k[1, 1]);
            int.TryParse(textBox6.Text, out k[1, 2]);
            int.TryParse(textBox7.Text, out k[2, 0]);
            int.TryParse(textBox8.Text, out k[2, 1]);
            int.TryParse(textBox9.Text, out k[2, 2]);           

            Filter filter = null;
            if (name == "Erosion") filter = new Erosion(k);
            if (name == "Dilatation") filter = new Dilatation(k);
            if (name == "Opening") filter = new Opening(k);
            if (name == "Closing") filter = new Closing(k);
            if (name == "TopHat") filter = new TopHat(k);
            this.Close();
            main.backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}
