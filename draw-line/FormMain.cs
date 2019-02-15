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

            xi = Convert.ToDouble(line.getInitialPoint().getX());
            yi = Convert.ToDouble(line.getInitialPoint().getY());
            xf = Convert.ToDouble(line.getFinalPoint().getX());
            yf = Convert.ToDouble(line.getFinalPoint().getY());

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

                for(int i = Convert.ToInt32(xi); i != xf; i += incremento)
                {
                    yact = Convert.ToInt32(Math.Round((m * i) + b));
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

                    for(int i = Convert.ToInt32(yi); i != yf; i += incremento)
                    {
                        xact = Convert.ToInt32(Math.Round((m * i) + b));
                        workSpace.CreateGraphics().DrawEllipse(pen, xact, i, 1, 1);
                    }
                }
            }
        }

        private void bresenham(Panel workSpace, Line line)
        {
            int xi, yi;
            int xf, yf;
            int deltaX, deltaY;
            int p;
            int x, y, xf2;
            Pen pen;

            pen = new Pen(Color.Green, 1);

            xi = line.getInitialPoint().getX();
            yi = line.getInitialPoint().getY();
            xf = line.getFinalPoint().getX();
            yf = line.getFinalPoint().getX();

            deltaX = Math.Abs(xf - xi);
            deltaY = Math.Abs(yf - yi);

            p = (2 * deltaY) - deltaX;

            if(xi > xf)
            {
                x = xf;
                y = yf;
                xf2 = xi;
            }
            else
            {
                x = xi;
                y = yi;
                xf2 = xf;
            }

            workSpace.CreateGraphics().DrawEllipse(pen, x, y, 1, 1);

            while(x < xf2)
            {
                x++;
                if(p < 0)
                {
                    workSpace.CreateGraphics().DrawEllipse(pen, x, y, 1, 1);
                    p = p + (2 * deltaY);
                }
                else
                {
                    y++;
                    workSpace.CreateGraphics().DrawEllipse(pen, x, y, 1, 1);
                    p = p + (2 * deltaY) - (2 * deltaX);
                }
            }

        }

        
    }
}
