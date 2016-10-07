namespace _08_MasterNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int upperBound = int.Parse(Console.ReadLine());
            List<int> masterNumbers = new List<int>();
            for (int i = 1; i <= upperBound; i++)
            {
                if (IsPalindrome(i) && IsSevener(i) && HasOneEvenDigit(i))
                {
                    masterNumbers.Add(i);
                }
            }
        }

        private static bool HasOneEvenDigit(int number)
        {
            string numberedString = number.ToString();
            foreach (var digit in numberedString)
            {
                if (int.Parse(digit.ToString())%2 == 0)
                {
                    return true;
                }
            }
            return false;
        }


        private static bool IsSevener(int number)
        {
            string numberedString = number.ToString();
            int sumOfDigits = 0;
            foreach (var digit in numberedString)
            {
                sumOfDigits += int.Parse(digit.ToString());
            }
            if (sumOfDigits%7 == 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsPalindrome(int number)
        {
            char[] str8Number = number.ToString().ToCharArray();
            char[] reversedNumber = number.ToString().Reverse().ToArray();
            if (str8Number.ToString() == reversedNumber.ToString())
            {
                return true;
            }
            return false;
        }
    }
}
