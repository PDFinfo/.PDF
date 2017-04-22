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
    public partial class Form2 : Form
    {
        int x;
        int k = 1, n = 1;
        ListBox l, m;
        int utx, uty;

        public Form2(int meret, ListBox li)
        {
            InitializeComponent();
            x = meret;
            l = li;
            m = li;
        }

        void Click1(object sender, EventArgs e)
        {
            Button clickedb = sender as Button;
            utx = Convert.ToInt32(clickedb.Name) / 1000;
            uty = Convert.ToInt32(clickedb.Name) % 1000;
            //jat[utx, uty].BackColor = Color.AliceBlue;
            //label3.Text = utx.ToString();
        }

        void Click2(object sender, EventArgs e)
        {
            Button clickedb = sender as Button;
            utx = Convert.ToInt32(clickedb.Name) / 10000;
            uty = Convert.ToInt32(clickedb.Name) % 10000;
            jat[utx, uty].BackColor = Color.AliceBlue;
            //label3.Text = utx.ToString();
        }

        Button[,] jat = new Button[200, 200];
        Button[,] gep = new Button[200, 200];
        int[,] bjat = new int[200, 200];

        private void button2_Click(object sender, EventArgs e)
        {
            bool b;
            button1.Enabled = false;
            button2.Enabled = false;

            b = false;
            if (l.Items.Count == 0 && m.Items.Count > 0)
            {
                int v, a, c;
                Random r = new Random();
                v = r.Next(1);
                if (v == 0)
                {
                    do
                    {
                        //b = false;
                        utx = r.Next(1, x);
                        uty = r.Next(1, x);
                        if (utx + Convert.ToInt32(m.Items[m.Items.Count - 1]) - 1 < x)
                        {
                            for (int i = 0; i < Convert.ToInt32(m.Items[m.Items.Count - 1]); i++)
                            {
                                if (gep[i + utx, uty].Enabled == false)
                                {
                                    b = true;

                                }
                            }
                            if (b == false)
                            {
                                for (int i = 0; i < Convert.ToInt32(m.Items[m.Items.Count - 1]); i++)
                                {
                                    gep[i + utx, uty].Enabled = false;
                                    gep[i + utx, uty].BackColor = Color.AliceBlue;
                                    bgep[i + utx, uty] = n;
                                    if (uty + 1 < x) gep[utx + i, uty + 1].Enabled = false;
                                    if (uty - 1 > 1) gep[utx + i, uty - 1].Enabled = false;

                                }
                                if (utx > 1) gep[utx - 1, uty].Enabled = false;
                                if (utx + Convert.ToInt32(m.Items[m.Items.Count - 1]) - 1 < x) gep[utx + Convert.ToInt32(m.Items[m.Items.Count - 1]), uty].Enabled = false;
                            }
                        }
                        else
                        {

                            b = true;
                        }
                    } while (b);
                }
                else
                {
                    do
                    {
                        utx = r.Next(1, x);
                        uty = r.Next(1, x);
                        if (uty + Convert.ToInt32(m.Items[m.Items.Count - 1]) - 1 < x)
                        {
                            for (int i = 0; i < Convert.ToInt32(m.Items[m.Items.Count - 1]); i++)
                            {
                                if (gep[utx, uty + i].Enabled == false)
                                {
                                    b = true;

                                }
                            }
                            if (b == false)
                            {
                                for (int i = 0; i < Convert.ToInt32(m.Items[m.Items.Count - 1]); i++)
                                {
                                    gep[utx, i + uty].Enabled = false;
                                    gep[i + utx, uty].BackColor = Color.AliceBlue;
                                    bgep[utx, i + uty] = n;
                                    if (utx + 1 < x) gep[utx + 1, uty + i].Enabled = false;
                                    if (utx - 1 > 1) gep[utx - 1, uty + i].Enabled = false;
                                }
                                if (uty > 1) gep[utx, uty - 1].Enabled = false;
                                if (uty + Convert.ToInt32(m.Items[m.Items.Count - 1]) - 1 < x) gep[utx, uty + Convert.ToInt32(m.Items[m.Items.Count - 1])].Enabled = false;
                            }
                        }
                        else
                        {

                            b = true;
                        }
                    } while (b);
                }
                if (b == false)
                {
                    n++;
                    m.Items.RemoveAt(m.Items.Count - 1);
                }
            }

            for (int i = 1; i <= x; i++)
            {
                for (int j = 1; j <= x; j++)
                {
                    gep[i, j].Visible = true;
                    gep[i, j].Enabled = true;
                    jat[i, j].Enabled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            int q = 0;
            if(bgep[utx, uty] != 0)
            {
                q = 0;
                bgep[utx, uty] = 0;
                gep[utx, uty].Text = "x";
                gep[utx, uty].Enabled = false;
                for (int a = 1; a <= x; a++)
                {
                    for (int b = 1; b <= x; b++)
                    {
                        if (bjat[a, b] != 0) q++;
                    }
                }
                if (q == 0)
                {
                    MessageBox.Show("te nyertel");
                    this.Close();
                }
            }
            else
            {
                gep[utx, uty].Text = "-";
                gep[utx, uty].Enabled = false;
                gepLo();
            }
        }

        void gepLo()
        {
            button3.Enabled = false;

            int i, j, q=0;
            do
            {
                Random r = new Random();
                i = r.Next(1, x);
                j = r.Next(1, x);
            } while (jat[i, j].Enabled == false);

            if (bjat[i, j] != 0)
            {
                q = 0;
                jat[i, j].Text = "x";
                jat[i, j].Enabled = false;
                bjat[i, j] = 0;
                for(int a = 1; a <= x; a++)
                {
                    for(int b = 1; b <= x; b++)
                    {
                        if (bjat[a, b] != 0) q++;
                    }
                }
                if (q == 0)
                {
                    MessageBox.Show("gep nyert");
                    this.Close();
                }
                gepLo();
            }
            else
            {
                jat[i, j].Text = "-";
                jat[i, j].Enabled = false;
                
            }

            button3.Enabled = true;
        }

        int[,] bgep = new int[200, 200];

        private void Form2_Load(object sender, EventArgs e)
        {
           
            for (int i = 1; i <= x; i++)
            {
                for (int j = 1; j <= x; j++)
                {
                    jat[i, j] = new Button();
                    jat[i, j].Size = new System.Drawing.Size(20, 20);
                    jat[i, j].Location = new System.Drawing.Point(20 + i * 20, 20 + j * 20);
                    jat[i, j].Click += new EventHandler(Click1);
                    jat[i, j].Name = (1000 * i + j).ToString();
                    this.Controls.Add(jat[i, j]);
                    jat[i, j].Show();
                }
            }

            for (int i = 1; i <= x; i++)
            {
                for (int j = 1; j <= x; j++)
                {
                    gep[i, j] = new Button();
                    gep[i, j].Size = new System.Drawing.Size(20, 20);
                    gep[i, j].Location = new System.Drawing.Point(420 + i * 20, 20 + j * 20);
                    gep[i, j].Click += new EventHandler(Click2);
                    gep[i, j].Name = (10000 * i + j).ToString();
                    this.Controls.Add(gep[i, j]);
                    gep[i, j].Visible = false;
                    gep[i, j].Show();
                }
            }

            label2.Text = l.Items[l.Items.Count-1].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool b = false;
            if(l.Items.Count > 0)
            {
                if (radioButton2.Checked)
                {
                    if (utx + Convert.ToInt32(l.Items[l.Items.Count - 1]) - 1 < x)
                    {
                        for (int i = 0; i < Convert.ToInt32(l.Items[l.Items.Count - 1]); i++)
                        {
                            if(jat[i + utx, uty].Enabled == false)
                            {
                                b = true;

                            }
                        }
                        if (b == false)
                        {
                            for (int i = 0; i < Convert.ToInt32(l.Items[l.Items.Count - 1]); i++)
                            {
                                jat[i + utx, uty].Enabled = false;
                                //jat[i + utx, uty].BackColor = Color.AliceBlue;
                                bjat[i + utx, uty] = k;
                               if(uty +1 <x) jat[utx + i, uty + 1].Enabled = false;
                               if(uty -1 > 1) jat[utx + i, uty - 1].Enabled = false;

                            }
                            if (utx > 1) jat[utx - 1, uty].Enabled = false;
                            if (utx + Convert.ToInt32(l.Items[l.Items.Count - 1])-1 < x) jat[utx + Convert.ToInt32(l.Items[l.Items.Count - 1]), uty].Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nem fer be");
                        b = true;
                    }
                }
                else
                {
                    if (uty + Convert.ToInt32(l.Items[l.Items.Count - 1]) - 1 < x)
                    {
                        for (int i = 0; i < Convert.ToInt32(l.Items[l.Items.Count - 1]); i++)
                        {
                            if (jat[utx, uty+  i].Enabled == false)
                            {
                                b = true;

                            }
                        }
                        if (b == false)
                        {
                            for (int i = 0; i < Convert.ToInt32(l.Items[l.Items.Count - 1]); i++)
                            {
                                jat[utx, i + uty].Enabled = false;
                                //jat[i + utx, uty].BackColor = Color.AliceBlue;
                                bjat[utx, i + uty] = k;
                             if(utx+1<x)   jat[utx + 1, uty + i].Enabled = false;
                              if(utx-1>1)  jat[utx - 1, uty + i].Enabled = false;
                            }
                            if (uty > 1) jat[utx, uty - 1].Enabled = false;
                            if (uty + Convert.ToInt32(l.Items[l.Items.Count - 1])-1 < x) jat[utx, uty + Convert.ToInt32(l.Items[l.Items.Count - 1])].Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nem fer be");
                        b = true;
                    }
                }
                if (b == false)
                {
                    k++;
                    l.Items.RemoveAt(l.Items.Count - 1);
                    if(l.Items.Count - 1 > 0)
                    label2.Text = l.Items[l.Items.Count - 1].ToString();
                }
            }
            
        }
    }
}
