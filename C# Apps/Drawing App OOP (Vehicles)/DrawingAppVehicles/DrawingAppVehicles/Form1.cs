using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingAppVehicles
{
    public partial class Form1 : Form
    {
        List<Figure> figureList = new List<Figure>();
        private bool isDragging = false;
        private Figure moveFigure;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            Circle circle = new Circle();
            figureList.Add(circle);
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!(figureList == null))
            {
                foreach (Figure figure in figureList)
                {
                    figure.Draw(e.Graphics);
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach(Figure figure in figureList)
            {
                if(figure.IsPointInside(e.X, e.Y))
                {
                    isDragging = true;
                    moveFigure = figure;
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(isDragging)
            {
                moveFigure.MoveTo(e.X, e.Y);
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            moveFigure = null;
            pictureBox1.Refresh();
        }
    }
}
