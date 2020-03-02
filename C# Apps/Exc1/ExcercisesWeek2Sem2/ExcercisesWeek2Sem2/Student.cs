using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcercisesWeek2Sem2
{
    class Student : Person
    {
        public string country = "";
        public int nrOfECs = 0;

        public Student()
        {

        }

        public void AddECs(int addedECs)
        {
            nrOfECs += addedECs;
        }
    }
}
