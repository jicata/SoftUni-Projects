namespace _05_CustomComparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MyComparator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if ((x % 2 == 0) && (y % 2 != 0))
            {
                return -1;
            }
            else if ((x % 2 != 0) && (y % 2 == 0))
            {
                return 1;
            }
            else
            {
                if (x < y)
                {
                    return -1;
                }
                else if (x > y)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(numbers, new MyComparator());
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
