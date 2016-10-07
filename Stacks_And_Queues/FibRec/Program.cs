using System;

namespace RecursiveFibonacci
{
    public class RecursiveFibonacci
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //Fibonacci(0, 1, 1, n);
            int[] tests = new[] {1, 2, 3, 6, 8, 24, 30, 37, 42, 49};
            for (int i = 0; i < tests.Length; i++)
            {
                Console.Write("The {0} fibonacci number is: ",tests[i]);
                Console.WriteLine(ProperFib(tests[i]));
            }
            
        }

        public static int ProperFib(int number)
        {
            if (number == 0)
            {
                return 0;
            }
            else if (number <= 1)
            {
                return 1;
            }

           
            else
            {
                return ProperFib(number - 2) + ProperFib(number - 1);
            }
        }
        
    }
}
