using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace draw_line
{
    class Line
    {
        private Point initialPoint;
        private Point finalPoint;


        public void setInitialPoint(Point point)
        {
            this.initialPoint = point;
        }

        public void setFinalPoint(Point point)
        {
            this.finalPoint = point;
        }

        public Point getInitialPoint()
        {
            return this.initialPoint;
        }

        public Point getFinalPoint()
        {
            return this.finalPoint;
        }

    }
}
