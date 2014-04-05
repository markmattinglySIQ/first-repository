using System;
using System.Collections.Generic;
using System.Diagnostics;
using FizzBuzz;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> returnedArray = new List<string>();

            Execute(5, 100, returnedArray);
            Execute(5, 500, returnedArray);
            Execute(5, 1000, returnedArray);

            Execute(10, 100, returnedArray);
            Execute(10, 500, returnedArray);
            Execute(10, 1000, returnedArray);

            Execute(20, 100, returnedArray);
            Execute(20, 500, returnedArray);
            Execute(20, 1000, returnedArray);

            foreach (string result in returnedArray)
            {
                Console.WriteLine(result);
            }

            Console.Write("Hit Enter key to finish...");
            Console.Read();

        }

        private static void Execute(int numberOfTimesToExecute, int ceiling, IList<string> returnedArray)
        {
            int[] performanceTimesForFirstMethod = new int[numberOfTimesToExecute];
            int[] performanceTimesForSecondMethod = new int[numberOfTimesToExecute];

            Stopwatch stopwatch = new Stopwatch();

            FizzBuzzPrinter fizzBuzzPrinter = new FizzBuzzPrinter();

            // call to prime the JIT
            for (int i = 1; i <= 10; i++)
            {
                fizzBuzzPrinter.PrintNumber(3);
            }

            for (int index = 0; index < performanceTimesForFirstMethod.Length; index++)
            {
                stopwatch.Start();
                for (int i = 1; i <= ceiling; i++)
                {
                    //Console.WriteLine("FizzBuzz result for {0} = {1}", i, fizzBuzzPrinter.PrintNumber(i));
                    fizzBuzzPrinter.PrintNumber(i);
                }
                stopwatch.Stop();
                TimeSpan durationTimeSpan1 = stopwatch.Elapsed;

                performanceTimesForFirstMethod[index] = durationTimeSpan1.Milliseconds;
                stopwatch.Reset();
            }

            int averagePerformanceTimeForFirstMethod = GetAveragePerformanceTime(performanceTimesForFirstMethod);

            // call once to prime the JIT
            PrintFizzBuzzForRange(1, 1);

            for (int index = 0; index < performanceTimesForFirstMethod.Length; index++)
            {
                stopwatch.Start();
                PrintFizzBuzzForRange(1, ceiling);
                stopwatch.Stop();
                TimeSpan durationTimeSpan2 = stopwatch.Elapsed;
                stopwatch.Reset();
                performanceTimesForSecondMethod[index] = durationTimeSpan2.Milliseconds;
            }

            int averagePerformanceTimeForSecondMethod = GetAveragePerformanceTime(performanceTimesForSecondMethod);

            returnedArray.Add(string.Format("Below is the performance for {0} numbers executed {1} times", ceiling, numberOfTimesToExecute));

            returnedArray.Add(
                string.Format(
                    "average duration (in milliseconds) for FizzBuzzPrinter (method in seperate class) was: {0}",
                    averagePerformanceTimeForFirstMethod));

            returnedArray.Add(
                string.Format(
                    "average duration (in milliseconds) for PrintFizzBuzzForRange (method in this same class) was: {0}",
                    averagePerformanceTimeForSecondMethod));

            returnedArray.Add("");
        }

        private static int GetAveragePerformanceTime(int[] performanceTimes)
        {
            int indexOfHighestPerformanceTime = 0;
            int indexOfLowestPerformanceTime = 1000000;

            for (int index = 0; index < performanceTimes.Length; index++)
            {
                if (performanceTimes[index] > indexOfHighestPerformanceTime)
                {
                    indexOfHighestPerformanceTime = index;
                }

                if (performanceTimes[index] < indexOfLowestPerformanceTime)
                {
                    indexOfLowestPerformanceTime = index;
                }
            }

            // -1 is magic number meaning 'don't count me
            performanceTimes[indexOfHighestPerformanceTime] = -1;
            performanceTimes[indexOfLowestPerformanceTime] = -1;

            return GetAverage(performanceTimes);
        }

        private static int GetAverage(int[] arrayOfIntegers)
        {
            int totalValueOfAllIntegersCounted = 0;
            int totalNumberOfIntegersCounted = 0;
            for (int index = 0; index < arrayOfIntegers.Length; index++)
            {
                // NOTE -1 is the magic number that means 'don't count me'
                if (arrayOfIntegers[index] != -1)
                {
                    totalValueOfAllIntegersCounted += arrayOfIntegers[index];
                    totalNumberOfIntegersCounted++;
                }
            }

            return totalValueOfAllIntegersCounted/totalNumberOfIntegersCounted;
        }

        private static void PrintFizzBuzzForRange(int lowStartNumber, int highEndingNumber)
        {
            string returnValue;
            bool fizzAndOrBuzz = false;
            for (int i = lowStartNumber; i <= highEndingNumber; i++)
            {
                //returnValue = string.Empty;
                

                if (i%3 == 0)
                {
                    //returnValue = "Fizz";
                    Console.Write("Fizz");
                    fizzAndOrBuzz = true;
                }

                if (i%5 == 0)
                {
                    //returnValue += "Buzz";
                    Console.Write("Buzz");
                    fizzAndOrBuzz = true;
                }

                if (!fizzAndOrBuzz)
                {
                    Console.Write(i);
                }

                Console.WriteLine();
                
                
                //Console.WriteLine(string.IsNullOrEmpty(returnValue) ? i.ToString() : returnValue);
            }
        }
    }
}
