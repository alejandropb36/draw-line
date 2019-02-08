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
        public FormMain()
        {
            line = new Line();
            InitializeComponent();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            workSpace1.Refresh();
            workSpace2.Refresh();
        }

        private void workSpace1_MouseClick(object sender, MouseEventArgs e)
        {
            Point initialPoint = new Point();
            Point finalPoint = new Point(); ;

            if (line.getInitialPoint().getX() == -1)
            {
                initialPoint.setX(e.X);
                initialPoint.setY(e.Y);
            }
            else
            {
                finalPoint.setX(e.X);
                initialPoint.setY(e.Y);
            }

            
        }
    }
}
