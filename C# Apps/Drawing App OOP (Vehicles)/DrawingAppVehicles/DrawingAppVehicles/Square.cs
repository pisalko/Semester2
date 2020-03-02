using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppVehicles
{
    public class Square : Figure
    {
        public override int Area => throw new NotImplementedException();

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
        }

        public override bool IsPointInside(int x, int y)
        {
            return base.IsPointInside(x, y);
        }
    }
}
