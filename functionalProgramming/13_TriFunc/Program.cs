namespace _13_TriFunc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            
            int asciiValue = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
       
            Func<string, int, bool> asd = (s, i) => SummmIt(s) >= i;

            Func<List<string>, int, Func<string, int, bool>, string> triFunc = (list, i, func) =>
            {
                string result = string.Empty;
                foreach (var ok in list)
                {
                    if (func(ok, i))
                    {
                        result = ok;
                        break;
                    }
                }
                return result;
            };
            string name = triFunc(names, asciiValue, asd);

            Console.WriteLine(name);
        }

        public static int SummmIt(string s)
        {
            int soFar = 0;
            foreach (var character in s)
            {
                soFar += character;
            }
            return soFar;
        }
        
        
        
    }
}
