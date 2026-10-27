using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{

    using System;

    class Calculator
    {
        public double Div(double a, double b)
        {
            Console.WriteLine("    Div: start");
            if (b == 0)
                throw new DivideByZeroException("Nie można dzielić przez zero.");
            Console.WriteLine("    Div: koniec");
            return a / b;
        }
    }
}
