using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1Sem2
{
    class Gym : Package //child of package interface
    {
        public double GetPrice() //returns package Price
        {
            return 55;
        }

        public string Name //returns package Name
        {
            get
            {
                return "Gym";
            }
        }
        bool y = false;
        public bool IsBought //Plays a big role in MultiPackage and Member classes
        {

            set { y = value; }
            get { return y; }
        }
    }
}
