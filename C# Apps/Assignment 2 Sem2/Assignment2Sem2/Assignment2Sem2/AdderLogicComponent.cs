using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Sem2
{
    abstract class AdderLogicComponent : ILogicComponent
    {
        /// summary      Returns the state of an input pin.
        public abstract bool GetInput(int pin);
        /// summary      Returns the state of the sum pin
        public abstract bool GetOutput();
        /// summary      Returns the type of Gate as a string
        public abstract string GetTypeAsString();
        /// summary      Returns the carry bit (Used only for Adder components)
        public abstract bool GetCarryBit();
        /// summary      Returns all inputs in the format: pinNumber - state as a string
        public abstract string GetInputsAsString();
    }
}
