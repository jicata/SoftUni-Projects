using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SortStudents
{
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
                .OrderBy(x=>x[1])
                .ThenByDescending(x=>x[0])
                .ToList()
                .ForEach(x => Console.WriteLine(string.Format("{0} {1}", x[0], x[1])));
        }
    }
}
