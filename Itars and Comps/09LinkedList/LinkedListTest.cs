using System;
using System.Collections;
using System.Collections.Generic;

namespace _09LinkedList
{
    class LinkedListTest
    {
        static void Main(string[] args)
        {
            LinkedList<int> sequence = new LinkedList<int>();
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine().Split();
                string action = command[0];
                int number = int.Parse(command[1]);
                switch (action)
                {
                    case "Add": sequence.Add(number); break;
                    case "Remove":
                        int removeIndex = sequence.FirstIndexOf(number);
                        if (removeIndex > -1)
                        {
                            sequence.Remove(sequence.FirstIndexOf(number));
                        }
                        break;
                }
            }

            Console.WriteLine(sequence.Count);
            Console.WriteLine(string.Join(" ", sequence));
        }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> head;

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (this.Count == 0)
            {
                this.head = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> lastNode = GetElementAtIndex(this.Count - 1);
                lastNode.NextNode = new ListNode<T>(element); ;
            }

            this.Count++;
        }

        public T Remove(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot remove element from empty list");
            }

            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException(string.Format("Index must be in range [0, {0}]", this.Count));
            }

            var removeNodeValue = default(T);
            if (index == 0)
            {
                removeNodeValue = this.head.Value;
                this.head = this.head.NextNode;
            }
            else
            {
                ListNode<T> previousNode = this.GetElementAtIndex(index - 1);
                ListNode<T> currentNode = this.GetElementAtIndex(index);
                previousNode.NextNode = currentNode.NextNode;

                removeNodeValue = currentNode.Value;
            }

            this.Count--;

            return removeNodeValue;
        }

        public int FirstIndexOf(T element)
        {
            int firstIndex = IndexOf(element, true);
            return firstIndex;
        }

        public int LastIndexOf(T element)
        {
            int lastIndex = IndexOf(element, false);
            return lastIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private ListNode<T> GetElementAtIndex(int index)
        {
            var currentElement = this.head;
            for (int i = 0; i < index; i++)
            {
                currentElement = currentElement.NextNode;
            }

            return currentElement;
        }

        private int IndexOf(T element, bool isFirstFoundIndexNeeded)
        {
            int foundIndex = -1;
            var currentNode = this.head;
            for (int index = 0; index < this.Count; index++)
            {
                if (currentNode.Value.Equals(element))
                {
                    foundIndex = index;
                    if (isFirstFoundIndexNeeded)
                    {
                        return foundIndex;
                    }
                }

                currentNode = currentNode.NextNode;
            }

            return foundIndex;
        }

        private class ListNode<T>
        {
            public ListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }
            public ListNode<T> NextNode { get; set; }
        }
    }
}
