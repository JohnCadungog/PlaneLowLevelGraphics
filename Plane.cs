using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LowLevelGraphicsGame
{
    public partial class Plane : Form
    {
        //Picturebox Plane;
        bool goLeft, goRight, goDown, goUp;
        int speed = 1;
        int positionX = 54;
        int positionY = 180;
      
        private List<string> frames = new List<string>(new String[] { "1", "2", "3", "4", "5", "6", "7", "8" });
        int currFrame = 0;
        private List<Particle> particles = new List<Particle>();
        




        public Plane()
        {
            InitializeComponent();
          
            positionX = pictureBox2.Left;
            positionY = pictureBox2.Top;
         
            timer1.Start();
          
            pictureBox4.Paint += pictureBoxParticles_Paint;


        }

       

       

        private void timer2_Tick(object sender, EventArgs e)
        {
            //infinite loop for bacground image
            if(pictureBox3.Left <= 0 && pictureBox3.Left >= -858)
            {
                pictureBox3.Left -= 1;
            }
            else
            {
                pictureBox3.Left = 0;
            }
        }

        private void wind_Tick(object sender, EventArgs e)
        {
      
            Random random = new Random();
            int lineLength = random.Next(1, 12); 
            float lineWidth = 1; 
            int particleVelocity =random.Next(-1000, -200); 
            int maxParticles = 75;
            int minLifetime = 500; 
            int maxLifetime = 4000; 

            if (particles.Count < maxParticles)
            {
                int randomY = random.Next(0, pictureBox4.Height); 
                int randomX = random.Next(20, pictureBox4.Width + 500); 
                int randomLifetime = random.Next(minLifetime, maxLifetime);

                Point startPoint = new Point(randomX, randomY);
                Point endPoint = new Point(startPoint.X + lineLength, startPoint.Y);
                Pen linePen = new Pen(Color.Black, lineWidth);
                Particle particle = new Particle(startPoint, endPoint, linePen, randomLifetime);
                particles.Add(particle);
            }

           
            particles.RemoveAll(particle => particle.StartPoint.X < 0 || particle.IsExpired());

            foreach (var particle in particles)
            {
                particle.Update();
            }

            
            pictureBox4.Invalidate();
        }



        private void pictureBoxParticles_Paint(object sender, PaintEventArgs e)
        {
            foreach (var particle in particles)
            {
                e.Graphics.DrawLine(particle.LinePen, particle.StartPoint, particle.EndPoint);
            }
        }

       

        private void TimerEvent(object sender, EventArgs e)
        {
            if(goLeft == true && pictureBox2.Left > -70)
            {
                pictureBox2.Left -= speed;

            }
            if(goRight == true && pictureBox2.Left < 250)
            {
                pictureBox2.Left += speed;
            }
            if(goUp == true && pictureBox2.Top > 0)
            {
                pictureBox2.Top -= speed;
            }
            if(goDown == true && pictureBox2.Top < 200)
            {
                pictureBox2.Top += speed;
            }

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;

            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
        }


     
    }
}
