﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1Sem2
{
    class MultiPackage : Package
    {
        public double GetPrice()
        {
            return 27;
        }

        public string Name
        {
            get
            {
                return "MultiPackage";
            }
        }
    }
}