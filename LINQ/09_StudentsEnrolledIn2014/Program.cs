namespace _09_StudentsEnrolledIn2014
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
            //554214 6 6 6 5
            //653215 3 4 5 6
            //156212 4 2 3 4

            students
                .Where(x => int.Parse(x[0][x[0].Length - 2].ToString() + x[0][x[0].Length - 1].ToString()) == 14 
                || int.Parse(x[0][x[0].Length - 2].ToString() + x[0][x[0].Length - 1].ToString()) == 15)
                .ToList()
                .ForEach(x => Console.WriteLine(string.Format("{0}",
                string.Join(" ", x.Skip(1).ToList()))));
        }
    }
}
