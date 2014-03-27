using System;
using System.Text;

namespace FizzBuzz
{ 
    public class FizzBuzzPrinter
    {
        //public string   PrintNumber(int i)
        public void PrintNumber(int i)
        {
            //StringBuilder returnValue = new StringBuilder();
            bool fizzAndOrBuzz = false; 

            if (i % 3 == 0)
            {
                //returnValue.Append("Fizz");
                Console.Write("Fizz");
                fizzAndOrBuzz = true;
            }

            if (i % 5 == 0)
            {
                //returnValue.Append("Buzz");
                Console.Write("Buzz");
                fizzAndOrBuzz = true;
            }

            if (!fizzAndOrBuzz)
            {
                Console.Write(i);
            }

            Console.WriteLine();
            //return string.IsNullOrEmpty(returnValue.ToString()) ? i.ToString() : returnValue.ToString() ;
        }
    }
}