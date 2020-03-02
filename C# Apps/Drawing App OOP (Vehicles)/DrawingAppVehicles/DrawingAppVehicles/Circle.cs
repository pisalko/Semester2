using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppVehicles
{
    class Circle : Figure
    {
        public override int Area
        {
            get
            {
                int r = (x2 - x1 / 2);
                return (int)(Math.PI * r * r);
                
            }
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(color,x1,y1,x2-x1,y2-y1);
        }

        public override bool IsPointInside(int x, int y)
        {
            return (x > x1 && x < x2 && y > y1 && y < y2);
        }

    }
}
