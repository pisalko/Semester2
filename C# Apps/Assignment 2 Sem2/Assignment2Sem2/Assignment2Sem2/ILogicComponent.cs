using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Sem2
{
    public interface ILogicComponent
    {
        /// summary      Returns the state of an input pin.
        bool GetInput(int pin);
        /// summary      Returns the state of the output in.
        bool GetOutput();
        /// summary      Returns the type of Gate as a string
        string GetTypeAsString();
        /// summary      Returns all inputs in the format: pinNumber - state as a string
        string GetInputsAsString();
    }
}
