using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DrawingStarMethod
{
    public partial class Form1 : Form
    {
        List<Star> stars = new List<Star>();

        public Form1()
        {
            InitializeComponent();
            Pen blackPen = new Pen(Color.Black);
            Random randGen = new Random();

            for (int i =0; i < 50; i++)
            {
                int x = randGen.Next(1, this.Width);
                int y = randGen.Next(1, this.Width);
                int size = randGen.Next(10, 50);

                Star newStar = new Star(blackPen, x, y, size);
                stars.Add(newStar);
            }
        }

        private void starTimer_Tick(object sender, EventArgs e)
        {
            foreach(Star s in stars)
            {
                s.Move();
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Star s in stars)
            {
                e.Graphics.DrawPolygon(s.starPen, s.starPoints);
            }
        }
    }
}
