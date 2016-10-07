namespace _04_NumbersInReversedOrder
{
    using System;
    using System.Text;

    class Program
    {
        static void Main()
        {
            decimal number = Decimal.Parse(Console.ReadLine());
            Console.WriteLine(ReversedDigits(number));
        }

        private static string ReversedDigits(decimal number)
        {
            StringBuilder sb = new StringBuilder();
            string numberStr = number.ToString();
            for (int i = numberStr.Length-1; i >= 0; i--)
            {
                sb.Append(numberStr[i]);
            }
            return sb.ToString();
        }
    }
}
