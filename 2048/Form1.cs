using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Label[,] a = new Label[4, 4];
        Random rand = new Random();
        Int32 b, c, x, y, score = 0, newnum;
        Boolean sw, sw1, sw2, sw3;
        Char ch;

        private void Form1_Load(object sender, EventArgs e)
        {
            a[0, 0] = label1;
            a[0, 1] = label2;
            a[0, 2] = label3;
            a[0, 3] = label4;
            a[1, 0] = label5;
            a[1, 1] = label6;
            a[1, 2] = label7;
            a[1, 3] = label8;
            a[2, 0] = label9;
            a[2, 1] = label10;
            a[2, 2] = label11;
            a[2, 3] = label12;
            a[3, 0] = label13;
            a[3, 1] = label14;
            a[3, 2] = label15;
            a[3, 3] = label16;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    a[i, j].Text = "0";
                }
            }

            for (int count = 0; count < 2; count++)
            {
                sw2 = true;
                while (sw2 == true)
                {
                    x = rand.Next(0, 4);
                    y = rand.Next(0, 4);
                    if (a[x, y].Text.CompareTo("0") == 0)
                        sw2 = false;
                }

                newnum = rand.Next(0, 3);
                if (newnum == 0)
                    a[x, y].Text = "4";
                if (newnum == 1 || newnum == 2)
                    a[x, y].Text = "2";
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (a[i, j].Text.CompareTo("0") == 0)
                    {
                        a[i, j].ForeColor = Color.White;
                        a[i, j].BackColor = Color.White;
                    }
                    else if (a[i, j].Text.CompareTo("2") == 0)
                    {
                        a[i, j].ForeColor = Color.Black;
                        a[i, j].BackColor = Color.LightGreen;
                    }
                    else if (a[i, j].Text.CompareTo("4") == 0)
                    {
                        a[i, j].ForeColor = Color.Black;
                        a[i, j].BackColor = Color.GreenYellow;
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            sw = true;

            for (int count = 0; count < 4; count++)
            {
                if (e.KeyData == Keys.Up)
                {
                    ch = 'U';
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (i - 1 != -1 && a[i, j].Text.CompareTo("0") != 0 && a[i - 1, j].Text.CompareTo("0") == 0)
                            {
                                a[i - 1, j].Text = a[i, j].Text;
                                a[i, j].Text = "0";
                                sw = false;
                            }
                            if (i - 1 != -1 && a[i, j].Text.CompareTo(a[i - 1, j].Text) == 0 && a[i, j].Text.CompareTo("0") != 0)
                            {
                                b = Convert.ToInt32(a[i - 1, j].Text);
                                b *= 2;
                                a[i - 1, j].Text = Convert.ToString(b);
                                a[i, j].Text = "0";
                                score = score + Convert.ToInt32(a[i - 1, j].Text);
                                sw = false;
                            }
                        }
                    }
                }
                else if (e.KeyData == Keys.Down)
                {
                    ch = 'D';
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (i + 1 != 4 && a[i, j].Text.CompareTo("0") != 0 && a[i + 1, j].Text.CompareTo("0") == 0)
                            {
                                a[i + 1, j].Text = a[i, j].Text;
                                a[i, j].Text = "0";
                                sw = false;
                            }
                            if (i + 1 != 4 && a[i, j].Text.CompareTo(a[i + 1, j].Text) == 0 && a[i, j].Text.CompareTo("0") != 0)
                            {
                                b = Convert.ToInt32(a[i + 1, j].Text);
                                b *= 2;
                                a[i + 1, j].Text = Convert.ToString(b);
                                a[i, j].Text = "0";
                                score = score + Convert.ToInt32(a[i + 1, j].Text);
                                sw = false;
                            }
                        }
                    }
                }
                else if (e.KeyData == Keys.Left)
                {
                    ch = 'L';
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (j - 1 != -1 && a[i, j].Text.CompareTo("0") != 0 && a[i, j - 1].Text.CompareTo("0") == 0)
                            {
                                a[i, j - 1].Text = a[i, j].Text;
                                a[i, j].Text = "0";
                                sw = false;
                            }
                            if (j - 1 != -1 && a[i, j].Text.CompareTo(a[i, j - 1].Text) == 0 && a[i, j].Text.CompareTo("0") != 0)
                            {
                                b = Convert.ToInt32(a[i, j - 1].Text);
                                b *= 2;
                                a[i, j - 1].Text = Convert.ToString(b);
                                a[i, j].Text = "0";
                                score = score + Convert.ToInt32(a[i, j - 1].Text);
                                sw = false;
                            }
                        }
                    }
                }
                else if (e.KeyData == Keys.Right)
                {
                    ch = 'R';
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (j + 1 != 4 && a[i, j].Text.CompareTo("0") != 0 && a[i, j + 1].Text.CompareTo("0") == 0)
                            {
                                a[i, j + 1].Text = a[i, j].Text;
                                a[i, j].Text = "0";
                                sw = false;
                            }
                            if (j + 1 != 4 && a[i, j].Text.CompareTo(a[i, j + 1].Text) == 0 && a[i, j].Text.CompareTo("0") != 0)
                            {
                                b = Convert.ToInt32(a[i, j + 1].Text);
                                b *= 2;
                                a[i, j + 1].Text = Convert.ToString(b);
                                a[i, j].Text = "0";
                                score = score + Convert.ToInt32(a[i, j + 1].Text);
                                sw = false;
                            }
                        }
                    }
                }
                else
                    return;
            }

            label18.Text = Convert.ToString(score);

            sw1 = true;

            if (sw == true)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (a[i, j].Text.CompareTo("0") == 0)
                        {
                            sw1 = false;
                        }
                        if (a[i, j].Text.CompareTo("2048") == 0)
                        {
                            MessageBox.Show("You Win!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                if (sw1 == true)
                {
                    MessageBox.Show("Game Over!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            sw2 = true;
            while (sw2 == true)
            {
                x = rand.Next(0, 4);
                y = rand.Next(0, 4);
                if (a[x, y].Text.CompareTo("0") == 0 && ((ch == 'U' && x == 3) || (ch == 'D' && x == 0) || (ch == 'L' && y == 3) || (ch == 'R' && y == 0)))
                    sw2 = false;
            }

            if (sw1 == true)
            {
                newnum = rand.Next(0, 3);
                if (newnum == 0)
                    a[x, y].Text = "4";
                if (newnum == 1 || newnum == 2)
                    a[x, y].Text = "2";
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (a[i, j].Text.CompareTo("0") == 0)
                    {
                        a[i, j].ForeColor = Color.White;
                        a[i, j].BackColor = Color.White;
                    }
                    else if (a[i, j].Text.CompareTo("2") == 0)
                    {
                        a[i, j].ForeColor = Color.Black;
                        a[i, j].BackColor = Color.LightGreen;
                    }
                    else if (a[i, j].Text.CompareTo("4") == 0)
                    {
                        a[i, j].ForeColor = Color.Black;
                        a[i, j].BackColor = Color.GreenYellow;
                    }
                    else if (a[i, j].Text.CompareTo("8") == 0)
                    {
                        a[i, j].ForeColor = Color.White;
                        a[i, j].BackColor = Color.CadetBlue;
                    }
                    else if (a[i, j].Text.CompareTo("16") == 0)
                    {
                        a[i, j].ForeColor = Color.White;
                        a[i, j].BackColor = Color.Orchid;
                    }
                    else if (a[i, j].Text.CompareTo("32") == 0)
                    {
                        a[i, j].ForeColor = Color.White;
                        a[i, j].BackColor = Color.DarkMagenta;
                    }
                    else if (a[i, j].Text.CompareTo("64") == 0)
                    {
                        a[i, j].ForeColor = Color.Black;
                        a[i, j].BackColor = Color.Cyan;
                    }
                    else if (a[i, j].Text.CompareTo("128") == 0)
                    {
                        a[i, j].ForeColor = Color.White;
                        a[i, j].BackColor = Color.LightSeaGreen;
                    }
                    else if (a[i, j].Text.CompareTo("256") == 0)
                    {
                        a[i, j].ForeColor = Color.White;
                        a[i, j].BackColor = Color.Magenta;
                    }
                    else if (a[i, j].Text.CompareTo("512") == 0)
                    {
                        a[i, j].ForeColor = Color.White;
                        a[i, j].BackColor = Color.Orange;
                    }
                    else if (a[i, j].Text.CompareTo("1024") == 0)
                    {
                        a[i, j].ForeColor = Color.White;
                        a[i, j].BackColor = Color.Silver;
                    }
                    else if (a[i, j].Text.CompareTo("2048") == 0)
                    {
                        a[i, j].ForeColor = Color.White;
                        a[i, j].BackColor = Color.Gold;
                    }
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2048 v 2.01\nProgrammer: Sajjad Aemmi\nAll Rights Reserved.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    a[i, j].Text = "0";
                }
            }

            for (int count = 0; count < 2; count++)
            {
                sw2 = true;
                while (sw2 == true)
                {
                    x = rand.Next(0, 4);
                    y = rand.Next(0, 4);
                    if (a[x, y].Text.CompareTo("0") == 0)
                        sw2 = false;
                }

                newnum = rand.Next(0, 3);
                if (newnum == 0)
                    a[x, y].Text = "4";
                if (newnum == 1 || newnum == 2)
                    a[x, y].Text = "2";
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (a[i, j].Text.CompareTo("0") == 0)
                    {
                        a[i, j].ForeColor = Color.White;
                        a[i, j].BackColor = Color.White;
                    }
                    else if (a[i, j].Text.CompareTo("2") == 0)
                    {
                        a[i, j].ForeColor = Color.Black;
                        a[i, j].BackColor = Color.LightGreen;
                    }
                    else if (a[i, j].Text.CompareTo("4") == 0)
                    {
                        a[i, j].ForeColor = Color.Black;
                        a[i, j].BackColor = Color.GreenYellow;
                    }
                }
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do You Want To Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}