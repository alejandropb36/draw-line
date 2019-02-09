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

        private void buttonClear_Click(object sender, EventArgs e)
        {
            workSpace1.Refresh();
            workSpace2.Refresh();
            line.getInitialPoint().setX(-1);
            line.getInitialPoint().setY(-1);
            line.getFinalPoint().setX(-1);
            line.getFinalPoint().setY(-1);
        }

        private void workSpace1_MouseClick(object sender, MouseEventArgs e)
        {
            Point initialPoint;
            Point finalPoint;

            if (initialX == -1)
            {
                initialX = e.X;
                initialY = e.Y;
                initialPoint = new Point(initialX, initialY);
                line.setInitialPoint(initialPoint);
            }
            else
            {
                finalX = e.X;
                finalY = e.Y;
                finalPoint = new Point(finalX, finalY);
                line.setFinalPoint(finalPoint);
            }

            // DDA(workSpace1, line);
            // Bresenham(workSpace2, line);

            // Esto es para que se vuelva a cumplir el proceso de 
            // las coordenadas
            if(finalX != -1)
            {
                initialX = -1;
            }

            // Esto solo es de prueba
            Console.WriteLine("------------- Puntos ------------------");
            Console.WriteLine("punto inicial: (" + initialX + ", " + initialY + ")");
            Console.WriteLine("punto final: (" + finalX + ", " + finalY + ")");
        }

        private void DDA(Panel workSpace, Line line)
        {
            int incremento = 1;
            float m;



        }
    }
}
