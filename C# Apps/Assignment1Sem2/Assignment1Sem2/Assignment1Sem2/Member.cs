using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1Sem2
{
    public class Member
    {
        private string givenName,lastName, email = "";
        private string membershipID = "";
        private string dob = DateTime.Today.ToString("dd/MM/yyyy");
        bool hasPaid = false;
        public double owns = 0;
        public bool SwimmingPool = false;
        public bool Gym = false;
        public bool Dance = false;
        public bool Billiards = false;
        public Package package = new MultiPackage();
        MultiPackage packageWorking = new MultiPackage();

        public Member() //Constructor
        {
            
        }
        public void SetGivenName(string memberGivenName) //Sets the GIven name of the member
        {
            givenName = memberGivenName;
        }
        public string GetGivenName() //Gets the Given name of the member
        {
            return givenName; //"" by default
        }
        public void SetLastName(string memberGivenName) //Sets member's Last name
        {
            lastName = memberGivenName;
        }
        public string GetLastName() //Gets member's Last name
        {
            return lastName; //"" by default
        }
        public void SetMembershipID(string randomGenString)  //Sets member's Membership ID
        {
            membershipID = randomGenString;
        }
        public string GetMembershipID() //Gets member's Membership ID
        {
            return membershipID; //"" by default
        }
        public void SetEmail(string memberEmail) //Sets member's Email
        {
            email = memberEmail;
        }
        public string GetEmail() //Gets member's Email
        {
            return email; //"" by default
        }
        public void SetDOB(string memberDOB) //Sets member's Date of Birth
        {
            dob = memberDOB;
        }
        public string GetDOB() //Gets member's Date of Birth
        {
            return dob; // "dd/mm/yyyy" by default (today)
        }
        public bool HasPaid //Indicates whether or not the user has paid the packages he has requested
        {
            get { return hasPaid; } // false by default
            set { hasPaid = value; }
        }
       private int PackagesBought() //Returns the number of packages bough by the member
       {
            int packagesBought = 0;
            if (SwimmingPool)
                packagesBought++;
            if (Dance)
                packagesBought++;
            if (Gym)
                packagesBought++;
            if (Billiards)
                packagesBought++;

            return packagesBought;
       }
        public void PriceOwned()            //Indicates how much money the member owes. Mathemathics are done in the separate classes themselves.
        {            
            int packBought = PackagesBought();
            if (packBought == 0)
            {
                owns = 0;
            }
            else if (packBought == 1)
            {
                if (SwimmingPool)
                    package = new SwimmingPool();
                if (Dance)
                    package = new Dance();
                if (Gym)
                    package = new Gym();
                if (Billiards)
                    package = new Billiards();
            }
            else if (packBought > 1) //We add Packages to a MultiPackage object to indicate what and how many packages the member has bought.
            {
                package = new MultiPackage();
                packageWorking = package as MultiPackage;

                if (SwimmingPool)
                    packageWorking.AddPackage(new SwimmingPool());
                if (Dance)
                    packageWorking.AddPackage(new Dance());
                if (Gym)
                    packageWorking.AddPackage(new Gym());
                if (Billiards)
                    packageWorking.AddPackage(new Billiards());
            }

            if (packBought != 0)
            {
                switch (package.Name)
                {
                    case "Dance":
                        owns = package.GetPrice();
                        break;

                    case "Gym":
                        owns = package.GetPrice();
                        break;

                    case "SwimmingPool":
                        owns = package.GetPrice();
                        break;

                    case "Billiards":
                        owns = package.GetPrice();
                        break;

                    case "MultiPackage":
                        owns = packageWorking.GetPrice();
                        break;
                }
            }
            if (HasPaid) //This comes into play when "Has paid" button is pressed
                owns = 0;
        }
    }
}
