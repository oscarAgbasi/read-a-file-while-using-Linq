/*
  Program: Sample.cs
  Author:  agbasi oscar
  Date:    december 7th, 2018
 
  Purpose: This program demonstrates some of the common capabilities of the Graphics object
           as well as how to properly use them.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5a
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private Pen P;
        private Pen P1;
        private SolidBrush b;
        int w;
        int h;
        private Color c;
        private Color c1 = Color.White;
        private int _X;
        private int _Y;
        private int rate; //value of the track bar


        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(button2_Paint);
            //_X = 355;
            //_Y = 15;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show the color dialog.
            colorDialog1.Color = c;                //Display with the previous colour already chosen
            DialogResult result = colorDialog1.ShowDialog(); 
            c = colorDialog1.Color;                //Save the colour choice the user made
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();// closing the appliaction
        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {
            int w = this.ClientSize.Width; // use to get the width of the working area
            int h = this.ClientSize.Height; // use to get the height of the working area
            g = e.Graphics; // Get the Graphics object from the PaintEventArgs
            P = new Pen(c);  //Create a new Pen using the current colour
            P1 = new Pen(c1);  //Create a new Pen using the current colour
            b = new SolidBrush(c);  //Create a new brush using the current colour


            //g = this.CreateGraphics();    //Create a graphics object
            //g.DrawRectangle(P1, 100, 220, 200, 150);


            g.DrawLine(P1, 90, 370, 270, 370);  //drawing the bucket when the form starts
            g.DrawLine(P1, 90, 370, 90, 270);
            g.DrawLine(P1, 270, 370, 270, 270);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //timer1.Start();
            //g = this.CreateGraphics();
            //g.FillRectangle(b, 118, 200, 15, 170);

           
        }

        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++; //increment the counter
            g = this.CreateGraphics();

            P.Color = c;
            g.DrawLine(P, 91, 370 - i, 269, 370 - i); //these lines fill up the bucket

            if (i == 100) //when the bucket fills up
            {
                timer1.Stop(); //stop the timer
                trackBar1.Value = 0; //stops the tap
                i = 0; //sets counter to 0
            }

            //g.FillRectangle(b, 100, _X, 200, _Y);//strating bucket fills
            //_X -= 15;
            //_Y += 2;

            ////g.FillRectangle(b, 100, 355, 200, 150) button liqud;  g.FillRectangle(b, 100, 320, 200, 20);
            ////g.FillRectangle(b, 100, 220, 200, 150);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            g = this.CreateGraphics();

            rate = trackBar1.Value; //

            if (rate > 0)
            {
                b = new SolidBrush(c);
                g.FillRectangle(b, 110, 180, 25, 190 - i);
                timer1.Interval = 250 / rate;
                timer1.Start();
            }
            if (rate == 0)
            {
                b.Color = Color.Black;
                g.FillRectangle(b, 110, 180, 25, 190 - i);
                timer1.Stop();
            }
        }
    }
    }

