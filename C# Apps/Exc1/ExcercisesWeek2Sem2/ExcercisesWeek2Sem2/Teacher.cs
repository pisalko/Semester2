using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcercisesWeek2Sem2
{
    class Teacher : Person
    {
        public enum Position
        {
            juniorTeacher = 1,
            teacher1 = 2,
            teacher2 = 3,
            teacher3 = 4,
            coordinator = 5,
            director = 6
        }

        Position position;
        public Teacher(Position vale)
        {
            position = vale;
        }

        public void MakePromotion()
        {
            if(!(position == Position.director))
            position++;
        }
    }
}
