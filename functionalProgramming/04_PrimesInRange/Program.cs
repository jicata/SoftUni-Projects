namespace _04_PrimesInRange
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ReverseFunc
    {
        public static List<int> ReverseAndExclude(List<int> collection , Func<int, bool> predicate )
        {
            List<int> result = new List<int>();
            for (int i = collection.Count-1; i >= 0; i--)
            {
                if (!predicate(collection[i]))
                {
                    result.Add(collection[i]);
                }
            }
            return result;
        } 
      
    }
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = Int32.Parse(Console.ReadLine());
            numbers = ReverseFunc.ReverseAndExclude(numbers, x => x%n == 0);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
