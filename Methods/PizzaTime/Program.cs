namespace PizzaTime
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;

    class Pizza
    {
        public static SortedDictionary<int, List<string>> pizzasByGroups=
            new SortedDictionary<int, List<string>>();

        public int group;
        public string name;

        public Pizza(int group, string name)
        {
            this.group = group;
            this.name = name;
        }

        public static SortedDictionary<int, List<string>> GetPizzas(params int[] groups)
        {
            if (groups.Length == 0)
            {
                return Pizza.pizzasByGroups;
            }
            SortedDictionary<int, List<string>> selectGroups 
                = new SortedDictionary<int, List<string>>();
            foreach (var @group in groups)
            {
                List<string> pizzas = Pizza.pizzasByGroups[@group];
                selectGroups.Add(@group, pizzas);
            }
            return selectGroups;
        }

        public static void PrintPizzas()
        {
            foreach (var pizzasByGroup in pizzasByGroups)
            {
                Console.WriteLine("{0} - {1}",
                    pizzasByGroup.Key, string.Join(", ", pizzasByGroup.Value));
            }
        }
    }
    class Program
    {
        static void Main()
        {
            MethodInfo[] methods = typeof(Pizza).GetMethods();
            bool containsMethod = methods.Any(m => m.ReturnType.Name.Contains("SortedDictionary"));
            if (!containsMethod)
            {
                throw new Exception();
            }

            string[] rawPizzas = Console.ReadLine().Split();
            string pattern = @"(\d+)(\w+)";
            Regex matcher = new Regex(pattern);
            List<Pizza> pizzas = new List<Pizza>();
            for (int i = 0; i < rawPizzas.Length; i++)
            {
                Match match = matcher.Match(rawPizzas[i]);
                var pizza = new Pizza(int.Parse(match.Groups[1].Value), match.Groups[2].Value);
                if (!Pizza.pizzasByGroups.ContainsKey(int.Parse(match.Groups[1].Value)))
                {
                    Pizza.pizzasByGroups.Add(int.Parse(match.Groups[1].Value), new List<string>());
                }
                Pizza.pizzasByGroups[int.Parse(match.Groups[1].Value)].Add(match.Groups[2].Value);
            }
            //Pizza.PrintPizzas();
            var selectPizzas = Pizza.GetPizzas();
            foreach (var pizzasByGroup in selectPizzas)
            {
                Console.WriteLine("{0} - {1}",
                    pizzasByGroup.Key, string.Join(", ", pizzasByGroup.Value));
            }
        }

       
    }
}
