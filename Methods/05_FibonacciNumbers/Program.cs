namespace _05_FibonacciNumbers
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int fibonacciMember = int.Parse(Console.ReadLine());
            List<int> fibonacciNumbers = FindFibs(fibonacciMember);
            Console.WriteLine(fibonacciNumbers[fibonacciNumbers.Count-1]);
        }

        private static List<int> FindFibs(int fibonacciNumber)
        {
            List<int> fibs = new List<int>();
            fibs.Add(1);
            fibs.Add(1);
            int counter = 2;
            
            while (fibs.Count != fibonacciNumber)
            {
                if (counter == fibs[fibs.Count - 1] + fibs[fibs.Count - 2])
                {
                    fibs.Add(counter);
                }
                counter++;
            }
            return fibs;

        }
    }
}
