using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1Sem2
{
    public class Member
    {
        private string namee = "";
        private int agee = 0;
        private string packagee = "";
        public Member(string name, int age, string package)
        {
            namee = name;
            agee = age;
            packagee = package;
        }
        public string getName()
        {
            return namee;
        }
        public int getAge()
        {
            return agee;
        }
        public string getPackageAccess()
        {
            return packagee;
        }
    }
}
