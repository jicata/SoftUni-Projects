using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06StategyPatter
{
    class StrategyPatternTest
    {
        static void Main(string[] args)
        {
            SortedSet<Person> peopleByName = new SortedSet<Person>(new NameComparer());
            SortedSet<Person> peopleByAge = new SortedSet<Person>(new AgeComparer());

            int peopleCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCount; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                Person person = new Person(name, age);
                peopleByName.Add(person);
                peopleByAge.Add(person);
            }

            foreach (Person person in peopleByName)
            {
                Console.WriteLine(person);
            }

            foreach (Person person in peopleByAge)
            {
                Console.WriteLine(person);
            }
        }
    }

    class Person 
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }

        public override string ToString()
        {
            return this.Name + " " + this.Age;
        }

    }

    class NameComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result = x.Name.Length.CompareTo(y.Name.Length);
            if(result == 0)
            {
                char xFirstLetter = x.Name.ToLower()[0];
                char yFirstLetter = y.Name.ToLower()[0];
                result = xFirstLetter.CompareTo(yFirstLetter);
            }

            return result;
        }
    }

    class AgeComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }

}
