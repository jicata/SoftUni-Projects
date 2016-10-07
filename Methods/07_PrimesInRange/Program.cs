namespace _07_PrimesInRange
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int lowerBound = int.Parse(Console.ReadLine());
            int upperBound = int.Parse(Console.ReadLine());

            List<int> primesInRange = PrimesInRange(lowerBound, upperBound);
            Console.WriteLine(string.Join(", ", primesInRange));
        }

        private static List<int> PrimesInRange(int lowerBound, int upperBound)
        {
            List<int> result = new List<int>();
            bool isPrime = true;
            for (int i = Math.Max(2,lowerBound); i <= upperBound; i++)
            {
                int currentNum = i;
                for (int j = 2; j <= Math.Sqrt(currentNum); j++)
                {
                    if (currentNum%j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    result.Add(currentNum);
                }
                isPrime = true;
            }
            return result;
        }
    }
}
