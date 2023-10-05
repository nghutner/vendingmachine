using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException() : base("Invalid input. Type 1, 2, or 3") { }
    }
}
