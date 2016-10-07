namespace _03_ApplyFunctions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Functions
    {
        public static void MathFunc(IEnumerable<int> collection, Action<int> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
        public static List<int> MathFunc(IEnumerable<int> collection, Func<int, int> func)
        {
            List<int> result = new List<int>();
            foreach (var element in collection)
            {

                result.Add(func(element));
            }
            return result;
        }
    }

    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();


            string userInput = Console.ReadLine();
            while (userInput != "end")
            {
                switch (userInput)
                {
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                    case "add":
                        numbers = Functions.MathFunc(numbers, x => x + 1);
                        break;
                    case "multiply":
                        numbers = Functions.MathFunc(numbers, x => x*2);
                        break;
                    case "subtract":
                        numbers = Functions.MathFunc(numbers, x => x - 1);
                        break;
                    default:
                        break;
                }
                userInput = Console.ReadLine();
            }
            
        }
    }
}
