using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TenkIgra
{
    public partial class TankGame : Form
    {
        bool levo, desno;
        int brzinaTenka = 12;
        int brzinaMete = 5;
        int score = 0;
        int projektilMeteTimer = 300;

        PictureBox[] shermans;

        bool shooting;
        bool isGameOver;


        public TankGame()
        {
            InitializeComponent();
            gameSetUp();
        }

        private void mainGameTimeEvent(object sender, EventArgs e)
        {
            Score.Text = "SCORE: " + score;

            if (levo)
            {
                Tenk.Left -= brzinaTenka;
            }
            if (desno)
            {
                Tenk.Left += brzinaTenka;
            }

            projektilMeteTimer -= 10;

            if(projektilMeteTimer < 1)
            {
                projektilMeteTimer = 300;
                projektil("shermanShell");
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "shermans")
                {
                    x.Left += brzinaMete;

                    if(x.Left > 730)
                    {
                        x.Top += 90;
                        x.Left = -80;
                    }

                    if(x.Bounds.IntersectsWith(Tenk.Bounds))
                    {
                        gameOver("Scheiße! amerikanische Schweine haben Ihre Position erreicht!");
                    }

                    foreach(Control y in this.Controls)
                    {
                        if(y is PictureBox && (string)y.Tag == "shell")
                        {
                            if (y.Bounds.IntersectsWith(x.Bounds))
                            {
                                this.Controls.Remove(x);
                                this.Controls.Remove(y);
                                score += 1;
                                shooting = false;
                            }
                        }
                    }
                }

                if(x is PictureBox && (string)x.Tag == "shell")
                {
                    x.Top -= 20;

                    if(x.Top < 15)
                    {
                        this.Controls.Remove(x);
                        shooting = false;
                    }

                }

                if (x is PictureBox && (string)x.Tag == "shermanShell")
                {
                    x.Top += 20;

                    if(x.Top > 600)
                    {
                        this.Controls.Remove(x);
                    }

                    if (x.Bounds.IntersectsWith(Tenk.Bounds))
                    {
                        this.Controls.Remove(x);
                        gameOver("Scheiße! Amerikaner haben Ihren Panzer zerstört!");
                    }
                }
            }

            if(score > 10)
            {
                brzinaMete = 8;
            }

            if (score > 15)
            {
                brzinaMete = 10;
            }

            if (score == shermans.Length)
            {
                gameOver("Du hast alle Amerikaner besiegt!");
            }
        }

        private void strelicaDolje(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                levo = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                desno = true;
            }
        }

        private void strelicaGore(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                levo = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                desno = false;
            }
            if(e.KeyCode == Keys.Space && shooting == false)
            {
                shooting = true;
                projektil("shell");
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                removeAll();
                gameSetUp();
            }
        }

        private void makeShermans()
        {
            shermans = new PictureBox[20];

            int left = 0;

            for(int i = 0; i < shermans.Length; i++)
            {
                shermans[i] = new PictureBox();
                shermans[i].Size = new Size(35, 70);
                shermans[i].Image = Properties.Resources.sherman;
                shermans[i].Top = 5;
                shermans[i].Tag = "shermans";
                shermans[i].Left = left;
                shermans[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(shermans[i]);
                left = left - 80;
            }
        }

        private void gameSetUp()
        {
            Score.Text = "SCORE: 0";
            score = 0;
            isGameOver = false;

            projektilMeteTimer = 300;
            brzinaMete = 5;
            shooting = false;

            makeShermans();
            GameTimer.Start();
        }

        private void gameOver(string poruka)
        {
            isGameOver = true;
            GameTimer.Stop();
            Score.Text = "SCORE: " + score + " " + poruka;
        }

        private void removeAll()
        {
            foreach(PictureBox i in shermans)
            {
                this.Controls.Remove(i);
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if((string)x.Tag == "shell" || (string)x.Tag == "shermanShell")
                    {
                        this.Controls.Remove(x);
                    }
                }
            }
        }

        private void projektil(string projektilTag)
        {
            PictureBox shell = new PictureBox();
            shell.Image = Properties.Resources.shell;
            shell.Size = new Size(5, 20);
            shell.SizeMode = PictureBoxSizeMode.StretchImage;
            shell.Tag = projektilTag;
            shell.Left = Tenk.Left + Tenk.Width / 2;

            if((string)shell.Tag == "shell")
            {
                shell.Top = Tenk.Top - 20;
            }
            else if ((string)shell.Tag == "shermanShell")
            {
                shell.Top = -100;
            }

            this.Controls.Add(shell);
            shell.BringToFront();
        }
    }
}
