namespace _01_FunctionalSandbox
{
    using System;
    using System.CodeDom;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;

    class Program
    {
        static void Main()
        {
            List<Predicate<int>> predicates = new List<Predicate<int>>();
            List<int> numbers = new List<int>
            {1,2,3,4,5,6,7,111};

            //Predicate<int> randomPredicate = i => i % 3 == 0;
            //Predicate<int> randomPredicate2 = i => i * 2 < 23;


            //predicates.Add(randomPredicate);
            //predicates.Add(randomPredicate2);


            //var myFunctionalBot = new MyEnumerator<int>(numbers);
            //var importantItem = myFunctionalBot.Where(x => x == 122).Enumerate();
            //int myItem = FirstOrDefault(numbers, x => x == -3);
            //bool real = MyAny(numbers, x => x < 0);
            Action<int> actionMovie = x => Console.WriteLine(x);
            ReversePrint(numbers, actionMovie);
            //var kg = numbers.OrderByDescending(x => 90);

            //Console.WriteLine(string.Join(" ", kg));

            //Console.WriteLine(myItem);
            //Console.WriteLine(string.Join(" ", importantItem));
            //Console.WriteLine(real);

        }

        public static void ReversePrint(List<int> collection, Action<int> action)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                action(collection[i]);
            }
        }

        public static IEnumerable<int> RangeWhere(int[] collection, int startIndex, int count, string predicate)
        {
            ICollection<int> resultCollection = new List<int>();
            for (int i = startIndex; i <= startIndex + count; i++)
            {
                resultCollection.Add(collection[i]);
            }
            var func = GetWhere(predicate);

            return resultCollection.Where(func);
        }

        private static Func<int, bool> GetWhere(string predicate)
        {
            switch (predicate)
            {
                case "odd":
                    return (x) => x % 2 != 0;
                case "even":
                    return (x) => x % 2 == 0;
                default:
                    throw new ArgumentException();
            }
        }

        public static T FirstOrDefault<T>(IEnumerable<T> collection, Func<T, bool> predicate)
        {
            T result = default(T);
            foreach (T item in collection)
            {
                if (predicate(item))
                {
                    result = item;
                    break;
                }
            }
            return result;
        }

        public static bool MyAny<TSource>(IEnumerable<TSource> collection, Func<TSource, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class MyEnumerator<T>
    {
        private IEnumerable<T> data;

        private List<Predicate<T>> predicates = new List<Predicate<T>>();

        public MyEnumerator(IEnumerable<T> collection)
        {
            this.data = collection;
        }

        public MyEnumerator<T> Where(Predicate<T> filterPredicate)
        {
            this.predicates.Add(filterPredicate);
            return this;
        }

        public IEnumerable<T> Enumerate()
        {
            ICollection<T> result = new List<T>();
            foreach (T element in this.data)
            {
                var filtered = false;
                foreach (Predicate<T> predicate in this.predicates)
                {
                    if (!predicate(element))
                    {
                        filtered = true;
                        break;
                    }
                }
                if (!filtered)
                {
                    result.Add(element);
                }
            }
            return result;
        }
    }
}
