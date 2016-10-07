namespace _02_FuntionalSandbox2
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public static class Queries
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            Console.WriteLine("Where ...");
            foreach (var item in enumerable)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<R> Select<T, R>(this IEnumerable<T> enumerable, Func<T, R> transformator)
        {
            Console.WriteLine("Select ...");
            foreach (var item in enumerable)
            {
                yield return transformator(item);
            }
        }
    }
    class Program
    {
        static void Main()
        {
            int[] collection =
            {
                1, 2, 3, 52, 12, 31, 51, 2, 23452436, 235, 264, 2, 341, 32, 123, 1, 42, 31, 2, 5, 512, 3,
                123, 141, 53, 45, 13, 1
            };
            IEnumerable<int> kur = from i in collection
                where i%2 == 0
                select i + 2;

            IEnumerator<int> kurac = kur.GetEnumerator();
            while (kurac.MoveNext())
            {
                Console.WriteLine(kurac.Current);
            }
        }
    }
}
