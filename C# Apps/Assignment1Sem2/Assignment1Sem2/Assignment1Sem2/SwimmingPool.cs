using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1Sem2
{
    class SwimmingPool : Package //Child of Package Interface
    {
        
        public double GetPrice()// returns package price
        {
            return 69;
        }

        public string Name //returns package name
        {
            get
            {
                return "SwimmingPool";
            }
        }
        bool y = false;
        public bool IsBought //plays a role in MultiPackage & Member classes
        {
            
            set { y = value; }
            get { return y; }
        }
    }
}
