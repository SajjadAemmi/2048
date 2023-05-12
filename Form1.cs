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

        Label[,] board = new Label[4, 4];
        Random rand = new Random();
        Int32 b, x, y, score = 0, newnum;
        Boolean sw, sw1, sw2;

        Char ch = ' ';

        private void Form1_Load(object sender, EventArgs e)
        {
            board = new Label[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    board[i, j] = new Label();
                    board[i, j].Text = "";
                    board[i, j].Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
                    board[i, j].Font = new Font("Tahoma", 32, FontStyle.Bold);
                    var margin = board[i, j].Margin;
                    margin.All = 4;
                    board[i, j].Margin = margin;
                    board[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    tlp_tiles.Controls.Add(board[i, j], i, j);
                }
            }

            for (int count = 0; count < 2; count++)
            {
                generateNewNumber();
            }

            setAppearance();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            sw = true;

            for (int count = 0; count < 4; count++)
            {
                if (e.KeyData == Keys.Left)
                {
                    ch = 'L';
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (i - 1 != -1 && board[i, j].Text.CompareTo("") != 0 && board[i - 1, j].Text.CompareTo("") == 0)
                            {
                                board[i - 1, j].Text = board[i, j].Text;
                                board[i, j].Text = "";
                                sw = false;
                            }
                            if (i - 1 != -1 && board[i, j].Text.CompareTo(board[i - 1, j].Text) == 0 && board[i, j].Text.CompareTo("") != 0)
                            {
                                b = Convert.ToInt32(board[i - 1, j].Text);
                                b *= 2;
                                board[i - 1, j].Text = Convert.ToString(b);
                                board[i, j].Text = "";
                                score = score + Convert.ToInt32(board[i - 1, j].Text);
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
                            if (i + 1 != 4 && board[i, j].Text.CompareTo("") != 0 && board[i + 1, j].Text.CompareTo("") == 0)
                            {
                                board[i + 1, j].Text = board[i, j].Text;
                                board[i, j].Text = "";
                                sw = false;
                            }
                            if (i + 1 != 4 && board[i, j].Text.CompareTo(board[i + 1, j].Text) == 0 && board[i, j].Text.CompareTo("") != 0)
                            {
                                b = Convert.ToInt32(board[i + 1, j].Text);
                                b *= 2;
                                board[i + 1, j].Text = Convert.ToString(b);
                                board[i, j].Text = "";
                                score = score + Convert.ToInt32(board[i + 1, j].Text);
                                sw = false;
                            }
                        }
                    }
                }
                else if (e.KeyData == Keys.Up)
                {
                    ch = 'U';
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (j - 1 != -1 && board[i, j].Text.CompareTo("") != 0 && board[i, j - 1].Text.CompareTo("") == 0)
                            {
                                board[i, j - 1].Text = board[i, j].Text;
                                board[i, j].Text = "";
                                sw = false;
                            }
                            if (j - 1 != -1 && board[i, j].Text.CompareTo(board[i, j - 1].Text) == 0 && board[i, j].Text.CompareTo("") != 0)
                            {
                                b = Convert.ToInt32(board[i, j - 1].Text);
                                b *= 2;
                                board[i, j - 1].Text = Convert.ToString(b);
                                board[i, j].Text = "";
                                score = score + Convert.ToInt32(board[i, j - 1].Text);
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
                            if (j + 1 != 4 && board[i, j].Text.CompareTo("") != 0 && board[i, j + 1].Text.CompareTo("") == 0)
                            {
                                board[i, j + 1].Text = board[i, j].Text;
                                board[i, j].Text = "";
                                sw = false;
                            }
                            if (j + 1 != 4 && board[i, j].Text.CompareTo(board[i, j + 1].Text) == 0 && board[i, j].Text.CompareTo("") != 0)
                            {
                                b = Convert.ToInt32(board[i, j + 1].Text);
                                b *= 2;
                                board[i, j + 1].Text = Convert.ToString(b);
                                board[i, j].Text = "";
                                score = score + Convert.ToInt32(board[i, j + 1].Text);
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
                        if (board[i, j].Text.CompareTo("") == 0)
                        {
                            sw1 = false;
                        }
                        if (board[i, j].Text.CompareTo("2048") == 0)
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

            if (sw1 == true)
            {
                generateNewNumber();
            }
            setAppearance();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2048 v 2.01\nProgrammer: Sajjad Aemmi", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    board[i, j].Text = "";
                }
            }

            for (int count = 0; count < 2; count++)
            {
                sw2 = true;
                while (sw2 == true)
                {
                    x = rand.Next(0, 4);
                    y = rand.Next(0, 4);
                    if (board[x, y].Text.CompareTo("") == 0)
                        sw2 = false;
                }

                newnum = rand.Next(0, 3);
                if (newnum == 0)
                    board[x, y].Text = "4";
                if (newnum == 1 || newnum == 2)
                    board[x, y].Text = "2";
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j].Text.CompareTo("") == 0)
                    {
                        board[i, j].ForeColor = Color.White;
                        board[i, j].BackColor = ColorTranslator.FromHtml("#cdc1b4");
                    }
                    else if (board[i, j].Text.CompareTo("2") == 0)
                    {
                        board[i, j].ForeColor = Color.Black;
                        board[i, j].BackColor = Color.LightGreen;
                    }
                    else if (board[i, j].Text.CompareTo("4") == 0)
                    {
                        board[i, j].ForeColor = Color.Black;
                        board[i, j].BackColor = Color.GreenYellow;
                    }
                }
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do You Want To Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void generateNewNumber()
        {
            sw2 = true;
            while (sw2 == true)
            {
                x = rand.Next(0, 4);
                y = rand.Next(0, 4);
                if (board[x, y].Text.CompareTo("") == 0 && (ch == ' ' || (ch == 'L' && x == 3) || (ch == 'R' && x == 0) || (ch == 'U' && y == 3) || (ch == 'D' && y == 0)))
                    sw2 = false;
            }

            newnum = rand.Next(0, 3);
            if (newnum == 0)
                board[x, y].Text = "4";
            if (newnum == 1 || newnum == 2)
                board[x, y].Text = "2";
        }

        private void setAppearance()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j].Text.CompareTo("") == 0)
                    {
                        board[i, j].BackColor = ColorTranslator.FromHtml("#cdc1b4");
                    }
                    else if (board[i, j].Text.CompareTo("2") == 0)
                    {
                        board[i, j].Font = new Font("Tahoma", 32, FontStyle.Bold);
                        board[i, j].ForeColor = ColorTranslator.FromHtml("#776E65");
                        board[i, j].BackColor = ColorTranslator.FromHtml("#eee4da");
                    }
                    else if (board[i, j].Text.CompareTo("4") == 0)
                    {
                        board[i, j].Font = new Font("Tahoma", 32, FontStyle.Bold);
                        board[i, j].ForeColor = ColorTranslator.FromHtml("#776E65");
                        board[i, j].BackColor = ColorTranslator.FromHtml("#eee2cf");
                    }
                    else if (board[i, j].Text.CompareTo("8") == 0)
                    {
                        board[i, j].Font = new Font("Tahoma", 32, FontStyle.Bold);
                        board[i, j].ForeColor = ColorTranslator.FromHtml("#f9f6f2");
                        board[i, j].BackColor = ColorTranslator.FromHtml("#f3b27f");
                    }
                    else if (board[i, j].Text.CompareTo("16") == 0)
                    {
                        board[i, j].Font = new Font("Tahoma", 32, FontStyle.Bold);
                        board[i, j].ForeColor = ColorTranslator.FromHtml("#f9f6f2");
                        board[i, j].BackColor = ColorTranslator.FromHtml("#f6976c");
                    }
                    else if (board[i, j].Text.CompareTo("32") == 0)
                    {
                        board[i, j].Font = new Font("Tahoma", 32, FontStyle.Bold);
                        board[i, j].ForeColor = ColorTranslator.FromHtml("#f9f6f2");
                        board[i, j].BackColor = ColorTranslator.FromHtml("#f77f69");
                    }
                    else if (board[i, j].Text.CompareTo("64") == 0)
                    {
                        board[i, j].Font = new Font("Tahoma", 32, FontStyle.Bold);
                        board[i, j].ForeColor = ColorTranslator.FromHtml("#f9f6f2");
                        board[i, j].BackColor = ColorTranslator.FromHtml("#f76248");
                    }
                    else if (board[i, j].Text.CompareTo("128") == 0)
                    {
                        board[i, j].Font = new Font("Tahoma", 24, FontStyle.Bold);
                        board[i, j].ForeColor = ColorTranslator.FromHtml("#f9f6f2");
                        board[i, j].BackColor = ColorTranslator.FromHtml("#eed695");
                    }
                    else if (board[i, j].Text.CompareTo("256") == 0)
                    {
                        board[i, j].Font = new Font("Tahoma", 24, FontStyle.Bold);
                        board[i, j].ForeColor = ColorTranslator.FromHtml("#f9f6f2");
                        board[i, j].BackColor = ColorTranslator.FromHtml("#eed48a"); 
                    }
                    else if (board[i, j].Text.CompareTo("512") == 0)
                    {
                        board[i, j].Font = new Font("Tahoma", 24, FontStyle.Bold);
                        board[i, j].ForeColor = ColorTranslator.FromHtml("#f9f6f2");
                        board[i, j].BackColor = ColorTranslator.FromHtml("#eed48a");
                    }
                    else if (board[i, j].Text.CompareTo("1024") == 0)
                    {
                        board[i, j].Font = new Font("Tahoma", 16, FontStyle.Bold);
                        board[i, j].ForeColor = ColorTranslator.FromHtml("#f9f6f2");
                        board[i, j].BackColor = ColorTranslator.FromHtml("#eed48a");
                    }
                    else if (board[i, j].Text.CompareTo("2048") == 0)
                    {
                        board[i, j].Font = new Font("Tahoma", 16, FontStyle.Bold);
                        board[i, j].ForeColor = ColorTranslator.FromHtml("#f9f6f2");
                        board[i, j].BackColor = ColorTranslator.FromHtml("#eed48a");
                    }
                }
            }
        }
    }
}