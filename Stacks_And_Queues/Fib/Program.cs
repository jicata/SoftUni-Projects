namespace Fib
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibonacci(n));
        }
        static long GetFibonacci(long n)
        {
            Stack<long> stack = new Stack<long>(new long[] { 1, 1 });
            if (n > 2)
            {
                for (int i = 2; i <= n; i++)
                {
                    long currentNumber = stack.Pop();
                    long newNumber = currentNumber + stack.Peek();
                    stack.Push(currentNumber);
                    stack.Push(newNumber);
                }
            }

            return stack.Peek();
        }
    }
}
