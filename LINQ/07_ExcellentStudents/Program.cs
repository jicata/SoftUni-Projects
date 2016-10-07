namespace _07_ExcellentStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
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
                .Where(x => x.Contains("6"))
                .ToList()
                .ForEach(x => Console.WriteLine(string.Format("{0} {1}", x[0], x[1])));
        }
    }
}
