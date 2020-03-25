using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1Sem2
{
    public class Dance : Package //Child of Package interface
    {
        public double GetPrice() // returns price of package
        {            
            return 27;
        }

        public string Name //returns Name of package
        {
            get
            {
                return "Dance";
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
