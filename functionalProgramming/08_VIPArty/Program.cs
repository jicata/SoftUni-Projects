using System;
using System.Collections.Generic;
using System.Linq;
namespace _08_VIPArty
{
    public static class Functions
    {
        public static Func<string, bool> BuildPredicate(string modifier, string variable)
        {
            switch (modifier)
            {
                case "Starts with":
                    return x => x.StartsWith(variable);
                case "Ends with":
                    return x => x.EndsWith(variable);
                case "Length":
                    return x => x.Length == int.Parse(variable);
                case "Contains":
                    return x => x.Contains(variable);
                default:
                    return null;
            }
        }

        public static List<string> Filter(List<string> collection,
            Dictionary<string, Dictionary<string, Func<string, bool>>> filters)
        {
            List<string> result = new List<string>();
           
            foreach (var item in collection)
            {
                bool filtered = false;
                foreach (var filter in filters)
                {
                    foreach (var func in filter.Value)
                    {
                        if (func.Value(item))
                        {
                            filtered = true;
                            break;
                        }
                    }
                }
                if (!filtered)
                {
                    result.Add(item);
                }
            }
            return result;
        } 
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            Dictionary<string, Dictionary<string, Func<string, bool>>> partyFilters = new Dictionary<string, Dictionary<string, Func<string, bool>>>();

            string userInput = Console.ReadLine();
            while (userInput != "Print")
            {

                string[] commandArgs = userInput.Split(';');
                string command = commandArgs[0];
                string modifier = commandArgs[1];
                string variable = commandArgs[2];

                Func<string, bool> predicate = Functions.BuildPredicate(modifier, variable);
                if (command == "Add filter")
                {
                    if (!partyFilters.ContainsKey(modifier))
                    {
                        partyFilters.Add(modifier, new Dictionary<string, Func<string, bool>>());
                    }
                    partyFilters[modifier].Add(variable,predicate);
                }
                else
                {
                    partyFilters[modifier].Remove(variable);
                }
                userInput = Console.ReadLine();
            }
            names = Functions.Filter(names, partyFilters);
            Console.WriteLine(string.Join(" ", names));

        }
    }
}
