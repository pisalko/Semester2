using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Sem2
{
    
    class NotGate : ILogicComponent
    {
        bool state = false;

        public NotGate(bool value)
        {
            state = !value;
        }

        public bool GetInput(int pin)
        {
            return !state;
        }

        public bool GetOutput()
        {
            return state;
        }

        public string GetTypeAsString()
        {
            return "NOT Gate";
        }

        public string GetInputsAsString()
        {

            return (!state).ToString().ToLower();
        }
    }
}
