namespace ExcellentStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<string[]> students = new List<string[]>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] studentDetails = input.Split();
                students.Add(studentDetails);
                input = Console.ReadLine();
            }
            students
                .Where(x => x[0].EndsWith("14") || x[0].EndsWith("15"))
                .ToList()
                .ForEach(x => Console.WriteLine(string.Join(" ", x.Skip(1))));


        }
    }
}
