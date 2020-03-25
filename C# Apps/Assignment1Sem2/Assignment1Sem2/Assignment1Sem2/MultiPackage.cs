using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1Sem2
{
    public class MultiPackage : Package //Child of the Package Interface <IPackage>
    {
        List<Package> packagesList = new List<Package>();
        private double price = 0;

        public double GetPrice() //returns price
        {
            CalcPrice();
            return price;
        }

        public string Name //property name
        {
            get
            {
                return "MultiPackage";
            }
        }

        public void AddPackage(Package addedPackage)
        {
            addedPackage.IsBought = true;
            packagesList.Add(addedPackage);
        }

        private void CalcPrice() //Method for calculating the price for MultiPackage (+ discounts), storing it in variable price.
        {
            int sequence = 0;
            foreach(Package p in packagesList)
            {
                if (p.IsBought)
                {
                    sequence++;
                    switch (p.Name)
                    {
                        case "SwimmingPool":
                            double pricePack = p.GetPrice();
                            if (sequence == 2)
                               pricePack = (pricePack * 0.7);
                            if (sequence == 3)
                                pricePack = (pricePack * 0.5);
                            if (sequence >= 4)
                                pricePack = (pricePack * 0.35);
                            price += pricePack;
                            break;

                        case "Dance":
                            pricePack = p.GetPrice();
                            if (sequence == 2)
                                pricePack = (pricePack * 0.7);
                            if (sequence == 3)
                                pricePack = (pricePack * 0.5);
                            if (sequence >= 4)
                                pricePack = (pricePack * 0.35);
                            price += pricePack;
                            break;

                        case "Gym":
                            pricePack = p.GetPrice();
                            if (sequence == 2)
                                pricePack = (pricePack * 0.7);
                            if (sequence == 3)
                                pricePack = (pricePack * 0.5);
                            if (sequence >= 4)
                                pricePack = (pricePack * 0.35);
                            price += pricePack;
                            break;

                        case "Billiards":
                            pricePack = p.GetPrice();
                            if (sequence == 2)
                                pricePack = (pricePack * 0.7);
                            if (sequence == 3)
                                pricePack = (pricePack * 0.5);
                            if (sequence >= 4)
                                pricePack = (pricePack * 0.35);
                            price += pricePack;
                            break;
                    }
                }
            }
        }

        public bool IsBought //obsolete, not used in MultiPackage but has to be present due to being an Interface child
        { set; get; } = false;
    }
}