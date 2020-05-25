using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Sem2
{
    class OrGate : ILogicComponent
    {
        List<bool> inputsList= new List<bool>();
        bool state = false;

        public OrGate(List<bool> inputs)
        {
            inputsList = inputs;
        }
   
        public bool GetInput(int pin)
        {
            if (pin >= inputsList.Count)
                throw new InvalidPinException();
            else
                return inputsList[pin];
        }

        public bool GetOutput()
        {
            state = false;
            foreach (bool b in inputsList)
            {
                if (b)
                {
                    state = true;
                    break;
                }
            }
            return state;
        }

        public string GetTypeAsString()
        {
            return "OR Gate";
        }

        public string GetInputsAsString()
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
    }
}
