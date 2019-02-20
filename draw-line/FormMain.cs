using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Add for use Timer
using System.Diagnostics;


namespace draw_line
{
    public partial class FormMain : Form
    {
        Point initial, final;
        Bitmap bmp;
        Stopwatch sw;

        public FormMain()
        {
            initial = new Point(-1, -1);
            final = new Point(-1, -1);
            bmp = new Bitmap(500, 500);
            sw = new Stopwatch();
            InitializeComponent();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            initial.X = initial.Y = -1;
            final.X = final.Y = -1;

            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(Brushes.White, 0, 0, 500, 500);
            workSpace.Image = bmp;

            labelAdd.Text = "ADD: 0 s";
            labelBresenham.Text = "Bresenham: 0 s";
        }

        /*
         * Algoritmo de trasado de lineas con DDA
         */
        private void DDA(Point initial, Point final)
        {
            double xi, yi;
            double xf, yf;
            double deltaX, deltaY;
            double m, b;
            int incremento;
            int xact, yact;

            sw.Restart();
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
            labelAdd.Text = "ADD: " + String.Format("{0}", sw.Elapsed.TotalMilliseconds) + " s";
        }
        
        private void swap(ref int a,ref int b)
        {
            int aux = a;
            a = b;
            b = aux;
        }

        /*
         * Algoritmo de trasado de lineas con Bresenham o MidPoint
         */
        private void bresenham(Point initial, Point final)
        { 
            int xi = initial.X;
            int yi = initial.Y;
            int xf = final.X;
            int yf = final.Y;
            int deltaX = Math.Abs(xf - xi);
            int deltaY = Math.Abs(yf - yi);
            int deltaX2 = 0;
            int deltaY2 = 0;
            int pk = 0;

            sw.Restart();
            deltaY2 = deltaY * 2;
            deltaX2 = deltaX * 2;

            if (deltaX >= deltaY)
            {
                /*
                 * Bresenham iteraciones en x
                 * P_k += 2DeltaY - DeltaX;
                 * P_k+1 += 2DeltaY;
                 * ó P_k+1 = 2DeltaY - 2DeltaX;
                 */
                pk = deltaY2 - deltaX;

                if(xi > xf)
                {
                    swap(ref xi, ref xf);
                    swap(ref yi, ref yf);
                }

                bmp.SetPixel(xi, yi, Color.Orange);

                while( xi < xf)
                {
                    if(pk < 0)
                    {
                        pk += deltaY2;
                    }
                    else
                    {
                        if(yi < yf)
                        {
                            yi = yi + 1;
                        }
                        else
                        {
                            yi = yi - 1;
                        }
                        pk += deltaY2 - deltaX2;
                    }
                    xi = xi + 1;
                    bmp.SetPixel(xi, yi, Color.Orange);
                }
            }
            else
            {
                /*
                 * Bresenham iteraciones en y
                 * P_k += 2DeltaX - DeltaY;
                 * P_k+1 += 2DeltaX;
                 * ó P_k+1 = 2DeltaX - 2DeltaY;
                 */
                pk = deltaX2 - deltaY;

                if (yi > yf)
                {
                    swap(ref xi, ref xf);
                    swap(ref yi, ref yf);
                }

                bmp.SetPixel(xi, yi, Color.Orange);

                while (yi < yf)
                {
                    if (pk < 0)
                    {
                        pk += deltaX2;
                    }
                    else
                    {
                        if (xi < xf)
                        {
                            xi = xi + 1;
                        }
                        else
                        {
                            xi = xi - 1;
                        }
                        pk += deltaX2 - deltaY2;
                    }
                    yi = yi + 1;
                    bmp.SetPixel(xi, yi, Color.Orange);
                }
            }
            workSpace.Image = bmp;
            labelBresenham.Text = "Bresenham: " + String.Format("{0}", sw.Elapsed.TotalMilliseconds) + " s";
        }

        /*
         * Captura de Puntos en el area de trabajo
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

                DDA(initial, final);
                bresenham(initial, final);
                initial.X = initial.Y = -1;
                final.X = final.Y = -1;
            }
        }
        
        
    }
}
