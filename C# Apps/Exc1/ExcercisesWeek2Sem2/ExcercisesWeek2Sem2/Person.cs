using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcercisesWeek2Sem2
{
    class Person
    {
        protected int age = 0;
        protected int PCN = 0;
        protected int yearsAtSchool = 0;
        protected string name = "";

        public Person()
        {

        }

        public void CelebrateBirthday()
        {
            this.age += 1;
        }

        public string AsAString()
        {
            string stringResult = "Age: " + this.age.ToString() + "PCN: " + this.PCN.ToString() + "Years in school: " + this.yearsAtSchool + "Name: " + this.name;
            return stringResult;
        }

        public void StartAnotherSchoolyear()
        {
            yearsAtSchool++;
        }
    }
}
