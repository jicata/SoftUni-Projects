namespace _05_PredicateForNames
{
    using System;
    using System.Collections.Generic;

    public static class NameFuncs
    {
        public static List<string> FilterLength(string[] names, Func<string, bool> predicate)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < names.Length; i++)
            {
                if (predicate(names[i]))
                {
                    result.Add(names[i]);
                }
            }
            return result;
        } 
    }
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            List<string> filteredNames = new List<string>();
            filteredNames = NameFuncs.FilterLength(names, s => s.Length <= n);
            foreach (var name in filteredNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
