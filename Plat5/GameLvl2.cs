using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plat5
{
    public partial class GameLvl2 : Form
    {


        bool left, right;
        int playerSpeed = 0;
        int jumpHeight = 200;
        int jumpSpeed = 10;
        bool isJumping = false, rightColision = false, leftColision = false, hasGravity = true;
        int jumpCounter = 0;
        string jumpDirection = "down";
        int gravity = 15;
        int itemSpeed = 5;
        int flowers = 0;



        
        Rectangle rect1 = new Rectangle(30, 30, 50, 50);
        Rectangle rect2 = new Rectangle(30, 30, 50, 50);

        

        public GameLvl2()
        {
            InitializeComponent();

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "flower.txt");
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                lb_flower.Text = content;
                reader.Close();

                using (StreamWriter writer = new StreamWriter(filePath))
                {

                    writer.Write("");
                    writer.Close();
                }

            }

            InitializeComponent();
            //Set the Parent property of the PictureBox to be the parent control
            player.Parent = this;
            //// Set the TransparentColor property of the PictureBox to make a specific color transparent
            player.BackColor = Color.Transparent;
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {

        }


        private void gameTime(object sender, EventArgs e)
        {



            // se nao estiver a saltar se a flag da gravidade estiver a true ou seja que nao está em colisao com nenhuma plataforma aplica gravi
            if (isJumping == false && hasGravity == true)
            {
                player.Top += gravity;
            }


            if (left == true && player.Left > 200 && !rightColision)
            {
                player.Left -= playerSpeed;
            }

            if (right == true && player.Left + (player.Width + 200) < this.ClientSize.Width && !leftColision)
            {
                player.Left += playerSpeed;
            }

            if (left == true && !rightColision)
            {
                movePlatforms("platformRight");
                moveItems("itemRight");
            }

            if (right == true && !leftColision)
            {
                movePlatforms("platformLeft");
                moveItems("itemLeft");
            }


            rect1.Y += gravity; //aplica continuamente gravidade no retangulo para verificar a colisao
            leftColision = false;
            rightColision = false;

            if (Controls.Cast<Control>()
                 .Where(c => (string)c.Tag == "platform" && c.Bounds.IntersectsWith(rect1))
                 .ToList().Count == 0) //se nao estiver em colisao com a plataforma volta a ter gavidade
                hasGravity = true;



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

                rect2 = control.Bounds;

                //platfrom collision
                if (control is PictureBox && (string)control.Tag == "platform")
                {


                    if (rect1.IntersectsWith(rect2))
                    {
                        Rectangle intersection = Rectangle.Intersect(rect1, rect2);

                        if (intersection.Width < intersection.Height) // colisao lateral
                        {

                            if (rect1.X < rect2.X) //esquerda
                            {
                                rect1.X -= intersection.Width;//para nao ir para dentro
                                leftColision = true;
                            }
                            else  //direita
                            {

                                rect1.X += intersection.Width;
                                player.Left += intersection.Width;
                                rightColision = true;
                            }
                        }

                        if (intersection.Width < intersection.Height) // colisao lateral
                        {

                            if (rect1.X < rect2.X) //esquerda
                            {
                                rect1.X -= intersection.Width;//para nao ir para dentro
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
                                hasGravity = false; //deixa de ter gravidade
                                rect1.Y -= intersection.Height;
                            }
                            else // por baixo da plataforma
                            {
                                isJumping = false;

                            }
                        }
                    }


                }


                //flower catch
                if (control is PictureBox && (string)control.Tag == "flower")
                {
                    if (rect1.IntersectsWith(rect2) && control.Visible == true)
                    {
                        control.Visible = false;
                        flowers += 1;
                    }
                }

                lb_flower.Text = flowers.ToString();

                if (control is PictureBox && (string)control.Tag == "home")
                {
                    if (rect1.IntersectsWith(rect2) && control.Visible == true)
                    {
                        //passagem no nr de flores para o prox nivel
                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "flower.txt");
                        using (StreamWriter writer = new StreamWriter(filePath))
                        {

                            string myVariable = lb_flower.Text;
                            writer.WriteLine(myVariable);
                            writer.Close();
                        }

                        GameLvl2 form = new GameLvl2();
                        form.Show();

                        this.Hide();
                    }
                }

            }

            if (rect1.Y > this.ClientSize.Height)
            {
                timer1.Stop();
                int resposta = Convert.ToInt32(MessageBox.Show("Queres iniciar de novo?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question));

                if (resposta == 6)
                {
                    MessageBox.Show("Restart");
                    restartGame();

                }
                else if (resposta == 7) //gravar os scores
                {
                    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "score.txt");
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {

                        string myVariable = lb_flower.Text;
                        writer.WriteLine(myVariable);
                        writer.Close();
                    }

                    Gravar form = new Gravar();
                    form.Show();

                    this.Hide();
                }





            }



        }

        

        private void keyDown(object sender, KeyEventArgs e)
        {
            //esquerda
            if (e.KeyCode == Keys.Left)
            {
                left = true;
                playerSpeed = 8;
            }

            //direita
            if (e.KeyCode == Keys.Right)

            {
                right = true;
                playerSpeed = 8;
            }

            //saltar
            if (e.KeyCode == Keys.Space && !isJumping)
            {
                isJumping = true;
                jumpDirection = "up";
            }
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


        private void movePlatforms(string direction)
        {

            foreach (Control control in this.Controls)
            {
                if (control is PictureBox && (string)control.Tag == "platform")
                {

                    if (direction == "platformRight")
                    {
                        control.Left += itemSpeed;
                    }
                    if (direction == "platformLeft")
                    {
                        control.Left -= itemSpeed;
                    }


                }
            }



        }

        private void moveItems(string direction)
        {

            foreach (Control control in this.Controls)
            {
                if (control is PictureBox && (string)control.Tag == "flower")
                {

                    if (direction == "itemRight")
                    {
                        control.Left += itemSpeed;
                    }
                    if (direction == "itemLeft")
                    {
                        control.Left -= itemSpeed;
                    }


                }

                if (control is PictureBox && (string)control.Tag == "home")
                {

                    if (direction == "itemRight")
                    {
                        control.Left += itemSpeed;
                    }
                    if (direction == "itemLeft")
                    {
                        control.Left -= itemSpeed;
                    }


                }
            }



        }

        private void restartGame()
        {

            //lives -= 1;

            //// Update the lives label with the new lives count
            //lb_lives.Text = $"Lives: {lives}";

            //if (lives == 0)
            //{

            //    MessageBox.Show("Game over! You ran out of lives.");
            //    Application.Exit();
            //}
            //else
            //{



            //    GameLv1 newForm = new GameLv1();
            //    newForm.Show();

            //    this.Hide();


            //}

            GameLv1 newForm = new GameLv1();
            newForm.Show();

            this.Hide();



        }
    }
}
