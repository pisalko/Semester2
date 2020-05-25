using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Sem2
{
    class FullAdder : AdderLogicComponent
    {
        List<bool> inputsList = new List<bool>();
        bool sum = false;
        bool carry = false;

        public FullAdder(List<bool> inputs)
        {
            inputsList = inputs;
            HalfAdder hfone = new HalfAdder(inputsList.Take(2).ToList());
            List<bool> temp = new List<bool>();
            temp.Add(inputsList[inputsList.Count - 1]);
            temp.Add(hfone.GetOutput());
            HalfAdder hftwo = new HalfAdder(temp);
            temp = new List<bool>();
            temp.Add(hftwo.GetCarryBit());
            temp.Add(hfone.GetCarryBit());
            OrGate or = new OrGate(temp);
            sum = hftwo.GetOutput();
            carry = or.GetOutput();
        }

        public override bool GetCarryBit()
        {
            return carry;
        }

        public override bool GetInput(int pin)
        {
            if (pin >= inputsList.Count)
                throw new InvalidPinException();
            else
                return inputsList[pin];
        }

        public override string GetInputsAsString()
        {
            string inputsAll = "";
            for (int i = 0; i < inputsList.Count; i++)
            {
                if (inputsList[i])
                {
                    inputsAll += "pin" + i.ToString() + " - true, ";
                }
                else
                {
                    inputsAll += "pin" + i.ToString() + " - false, ";
                }
            }
            return inputsAll;
        }

        public override bool GetOutput()
        {
            return sum;
        }

        public override string GetTypeAsString()
        {
            return "Full Adder";
        }
    }
}
