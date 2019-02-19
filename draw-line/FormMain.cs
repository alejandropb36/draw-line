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
