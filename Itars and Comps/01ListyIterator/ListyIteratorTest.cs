using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01ListyIterator
{
    class ListyIteratorTest
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            ListyIterator<string> listyIterator = null;

            while (line != "END")
            {
                string[] parameters = line.Split();

                switch (parameters[0])
                {
                    case "Create":
                        if (parameters.Length > 1)
                        {
                            List<string> names = new List<string>(parameters);
                            names.RemoveAt(0);
                            listyIterator = new ListyIterator<string>(names);
                        }
                        else
                        {
                            listyIterator = new ListyIterator<string>();
                        }
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }

                line = Console.ReadLine();
            }
        }
    }

    class ListyIterator<T>
    {
        private int currentIndex = 0;
        private IList<T> elements;

        public ListyIterator(IEnumerable<T> collection)
        {
            this.elements = new List<T>(collection);
            this.currentIndex = 0;
        }

        public ListyIterator()
            : this(Enumerable.Empty<T>())
        {
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (currentIndex < elements.Count - 1)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.elements[this.currentIndex]);
        }
    }
}
