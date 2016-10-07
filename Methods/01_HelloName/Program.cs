namespace _01_HelloName
{
    using System;

    class Program
    {
        static void Main()
        {
            string name = Console.ReadLine();
            Helloer(name);
        }
        public static void Helloer(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }
    }
   
}
