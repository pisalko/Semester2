using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1Sem2
{
    class Gym : Package
    {
        public double GetPrice()
        {
            return 55;
        }

        public string Name
        {
            get
            {
                return "Gym";
            }
        }
    }
}
