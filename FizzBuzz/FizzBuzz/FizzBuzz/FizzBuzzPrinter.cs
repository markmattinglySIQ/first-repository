using System;
using System.Text;

namespace FizzBuzz
{ 
    public class FizzBuzzPrinter
    {
        public string PrintNumber(int i)
        {
            StringBuilder returnValue = new StringBuilder();

            if (i % 3 == 0)
            {
                returnValue.Append("Fizz");
            }

            if (i % 5 == 0)
            {
                returnValue.Append("Buzz");
            }

            return string.IsNullOrEmpty(returnValue.ToString()) ? i.ToString() : returnValue.ToString() ;
        }
    }
}