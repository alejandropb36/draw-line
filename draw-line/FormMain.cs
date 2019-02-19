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

        private void DDA(PictureBox workSpace, Point initial, Point final)
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


        private void bresenham(PictureBox workSpace, Point initial, Point final)
        {
            int dx = final.X - initial.X;
            int dy = final.Y - initial.Y;
            double m = (double)dy / (double)dx;
            int incremento = 1;
            int dy2, dx2, pk, xk, yk;
            

            dx = Math.Abs(dx);
            dy = Math.Abs(dy);

            dy2 = dy * 2;
            dx2 = dx * 2;
            pk = dy2 - dx;
            xk = initial.X;
            yk = initial.Y;

            

            if(m > 0)
            {
                for (int i = 0; i < dx; i+= incremento)
                {
                    bmp.SetPixel(xk, yk, Color.Orange);
                    while (pk >= 0)
                    {
                        yk++;
                        pk = pk - dx2;
                        bmp.SetPixel(xk, yk, Color.Orange);
                    }
                    xk++;
                    pk = pk + dy2;
                }
            }
            else
            {
                for (int i = 0; i < dx; i += incremento)
                {
                    bmp.SetPixel(xk, yk, Color.Orange);
                    while (pk >= 0)
                    {
                        yk--;
                        pk = pk - dx2;
                        bmp.SetPixel(xk, yk, Color.Orange);
                    }
                    xk++;
                    pk = pk + dy2;
                }
            }

            workSpace.Image = bmp;
        }

        /*
        private void bresenham(PictureBox workSpace, Point initial, Point final)
        {
            
            int dx, dx2;
            int dy, dy2;
            int xk, yk, pk;
            int stepx, stepy;

            dy = (final.Y - initial.Y);
            dx = (final.X - initial.X);

            if (dy < 0)
            {
                dy = -dy;
                stepy = -1;
            }
            else
            {
                stepy = 1;
            }

            if (dx < 0)
            {
                dx = -dx;
                stepx = -1;
            }
            else
            {
                stepx = 1;
            }

            xk = initial.X;
            yk = initial.Y;
            dy2 = dy * 2;
            dx2 = dx * 2;

            if (dx > dy)
            {
                pk = dy2 - dx;
                while (xk <= dx)
                {
                    xk += stepx;
                    if (pk <= 0)
                    {
                        pk += dy2;
                    }
                    else
                    {
                        yk += stepy;
                        pk += dy2 - dx;
                    }
                    bmp.SetPixel(xk, yk, Color.Orange);
                }
            }
            else
            {
                pk = dx2 - dy;
                while (yk <= dy)
                {
                    yk += stepy;
                    if (pk <= 0)
                    {
                        pk += dx2;
                    }
                    else
                    {
                        xk += stepx;
                        pk = dx2 - dy;
                    }
                    bmp.SetPixel(xk, yk, Color.Orange);
                }
            }
            workSpace.Image = bmp;

        }

        /*
        private void bresenham(PictureBox workSpace, Point initial, Point final)
        {
            double xi = (double)initial.X;
            double yi = (double)initial.Y;
            double xf = (double)final.X;
            double yf = (double)final.Y;
            double dx = xf - xi;
            double dy = yf - yi;
            double dx2 = dx * 2.0;
            double dy2 = dy * 2.0;
            double m = dy / dx;
            double b = yi - (m * xi);
            double c = -(dx2 * b) + dx - dy2;
            double x_k, y_k, p_k;
            int stepy = 1, stepx = 1; ;

            x_k = xi;
            y_k = yi;

            p_k = (2.0 * yi) * dx - (dy * 2.0) * xi + c;

            if(dx > dy)
            {
                if(yi > yf)
                {
                    stepy = -1;
                }
                if(xi > xf)
                {
                    stepx = -1;
                }

                while (x_k < xf)
                {
                    if (p_k >= 0)
                    {
                        p_k += -Math.Abs(dy2);
                        bmp.SetPixel((int)x_k, (int)y_k, Color.Orange);
                    }
                    else
                    {
                        y_k += stepy;
                        p_k += -Math.Abs(dy2) + Math.Abs(dx2);
                        bmp.SetPixel((int)x_k, (int)y_k, Color.Orange);
                    }
                    x_k += stepx;
                }
            }
            else
            {
                if (yi > yf)
                {
                    stepy = -1;
                }
                if (xi > xf)
                {
                    stepx = -1;
                }

                while (y_k < yf)
                {
                    if (p_k >= 0)
                    {
                        p_k += - Math.Abs(dy2);
                        bmp.SetPixel((int)x_k, (int)y_k, Color.Orange);
                    }
                    else
                    {
                        x_k += stepx;
                        p_k += - Math.Abs(dy2) + Math.Abs(dx2);
                        bmp.SetPixel((int)x_k, (int)y_k, Color.Orange);
                    }
                    y_k += stepy;
                }
            }
            workSpace.Image = bmp;
        }
        */

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

                DDA(workSpace, initial, final);
                bresenham(workSpace, initial, final);
                initial.X = initial.Y = -1;
                final.X = final.Y = -1;
            }
        }
        
        
    }
}
