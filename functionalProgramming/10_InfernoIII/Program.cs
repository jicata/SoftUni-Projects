namespace _10_InfernoIII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;



    class Program
    {
        public static List<int> gems = new List<int>();

        static void Main()
        {
            gems = Console.ReadLine().Split().Select(int.Parse).ToList();
            Dictionary<string, Dictionary<int, Func<int, bool>>> predicates =
                new Dictionary<string, Dictionary<int, Func<int, bool>>>();

            string userInput = Console.ReadLine();
            while (userInput != "Forge")
            {
                string[] commandArgs = userInput.Split(';');
                string command = commandArgs[0];
                string filterType = commandArgs[1];
                int filterParam = int.Parse(commandArgs[2]);
                Func<int, bool> predicate = BuildPredicate(filterType, filterParam);
                if (command == "Exclude")
                {
                    if (!predicates.ContainsKey(filterType))
                    {
                        predicates[filterType] = new Dictionary<int, Func<int, bool>>();
                    }
                    predicates[filterType].Add(filterParam, predicate);
                }
                else
                {
                    predicates[filterType].Remove(filterParam);
                }
                userInput = Console.ReadLine();
            }
            gems = PartyFilters(gems, predicates);
            Console.WriteLine(string.Join(" ", gems));
            
        }

        public static Func<int, bool> BuildPredicate(string modifier, int variable)
        {

            switch (modifier)
            {
                case "Sum Left":
                    return x => (x - 1 < 0 ? 0 : gems[x - 1]) + gems[x] == variable;
                case "Sum Right":
                    return x => gems[x] + (x + 1 >= gems.Count ? 0 : gems[x + 1]) == variable;
                case "Sum Left Right":
                    return x => (x - 1 < 0 ? 0 : gems[x - 1]) + gems[x] + (x + 1 >= gems.Count ? 0 : gems[x + 1]) == variable;
                default:
                    return null;
            }
        }

        public static List<int> PartyFilters(List<int> gems,
            Dictionary<string, Dictionary<int, Func<int, bool>>> predicates)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < gems.Count; i++)
            {
                bool filtered = false;
                foreach (var filter in predicates)
                {
                    foreach (var func in filter.Value)
                    {
                        if (func.Value(i))
                        {
                            filtered = true;
                            break;
                        }
                    }
                }
                if (!filtered)
                {
                    result.Add(gems[i]);
                }
            }
            return result;
        }
    }
}

