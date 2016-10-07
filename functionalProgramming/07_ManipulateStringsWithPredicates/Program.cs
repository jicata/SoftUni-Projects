namespace _07_ManipulateStringsWithPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Functions
    {
        public static Func<string, bool> BuildPredicate(string modifier, string variable)
        {
            switch (modifier)
            {
                case "StartsWith":
                    return x => x.StartsWith(variable);
                case "EndsWith":
                    return x => x.EndsWith(variable);
                case "Length":
                    return x => x.Length == int.Parse(variable);
                default:
                    return null;
            }
        }

        public static List<string> DoubleUp(IEnumerable<string> collection, Func<string, bool> predicate)
        {
            List<string> result = new List<string>();
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
                result.Add(item);
            }
            return result;
        }

        public static List<string> Remove(IEnumerable<string> collection, Func<string, bool> predicate)
        {
            List<string> result = new List<string>();
            foreach (var item in collection)
            {
                if (!predicate(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
    class Program
    {
        static void Main()
        {
            List<string> names = Console.ReadLine().Split().ToList();
            string userInput = Console.ReadLine();
           
            while (userInput != "Party!")
            {
                string[] commandArgs = userInput.Split();
                string command = commandArgs[0];
                string modifier = commandArgs[1];
                string variable = commandArgs[2];

                Func<string, bool> predicate = Functions.BuildPredicate(modifier, variable);
                if (command == "Remove")
                {
                    names = Functions.Remove(names, predicate);
                }
                else
                {
                    names = Functions.DoubleUp(names, predicate);
                }
                userInput = Console.ReadLine();
            }
            if (names.Count > 0)
            {
                Console.Write(string.Join(", ", names));
                Console.Write(" are going to the party!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            
        }
    }
}
