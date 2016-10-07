namespace _06_ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Predicates
    {
        static List<Func<int, bool>> predicates = new List<Func<int, bool>>();

        public static void AddPredicate(Func<int, bool> predicate)
        {
            predicates.Add(predicate);
        }

        public static List<int> FilterBy(List<int> collection)
        {
            List<int> result = new List<int>();
            bool isLegal = true;
            for (int i = 0; i < collection.Count; i++)
            {
                foreach (var predicate in predicates)
                {
                    if (!predicate(collection[i]))
                    {
                        isLegal = false;
                        break;
                    }
                }
                if (isLegal)
                {
                    result.Add(collection[i]);
                }
                isLegal = true;
            }
            return result;
        } 
    }

    class Program
    {
        static void Main()
        {
            int upperBound = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();
            for (int i = 1; i <= upperBound; i++)
            {
                numbers.Add(i);
            }
            int[] divisors = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (var divisor in divisors)
            {
                Predicates.AddPredicate(x=>x % divisor ==0);
            }
            numbers = Predicates.FilterBy(numbers);
            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
