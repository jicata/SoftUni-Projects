namespace _02_StudentsByFirstAndLastName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string[]> students = new List<string[]>();
            while (input != "END")
            {
                string[] inputArgs = input.Split();

                students.Add(inputArgs);
                input = Console.ReadLine();
            }
            students
                .Where(x => x[1].CompareTo(x[0]) > 0)
                .ToList()
                .ForEach(x => Console.WriteLine(x[0] + " " + x[1]));
            
        }
    }
}
