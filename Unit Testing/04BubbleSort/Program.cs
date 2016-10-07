namespace _04BubbleSort
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            List<int> collection = new List<int>() {3,2,1,5,1,2,46,1,2,4521,1,23,12,4};
            Bubble bubble = new Bubble();
            var sorted = bubble.Sort(collection);
            Console.WriteLine(string.Join(", ", sorted));
        }
    }
}
