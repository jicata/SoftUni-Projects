namespace ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Predicates
    {
        public static List<Func<int,bool>> predicates = new List<Func<int, bool>>();

        public static void AddPredicate(Func<int, bool> predicate)
        {
            predicates.Add(predicate);
        }

        public static List<int> ApplyPredicates(List<int> numbers)
        {
            List<int> result = new List<int>();
            bool legal = true;
            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNum = numbers[i];
                foreach (var predicate in predicates)
                {
                    if (!predicate(currentNum))
                    {
                        legal = false;
                        break;
                    }
                }
                if (legal)
                {
                    result.Add(currentNum);
                }
                legal = true;
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
                Predicates.AddPredicate(x=>x%divisor == 0);
            }
         
            numbers = Predicates.ApplyPredicates(numbers);
            Console.WriteLine(String.Join(" ", numbers));
        }

       
    }
}
