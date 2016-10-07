namespace _02_FilterEvenOddInRange
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Filters
    {
        
        public static ICollection<int> Where(int[] collection, Func<int, bool> predicate)
        {
            ICollection<int> resultCollection = new List<int>();
            for (int i = 0; i < collection.Length; i++)
            {
                if (predicate(collection[i]))
                {
                    resultCollection.Add(collection[i]);
                }
            }
            return resultCollection;
        }
    }
    class Program
    {
        static void Main()
        {
            int[] bounds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int lowerBound = bounds[0];
            int upperBound = bounds[1];
            int[] range = new int[(upperBound-lowerBound)+1];
            int counter = 0;
            for (int i = lowerBound; i <= upperBound; i++)
            {
                range[counter] = i;
                counter++;
            }
            string command = Console.ReadLine();
            List<int> filtered = new List<int>();
            if (command == "even")
            {
                filtered = Filters.Where(range, x => x % 2 == 0).ToList();
                
            }
            else
            {
                filtered = Filters.Where(range, x => x % 2 != 0).ToList();
            }
            Console.WriteLine(string.Join(" ", filtered));
        }
    }
}
