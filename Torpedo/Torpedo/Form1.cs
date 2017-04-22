//.pdf
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Torpedo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int meret;

        private void button3_Click(object sender, EventArgs e)
        {
            meret = Convert.ToInt32(numericUpDown1.Value);
            numericUpDown1.Enabled = false;
            numericUpDown2.Maximum = meret - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(numericUpDown2.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 x = new Form2(meret, listBox1);
            x.Show();
        }
    }
}
