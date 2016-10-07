namespace DatETime
{
    using System;
    using System.Globalization;

    class Program
    {
        static void Main()
        {

            Calendar opa = new GregorianCalendar();
            
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();
            DateTime time1 = DateTime.ParseExact(date1, "yyyy MM dd", CultureInfo.InvariantCulture);


            DateTime time2 = DateTime.ParseExact(date2, "yyyy MM dd", CultureInfo.InvariantCulture);
            long tix1 = time1.Ticks;
            long tix2 = time2.Ticks;
            long res = Math.Abs(tix1 - tix2);
            
            
           // Console.WriteLine(ts.TotalDays);
            var ts = Math.Abs((time1 - time2).TotalDays);
            Console.WriteLine(ts);
            //1 1 1  
            //2 1 1
        }
    }
}
