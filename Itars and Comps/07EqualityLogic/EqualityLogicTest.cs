using System;
using System.Collections.Generic;


namespace _07EqualityLogic
{
    class EqualityLogicTest
    {
        static void Main()
        {
            SortedSet<Person> peopleSet = new SortedSet<Person>();
            HashSet<Person> peopleHash = new HashSet<Person>();

            int peopleCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCount; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(name, age);

                peopleSet.Add(person);
                peopleHash.Add(person);
            }

            Console.WriteLine(peopleSet.Count);
            Console.WriteLine(peopleHash.Count);
        }
    }

    class Person : IComparable<Person>
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

        public override bool Equals(object obj)
        {
            Person other = obj as Person;
            if(other == null)
            {
                return false;
            }

            if(this.CompareTo(other) == 0)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Age ^ 231;
        }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);
            if(result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }
            return result;
        }
    }
}
