namespace _02_MaxMethod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumbers = int.Parse(Console.ReadLine());
            Console.WriteLine(MaxNumber(firstNumber, secondNumber, thirdNumbers));
        }

        public static int MaxNumber(int first, int second, int third)
        {
            List<int> numbers = new List<int>() {first, second, third};
            return numbers.Max();
        }
    }
}
