using Kalkulator;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Kalkulator
{
    public class Calculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
        public double Sub(double a, double b)
        {
            return a - b;
        }
        public double Mul(double a, double b)
        {
            return a * b;
        }
        public double Div(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Nie można dzielić przez zero.");
            return a / b;
        }
    }


}
