using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppVehicles
{
    public class Triangle : Figure
    {
        public override int Area
        {
            get { return (x2 - x1 * y2 - y1) / 2; }
        }

        public override void Draw(Graphics graphics)
        {
            //graphics.Draw
        }

        public override bool IsPointInside(int x, int y)
        {
            return base.IsPointInside(x, y);
        }
    }
}
