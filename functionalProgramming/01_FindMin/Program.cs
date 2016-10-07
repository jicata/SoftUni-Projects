namespace _01_FindMin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Queries
    {
        public static int FindMin(IEnumerable<int> collection, Func<int, int> transform)
        {
            List<int> transformedItems = new List<int>();

            foreach (var item in collection)
            {
                int newItem = transform(item);
                transformedItems.Add(newItem);
            }
            int minElement = int.MaxValue;

            foreach (var item in transformedItems)
            {
                if (item < minElement)
                {
                    minElement = item;
                }
            }
            return minElement;
        }

        public static int FindMin(IEnumerable<int> collection)
        {
            int minElement = int.MaxValue;
            foreach (var item in collection)
            {
                if (item < minElement)
                {
                    minElement = item;
                }
            }
            return minElement;
        }
    }
    class Program
    {
        static void Main()
        {


            int[] masivche = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var mda = Queries.FindMin(masivche);
            Console.WriteLine(mda);


        }
    }
}
