using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace draw_line
{
    public partial class FormMain : Form
    {
        Point initial, final;
        Bitmap bmp;

        public FormMain()
        {
            initial = new Point(-1, -1);
            final = new Point(-1, -1);
            bmp = new Bitmap(500, 500);
            InitializeComponent();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            initial.X = initial.Y = -1;
            final.X = final.Y = -1;

            bmp = new Bitmap(500, 500);
            workSpace.Image = bmp;
        }

        private void DDA(Point initial, Point final)
        {
            double xi, yi;
            double xf, yf;
            double deltaX, deltaY;
            double m, b;
            int incremento;
            int xact, yact;
            
            incremento = 1;

            xi = (double)initial.X;
            yi = (double)initial.Y;
            xf = (double)final.X;
            yf = (double)final.Y;

            deltaX = xf - xi;
            deltaY = yf - yi;

            if (Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                m = deltaY / deltaX;
                b = yi - (m * xi);
                if (deltaX < 0)
                {
                    incremento = -1;
                }
                else
                {
                    incremento = 1;
                }

                for (int i = (int)xi; i != xf; i += incremento)
                {
                    yact = (int)(Math.Round((m * i) + b));
                    bmp.SetPixel(i, yact, Color.Blue);
                }
            }
            else
            {
                if (deltaY != 0)
                {
                    m = deltaX / deltaY;
                    b = xi - (m * yi);

                    if (deltaY < 0)
                    {
                        incremento = -1;
                    }
                    else
                    {
                        incremento = 1;
                    }

                    for (int i = (int)yi; i != yf; i += incremento)
                    {
                        xact = (int)(Math.Round((m * i) + b));
                        bmp.SetPixel(xact, i, Color.Blue);
                    }
                }
            }

            workSpace.Image = bmp;
        }
        
        private void swap(ref int a,ref int b)
        {
            int aux = a;
            a = b;
            b = aux;
        }

        private void bresenham(Point initial, Point final)
        {
            int dx = Math.Abs(final.X - initial.X);
            int dy = Math.Abs(final.Y - initial.Y);

            if(dx >= dy)
            {
                //bresenhamX
            }
            else
            {
                //bresenhamY
            }

        }

        private void workSpace_MouseClick(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(Color.Orange, 3);

            if (initial.X == -1)
            {
                initial.X = e.X;
                initial.Y = e.Y;
                workSpace.CreateGraphics().DrawEllipse(pen, initial.X, initial.Y, 3, 3);
            }
            else
            {
                final.X = e.X;
                final.Y = e.Y;
                workSpace.CreateGraphics().DrawEllipse(pen, final.X, final.Y, 3, 3);

                Console.WriteLine("------------- Puntos ------------------");
                Console.WriteLine("punto inicial: (" + initial.X + ", " + initial.Y + ")");
                Console.WriteLine("punto final: (" + final.X + ", " + final.Y + ")");

                DDA(initial, final);
                bresenham(initial, final);
                initial.X = initial.Y = -1;
                final.X = final.Y = -1;
            }
        }
        
        
    }
}
