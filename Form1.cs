using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Graphics g;                         //Encapsulates a GDI+ drawing surface
        private Pen p;                              //Pens are used to draw objects
        private Font f;                             //Defines a particular format for text, including font face, size, and style attributes
        private SolidBrush b;                       //Brushes are used to fill graphics shapes
        private Color c = Color.White;              //Represents a color, initially set to black

        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint);  //Registers the Paint event handler
            pictureBox1.Image = imageList1.Images[0];

            pictureBox1.Refresh();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;                          //Get the Graphics object from the PaintEventArgs
            p = new Pen(c);                          //Create a new Pen using the current colour
            f = new Font("Arial", 20);               //Create a new Font
            b = new SolidBrush(c);               //Create a new brush using the current colour

            /* Write a title to the form */
            g.DrawString("Graphics Sampler", f, b, 100, 50);
            g.DrawLine(p, 100, 300, 100, 400);        //Draw two intersecting lines using the current Pen
            g.DrawLine(p, 250, 300, 250, 400);
            g.DrawLine(p, 100, 400, 250, 400);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            c = colorDialog1.Color;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            Color cc = Color.Black;
            g = this.CreateGraphics();               //Create a graphics object

            b = new SolidBrush(cc);
            g.FillRectangle(b, 124, 150, 20, 250);   //Draw a rectangle using the current pen
            for (int i = 390; i >= 300; i = i - 5)
            {
                g.FillRectangle(b, 100, i, 150, 9);   //Draw a rectangle using the current pen

            }

            b = new SolidBrush(c);
            g.FillRectangle(b, 124, 150, 20, 250);   //Draw a rectangle using the current pen
            for (int i = 390; i >= 300; i = i - 5)
            {
                g.FillRectangle(b, 100, i, 150, 10);   //Draw a rectangle using the current pen

                Thread.Sleep(500);
            }
           
        }

     
    }
}
