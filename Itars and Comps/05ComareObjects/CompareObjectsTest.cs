using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05ComareObjects
{
    class CompareObjectTest
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = Console.ReadLine();
            while(input != "END")
            {
                string[] tokens = input.Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];
                Person person = new Person(name, age, town);
                people.Add(person);
                input = Console.ReadLine();
            }

            int matchIndex = int.Parse(Console.ReadLine()) - 1;
            Person matchPerson = people[matchIndex];

            int equalPeopleCount = people.Count(x => x.CompareTo(matchPerson) == 0);
            int notEqualPeopleCount = people.Count(x => x.CompareTo(matchPerson) != 0);
            int totalPeopleCount = people.Count;

            if (equalPeopleCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", equalPeopleCount, notEqualPeopleCount, totalPeopleCount);
            }
        }
    }

    class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            if(result == 0)
            {
                result = this.Town.CompareTo(other.Town);
            }
            
            return result;
        }
    }
}
