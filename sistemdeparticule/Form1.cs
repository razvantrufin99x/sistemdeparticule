using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace sistemdeparticule
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Random r,l,f,s,cl,dx,dy;
        public List<particula> particule = new List<particula>();
        public List<Color> culori = new List<Color>();
        public int dirx, diry;
        public static int nr = 30;
        public int exitthis = 0;

        Graphics g;
        Pen pen0 = new Pen(Color.DarkGreen,2); 

        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();

            culori.Add(Color.Black);
            culori.Add(Color.White);
            culori.Add(Color.Red);
            culori.Add(Color.Blue);
            culori.Add(Color.Yellow);
            culori.Add(Color.Brown);
            culori.Add(Color.Violet);
            culori.Add(Color.Pink);
            culori.Add(Color.Green);
            culori.Add(Color.Gray);
            dirx = 1;
            diry = 1;
        }

        public void createSP()
        {
            r = new Random(100);
            l = new Random(Width);
            f = new Random(Height);
            s = new Random(2);
            dx = new Random(200);
            dy = new Random(200);
            cl = new Random(10);
         

            if (dx.Next(200) % 2 == 0) { dirx = 1; }
            else { dirx =  -1; }
            if (dy.Next(200) % 2 == 0) { diry = 1; }
            else { diry =  -1; }

            for (int i = 0; i < nr; i++)
            {
                particule.Add(new particula());
                particule[i].Left = dirx * (r.Next(10) + l.Next(Width));
                particule[i].Top = diry * (r.Next(10) + f.Next(Height));
                particule[i].BackColor = culori[cl.Next(10)];
                Controls.Add(particule[i]);
                particule[i].Show();
                particule[i].life--;
                particule[i].Height = (particule[i].Top / 200)+2;
                particule[i].Width = (particule[i].Left / 200) + 2;
                if (particule[i].life <= 0) 
                {
                    particule[i].BackColor = Color.Gold;
                }
                particule[i].startLeft = particule[i].Left;
                particule[i].startTop = particule[i].Top;
            }
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            createSP();

            
        }

       
        public void animateSP()
        {
            //g.Clear(Color.Black);
            for (int j = 0; j < 100; j++)
            {
                    r = new Random(10);
                    l = new Random(5);
                    f = new Random(5);
                    s = new Random(2);
                    cl = new Random(10);
                    dx = new Random(2);
                    dy = new Random(2);
g.Clear(Color.Black);
                    

                for (int i = 0; i < nr && exitthis !=1; i++)
                {
                    //g.Clear(Color.Black);
                    if (dx.Next(200) % 2 == 0) { dirx = 1; }
                    else { dirx = -1; }
                    if (dy.Next(200) % 2 == 0) { diry = 1; }
                    else { diry = -1; }

                    particule[i].Left += dirx * (r.Next(10) + l.Next(5));
                    particule[i].Top += diry * (r.Next(10) + f.Next(5));
                    if (particule[i].Left > Width) { particule[i].Left = 0; }
                    if (particule[i].Top > Height) { particule[i].Top = 0; }
                    particule[i].BackColor = culori[cl.Next(10)];
                    particule[i].life--;
                    particule[i].Height = (particule[i].Top / 100) + 2;
                    particule[i].Width = (particule[i].Left / 100) + 2;
                    if (particule[i].life <= 0)
                    {
                        particule[i].BackColor = Color.Gold;
                       
                    }
                    try
                    {

                       g.DrawLine(pen0, particule[i].Left, particule[i].Top, particule[i + 1].Left, particule[i + 1].Top);
                        g.DrawLine(pen0, particule[i].Left, particule[i].Top, particule[i].startLeft, particule[i].startTop);
                    }
                    catch { }
                }
                Thread.Sleep(20);
            }
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            animateSP();
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            exitthis = 1;
                Close();
            
        }
    }
}
