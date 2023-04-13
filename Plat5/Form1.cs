using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plat5
{
    public partial class Form1 : Form
    {
        bool left, right;
        int playerSpeed = 0;
        int jumpHeight = 200;
        int jumpSpeed = 10;
        bool isJumping = false, rightColision = false, leftColision = false, topColision = false;
        int jumpCounter = 0;
        string jumpDirection = "down";
        int gravity = 8;

        Rectangle rect1 = new Rectangle(10, 10, 50, 50); // create first rectangle
        Rectangle rect2 = new Rectangle(30, 30, 50, 50); // create second rectangle


        private void player_Paint(object sender, PaintEventArgs e)
        {

        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            //esquerda
            if (e.KeyCode == Keys.Left)
            {
                left = true;
                playerSpeed = -10;
            }

            //direita
            if (e.KeyCode == Keys.Right)

            {
                right = true;
                playerSpeed = 10;
            }

            //saltar
            if (e.KeyCode == Keys.Space && !isJumping)
            {
                isJumping = true;
                jumpDirection = "up";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void platform_Click(object sender, EventArgs e)
        {

        }

        private void keyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                left = false;
                playerSpeed = 0;

            }

            if (e.KeyCode == Keys.Right)
            {
                right = false;
                playerSpeed = 0;

            }

            if (e.KeyCode == Keys.Space && !isJumping)
            {
                isJumping = false;
                jumpDirection = "down";
            }
        }

        public Form1()
        {
            InitializeComponent();
            //Set the Parent property of the PictureBox to be the parent control
            player.Parent = this;
            //// Set the TransparentColor property of the PictureBox to make a specific color transparent
            player.BackColor = Color.Transparent;





            //player.Image = Image.FromFile("d:\\aulas atec\\pacheco\\jogoplat4\\jogoplat4\\resources\\gir.png");
            //player.SizeMode = PictureBoxSizeMode.StretchImage;
            //Bitmap bmp = new Bitmap(player.Image);

            //// Set the transparent color to make it transparent
            //bmp.MakeTransparent(Color.White);

            //// Set the bitmap as the new image of the PictureBox control
            //player.Image = bmp;
        }

        private void gameTime(object sender, EventArgs e)
        {
            // se nao estiver a saltar ou se nao estiver por cima de uma plataforma a gravidade está sempre a atuar
            if (!isJumping && !topColision)
            {
                player.Top += gravity;
            }


            if (left == true && player.Left > 50 && !rightColision)
            {
                player.Left += playerSpeed; // variavel entra como -10
            }

            if (right == true && player.Left + (player.Width + 50) < this.ClientSize.Width && !leftColision)
            {
                player.Left += playerSpeed; //variavel entra como 10
            }

            leftColision = false;
            rightColision = false;
            topColision = false;


            if (isJumping)
            {
                if (jumpDirection == "up")
                {

                    player.Top -= jumpSpeed; //vai se movimentar no sentido para cima, valor em y diminui

                    jumpCounter += jumpSpeed; //movimenta-se de 10 em 10 o numero de iteracoes até atingir o limite maximo

                    if (jumpCounter >= jumpHeight) // quando atingir o maximo de altura inicia a descida
                    {
                        jumpDirection = "down";
                    }
                }
                else
                {

                    player.Top += jumpSpeed;

                    jumpCounter -= jumpSpeed;

                    if (jumpCounter <= 0)
                    {
                        isJumping = false;
                    }
                }
            }

            rect1 = player.Bounds; // rectangulo fica com as dimensoes da picturebox

            foreach (Control control in this.Controls) //todos os objetos 
            {
                if (control is PictureBox && (string)control.Tag == "platform")
                {
                    rect2 = control.Bounds;

                    if (rect1.IntersectsWith(rect2))
                    {
                        Rectangle intersection = Rectangle.Intersect(rect1, rect2);

                        if (intersection.Width < intersection.Height) // colisao lateral
                        {

                            if (rect1.X < rect2.X) //esquerda
                            {
                                rect1.X -= intersection.Width;
                                leftColision = true;
                            }
                            else  //direita
                            {
                                rect1.X += intersection.Width;
                                rightColision = true;
                            }
                        }
                        else // colisao vertical
                        {

                            if (rect1.Y < rect2.Y) // por cima da plataforma
                            {
                                player.Top = control.Top - player.Height;
                                topColision = true;
                                rect1.Y -= intersection.Height;
                            }
                            else // por baixo da plataforma
                            {
                                isJumping = false;
                            }
                        }
                    }

                    //    label1.Text = "colisao2";
                    //    // Check for right collision
                    //    if (rect1.Left < rect2.Right && rect1.Left > rect2.Left && rect1.Bottom > rect2.Top && rect1.Top < rect2.Bottom)
                    //    {
                    //        label1.Text = "colisao";
                    //        rightColision = true;
                    //        player.BackColor = Color.White;

                    //        // Right collision detected
                    //        // Add code to handle the right collision here
                    //    }

                    //    if (rect1.Right > rect2.Left && rect1.Right < rect2.Right && rect1.Bottom > rect2.Top && rect1.Top < rect2.Bottom)
                    //    {
                    //        label1.Text = "colisao";
                    //        leftColision = true;
                    //        player.BackColor = Color.Red;
                    //        // Left collision detected
                    //        // Add code to handle the left collision here
                    //    }

                    //    // Check for top collision
                    //    if (rect1.Bottom > rect2.Top && rect1.Bottom < rect2.Bottom && rect1.Right > rect2.Left && rect1.Left < rect2.Right)
                    //    {
                    //        player.Top = control.Top - player.Height;
                    //        label1.Text = rect1.Right.ToString();
                    //        player.BackColor = Color.YellowGreen;
                    //        break;

                    //        // Top collision detected
                    //        // Add code to handle the top collision here
                    //    }


                    //    // Check for bottom collision
                    //    if (rect1.Top < rect2.Bottom && rect1.Top > rect2.Top && rect1.Right > rect2.Left && rect1.Left < rect2.Right)
                    //    {
                    //        label1.Text = "rabo";
                    //        jumpDirection = "down";
                    //        player.BackColor = Color.Gainsboro;
                    //        // Bottom collision detected
                    //        // Add code to handle the bottom collision here
                    //    }
                    //}
                    //else gravity = 8;
                }



            }







        }
    }

}
