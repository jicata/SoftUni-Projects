using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_FilterStudentsByEmailDomain
{
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
                .Where(x=>x[2].Contains("@gmail.com"))
                .ToList()
                .ForEach(x => Console.WriteLine(string.Format("{0} {1}", x[0], x[1])));
        }
    }
}
