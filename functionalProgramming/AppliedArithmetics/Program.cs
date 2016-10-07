namespace AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Functions
    {
        public static void Print(List<int> collection,Action<int> act, Action<int>lastElementAct)
        {
            for (int i = 0; i < collection.Count-1; i++)
            {
                act(collection[i]);
            }
            lastElementAct(collection[collection.Count - 1]);
        }
        public static List<int> ApplyFunc(List<int> collection, Func<int, int> func)
        {
            List<int> result = new List<int>();
            foreach (var item in collection)
            {
                result.Add(func(item));
            }
            return result;
        }
    }
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            while (input != "end")
            {
                switch (input)
                {
                    case "add":
                        numbers = Functions.ApplyFunc(numbers, x => x + 1);
                        break;
                    case "subtract":
                        numbers = Functions.ApplyFunc(numbers, x => x - 1);
                        break;
                    case "multiply":
                        numbers = Functions.ApplyFunc(numbers, x => x *2);
                        break;
                    case "print":
                        Functions.Print(numbers, x => Console.Write(x + " "),x=>Console.WriteLine(x));
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
