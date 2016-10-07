namespace _00_NameSwitcher
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            List<string> names = Console.ReadLine().Split().ToList();

            Action<int, List<string>> switcher = (indx, target) => target[indx] = "Sir " + target[indx];
            SwitchItUp(names, (indx, target) => target[indx] = "Sir " + target[indx]);
            for (int i = 0; i < names.Count; i++)
            {
                switcher(i, names);
            }

            //Console.Write(string.Join(", ", names));
        }

        static void SwitchItUp(List<string> names, Action<int, List<string>> switcher)
        {
            for (int i = 0; i < names.Count; i++)
            {
                switcher(i, names);
                Console.WriteLine(names[i]);
            }
        }

    }

}
