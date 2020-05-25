using System.Collections.Generic;

namespace Assignment2Sem2
{
    class XorGate : ILogicComponent
    {
        List<bool> inputsList = new List<bool>();
        bool state = false;

        public XorGate(List<bool> inputs)
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
            int counter = 0;
            foreach (bool b in inputsList) if (b) counter++;
            if (counter % 2 == 0) state = false;
            else state = true;
            return state;
        }

        public string GetTypeAsString()
        {
            return "XOR Gate";
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
