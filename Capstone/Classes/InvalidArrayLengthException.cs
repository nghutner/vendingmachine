using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class InvalidArrayLengthException : Exception
    {
        public InvalidArrayLengthException() : base("Array is not length four.") {}
    }
}
