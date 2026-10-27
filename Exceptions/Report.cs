using Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{

    class Report
    {
        private Calculator calc = new Calculator();

        public double Average(double sum, int count)
        {
            Console.WriteLine("  Average: start");

            if (count <= 0)
                throw new ArgumentException("Liczba elementów musi być dodatnia.");

            try 
            {
                double result = calc.Div(sum, count);
                Console.WriteLine("  Average: koniec");
                return result;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Average: złapano: " + ex.Message);
                return 0;
            }


        }
    }
}

