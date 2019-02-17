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
        Line line;
        int initialX;
        int initialY;
        int finalX;
        int finalY;

        public FormMain()
        {
            line = new Line();
            InitializeComponent();

            initialX = initialY = -1;
            finalX = finalY = -1;
        }

        private void drawGrid(Panel panel)
        {
            int x, y, height, width, linesWidth, linesHeight;
            Pen pen = new Pen(Color.LightGray, 1);
            const int sizeSquare = 20;

            height = panel.Height;
            width = panel.Width;
            linesWidth = width / sizeSquare;
            linesHeight = height / sizeSquare;

            y = 0;
            for (int i = 0; i < linesWidth; i++)
            {
                x = sizeSquare * i;
                panel.CreateGraphics().DrawLine(pen, x, y, x, height);
            }

            x = 0;
            for (int i = 0; i < linesHeight; i++)
            {
                y = sizeSquare * i;
                panel.CreateGraphics().DrawLine(pen, x, y, width, y);
            }
        }

        private void workSpace1_Paint(object sender, PaintEventArgs e)
        {
            drawGrid(workSpace1);
        }

        /*
        private void workSpace2_Paint(object sender, PaintEventArgs e)
        {
        }
        */

        private void buttonClear_Click(object sender, EventArgs e)
        {
            workSpace1.Refresh();
            initialX = initialY = -1;
            finalX = finalY = -1;
            line.getInitialPoint().setX(initialX);
            line.getInitialPoint().setY(initialY);
            line.getFinalPoint().setX(finalX);
            line.getFinalPoint().setY(finalY);
        }

        private void workSpace1_MouseClick(object sender, MouseEventArgs e)
        {
            Point initialPoint;
            Point finalPoint;
            Pen pen = new Pen(Color.Orange, 3);

            if (initialX == -1)
            {
                initialX = e.X;
                initialY = e.Y;
                initialPoint = new Point(initialX, initialY);
                line.setInitialPoint(initialPoint);
                workSpace1.CreateGraphics().DrawEllipse(pen, initialX, initialY, 3, 3);
            }
            else
            {
                finalX = e.X;
                finalY = e.Y;
                finalPoint = new Point(finalX, finalY);
                line.setFinalPoint(finalPoint);
                workSpace1.CreateGraphics().DrawEllipse(pen, finalX, finalY, 3, 3);

                Console.WriteLine("------------- Puntos ------------------");
                Console.WriteLine("punto inicial: (" + initialX + ", " + initialY + ")");
                Console.WriteLine("punto final: (" + finalX + ", " + finalY + ")");

                DDA(workSpace1, line);
                bresenham(workSpace1, line);
                initialX = initialY = -1;
                finalX = finalY = -1;
            }
            
        }

        private void DDA(Panel workSpace, Line line)
        {
            double xi, yi;
            double xf, yf;
            double deltaX, deltaY;
            double m, b;
            int incremento;
            int xact, yact;
            Pen pen;

            pen = new Pen(Color.Red, 1);

            incremento = 1;

            xi = (double)(line.getInitialPoint().getX());
            yi = (double)(line.getInitialPoint().getY());
            xf = (double)(line.getFinalPoint().getX());
            yf = (double)(line.getFinalPoint().getY());

            deltaX = xf - xi;
            deltaY = yf - yi;

            if(Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                m = deltaY / deltaX;
                b = yi - (m * xi);
                if(deltaX < 0)
                {
                    incremento = -1;
                }
                else
                {
                    incremento = 1;
                }

                for(int i = (int)xi; i != xf; i += incremento)
                {
                    yact = (int)(Math.Round((m * i) + b));
                    workSpace.CreateGraphics().DrawEllipse(pen, i, yact, 1, 1);
                }
            }
            else
            {
                if(deltaY != 0)
                {
                    m = deltaX / deltaY;
                    b = xi - (m * yi);

                    if(deltaY < 0)
                    {
                        incremento = -1;
                    }
                    else
                    {
                        incremento = 1;
                    }

                    for(int i = (int)yi; i != yf; i += incremento)
                    {
                        xact = (int)(Math.Round((m * i) + b));
                        workSpace.CreateGraphics().DrawEllipse(pen, xact, i, 1, 1);
                    }
                }
            }
        }

        private void bresenham(Panel workSpace, Line line)
        {
            Pen pen = new Pen(Color.Green, 1);
            double xi = (double)line.getInitialPoint().getX();
            double yi = (double)line.getInitialPoint().getY();
            double xf = (double)line.getFinalPoint().getX();
            double yf = (double)line.getFinalPoint().getY();
            double dx, dx2;
            double dy, dy2;
            double x_k, y_k, p_k;
            int stepx, stepy;

            dy = (yf - yi);
            dx = (xf - xi);

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
            
            x_k = xi;
            y_k = yi;
            dy2 = (dy * 2.0);
            dx2 = (dx * 2.0);
            
            if(dx > dy)
            {
                p_k = dy2 - dx;
                while(x_k != xf)
                {
                    x_k += stepx;
                    if(p_k <= 0)
                    {
                        p_k += dy2;
                    }
                    else
                    {
                        y_k += stepy;
                        p_k += dy2 - dx2;
                    }
                    workSpace.CreateGraphics().DrawEllipse(pen, (int)x_k, (int)y_k, 1, 1);
                }
            }
            else
            {
                p_k = dx2 - dy;
                while (y_k != yf)
                {
                    y_k += stepy;
                    if (p_k <= 0)
                    {
                        p_k += dx2;
                    }
                    else
                    {
                        x_k += stepx;
                        p_k = dx2 - dy2;
                    }
                    workSpace.CreateGraphics().DrawEllipse(pen, (int)x_k, (int)y_k, 1, 1);
                }
            }

        }

        
    }
}
