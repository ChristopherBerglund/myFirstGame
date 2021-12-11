using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myFirstGame
{
    public partial class Form1 : Form
    {
        bool goLeft, goRight, jumping, isGameOver;
        int jumpSpeed;
        int force;
        int score = 0;
        int playerSpeed = 12;

        int horizontalSpeed = 8;
        int verticalSpeed = 6;

        int enemyOneSpeed = 2;
        int enemyTwoSpeed = 3;
        int enemyThreeSpeed = 4;
        int enemyFourSpeed = 5;

        public Form1()
        {
            InitializeComponent();
        }

  

        private void MainGameTimeEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;
            Player.Top += jumpSpeed;

            if(goLeft == true)
            {
                Player.Left -= playerSpeed;
            }
            if(goRight == true)
            {
                Player.Left += playerSpeed;
            }
            if(jumping == true && force < 0)
            {
               jumping = false;
            }
            if (jumping == true)
            {
                jumpSpeed = -8;
                force -= 1;
            }

            else
            {
                jumpSpeed = 10;
            }
            foreach (Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if((string)x.Tag == "Platform")
                    {
                        if (Player.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            Player.Top = x.Top - Player.Height;
                            if ((string)x.Name == "HorizontalPlatform" && goLeft == false || (string)x.Name == "HorizontalPlatform" && goRight == false)
                            {
                                Player.Left -= horizontalSpeed;
                            }
                        }
                        x.BringToFront();
                    }
                    
                    if ((string)x.Tag == "coin")
                    {
                        if (Player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }
                    if ((string)x.Tag == "Enemy")
                    {
                        if (Player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameTimer.Stop();
                            isGameOver = true;
                            txtScore.Text = "Score: " + score + Environment.NewLine + "You where killed in your journey!";
                        }

                    }
                }
            }

            HorizontalPlatform.Left -= horizontalSpeed;

            if (HorizontalPlatform.Left < 400 || HorizontalPlatform.Left > 500)
            {
                horizontalSpeed = -horizontalSpeed;
            }

            VerticalPlatform.Top += verticalSpeed;
            if(VerticalPlatform.Top < 162 || VerticalPlatform.Top > 461)
            {
                verticalSpeed = -verticalSpeed;
            }

            EnemyOne.Left -= enemyOneSpeed;
            if(EnemyOne.Left < pictureBox4.Left || EnemyOne.Left + EnemyOne.Width > pictureBox4.Left + pictureBox4.Width)
            {
                enemyOneSpeed = -enemyOneSpeed;
            }

            EnemyTwo.Left -= enemyTwoSpeed;
            if (EnemyTwo.Left < pictureBox7.Left || EnemyTwo.Left + EnemyTwo.Width > pictureBox7.Left + pictureBox7.Width)
            {
                enemyTwoSpeed = -enemyTwoSpeed;
            }

            EnemyThree.Left -= enemyThreeSpeed;
            if (EnemyThree.Left < pictureBox9.Left || EnemyThree.Left + EnemyThree.Width > pictureBox9.Left + pictureBox9.Width)
            {
                enemyThreeSpeed = -enemyThreeSpeed;
            }

            EnemyFour.Left -= enemyFourSpeed;
            if (EnemyFour.Left < pictureBox14.Left || EnemyFour.Left + EnemyFour.Width > pictureBox14.Left + pictureBox14.Width)
            {
                enemyFourSpeed = -enemyFourSpeed;
            }
            if(Player.Top + Player.Height > 700)
            {
                gameTimer.Stop();
                isGameOver = true;
                txtScore.Text = "Score: " + score + Environment.NewLine + "You fell to the death!";
            }

            if(Player.Bounds.IntersectsWith(Door.Bounds) && score == 50)
            {
                gameTimer.Stop();
                isGameOver=true;
                txtScore.Text = "Score: " + score + Environment.NewLine + "Congratulation, youve done it!!"; 
            }
            if (Player.Bounds.IntersectsWith(Door.Bounds) && score != 50)
            {
                txtScore.Text = "Score: " + score + Environment.NewLine + "Collect all the coins first..!!";
            }



        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if(e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void KeyIsUo(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if(jumping == true)
            {
                jumping = false;
            }
            if(e.KeyCode == Keys.Enter && isGameOver == true)
            {
                RestardGame();
            }






        }

   


        private void RestardGame()
        {
            jumping = false;
            goLeft = false;
            goRight = false;
            isGameOver = false;
            score = 0;

            txtScore.Text = "Score: " + score;

            foreach  (Control x in this.Controls)
            {
                if(x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }

            Player.Left = 114;
            Player.Top = 600;

            EnemyOne.Left = 410;//*
            EnemyTwo.Left = 804;//*
            EnemyThree.Left = 780;
            EnemyFour.Left = 480;//*

            VerticalPlatform.Top = 382;
            HorizontalPlatform.Left = 447;

            gameTimer.Start();



        }






















        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
