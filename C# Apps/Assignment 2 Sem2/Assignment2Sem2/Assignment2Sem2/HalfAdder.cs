using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Sem2
{
    class HalfAdder : AdderLogicComponent
    {
        bool sum = false;
        bool carry = false;
        List<bool> inputsList = new List<bool>();

        public HalfAdder(List<bool> inputs)
        {
            inputsList = inputs;
            XorGate xor = new XorGate(inputsList);
            sum = xor.GetOutput();
            AndGate and = new AndGate(inputsList);
            carry = and.GetOutput();
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
        public override bool GetCarryBit()
        {
            return carry;
        }

        public override string GetTypeAsString()
        {
            return "Half Adder";
        }
    }
}
