namespace Comparators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            SortedSet<Person> byAge = new SortedSet<Person>(new AgeComp());
            SortedSet<Person> byName = new SortedSet<Person>(new NameComp());
            int numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personDetails = Console.ReadLine().Split();
                var person = new Person(personDetails[0], int.Parse(personDetails[1]));
                byAge.Add(person);
                byName.Add(person);
            }
            Console.WriteLine(string.Join(Environment.NewLine, byName));
            Console.WriteLine(string.Join(Environment.NewLine, byAge));
        }
    }
    class NameComp : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result = x.name.Length.CompareTo(y.name.Length);
            if (result == 0)
            {
                string firstChar = x.name[0].ToString();
                string secondFirstChar = y.name[0].ToString();
                result = String.Compare(firstChar, secondFirstChar, true);
            }
            return result;
        }
    }


    class RandomComp : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return 0;
        }
    }
    class AgeComp : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.age.CompareTo(y.age);
        }
    }
    internal class Person 
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return this.name + " " + this.age;
        }
    }
}
