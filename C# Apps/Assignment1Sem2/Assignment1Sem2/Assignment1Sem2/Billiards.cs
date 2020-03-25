using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1Sem2
{
    class Billiards : Package //child of Package interface
    {
        public double GetPrice() //returns Price of package
        {
            return 38;
        }

        public string Name //returns name of package
        {
            get
            {
                return "Billiards";
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
