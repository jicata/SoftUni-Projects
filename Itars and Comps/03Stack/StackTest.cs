using System;
using System.Collections;
using System.Collections.Generic;

namespace _03Stack
{
    class StackTest
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            string command = Console.ReadLine();
            while(command != "END")
            {
                string[] parameters = command.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string action = parameters[0];
                switch (action)
                {
                    case "Push":
                        for (int i = 1; i < parameters.Length; i++)
                        {
                            stack.Push(parameters[i]);
                        }
                        break;
                    case "Pop":
                        try
                        { 
                            stack.Pop();
                        }
                        catch(InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            try
            {
                foreach (string item in stack)
                {
                    Console.WriteLine(item);
                }
                foreach (string item in stack)
                {
                    Console.WriteLine(item);
                }
            }
            catch(InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }
    }

    class Stack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 16;
        private T[] elements;

        public Stack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }
        public int Capacity
        {
            get
            {
                return this.elements.Length;
            }
        }

        public void Push(T element)
        {
            if (this.Count == this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            CheckIfStackIEmpty();

            this.Count--;
            T resutlElement = this.elements[this.Count];
            return resutlElement;
        }

        private void Grow()
        {
            var newElements = new T[2 * this.elements.Length];
            Array.Copy(this.elements, newElements, this.Count);
            this.elements = newElements;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void CheckIfStackIEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
        }
    }
}
