namespace _10.Group_by_Group
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<Person> students = new List<Person>();
            while (input != "END")
            {
                string[] inputArgs = input.Split();

               var human = new Person(inputArgs[0] + " " + inputArgs[1],
                   int.Parse(inputArgs[2]));
                students.Add(human);
                input = Console.ReadLine();
            }
            var sorted = students.GroupBy(x => x.group).OrderBy(x=>x.Key);          
            foreach (var outerElement in sorted)
            {
                Console.Write("{0} - ", outerElement.Key);
                StringBuilder sb =new StringBuilder();
                foreach (var person in outerElement)
                {
                    sb.Append(person.name + ", ");
                }
                sb.Remove(sb.Length - 2,1);
                Console.WriteLine(sb);
               // Console.WriteLine();
            }
            
        }
    }

    public class Person
    {
        public string name;
        public int group;

        public Person(string name, int group)
        {
            this.name = name;
            this.group = group;
        }
    }
}
