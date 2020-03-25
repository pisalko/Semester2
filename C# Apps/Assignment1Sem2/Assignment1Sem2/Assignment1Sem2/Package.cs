using System;

namespace Assignment1Sem2
{
    public interface Package //Public interface, so we can create instances of it in Member and Forms as well
    {
        double GetPrice();
        string Name { get; }
        bool IsBought { get; set; }
    }
}