using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppVehicles
{
    public abstract class Figure
    {
        protected int x1, y1;
        protected int x2, y2;
        protected Pen color;

        public Figure()
        {
            x1 = 20;
            y1 = 20;
            x2 = 70;
            y2 = 70;
            color = Pens.Black;
        }

        virtual public void Draw(Graphics graphics)
        {
            
        }

        public virtual bool IsPointInside(int x, int y)
        {
            return false;
        }
        
        public virtual void MoveTo(int x, int y)
        {
            int w, h;
            h = y2 - y1;
            w = x2 - x1;
            x1 = x;
            x2 = x + w;
            y1 = y;
            y2 = y + h;

        }

        public abstract int Area { get; }
        

    }
}
