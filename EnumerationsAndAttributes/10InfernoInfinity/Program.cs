namespace _10InfernoInfinity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    class Program
    {
        public static List<CustomClassAttributes> GetCustomAttributesa()
        {
            var attributes = (typeof(Weapon)).GetCustomAttributes(false).Cast<CustomClassAttributes>().ToList();
            return attributes;
        }

        static void Main()
        {
            Dictionary<string, Weapon> weapons = new Dictionary<string, Weapon>();
            WeaponFactory weapongFactory = new WeaponFactory();
            GemFactory gemFactory = new GemFactory();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] commandArgs = input.Split(';');
                string commandType = commandArgs[0];
                var custAtts = GetCustomAttributesa();
                switch (commandType)
                {                 
                    case "Create":
                        weapons.Add(commandArgs[2], weapongFactory.ProduceWeapon(commandArgs[1], commandArgs[2]));
                        break;
                    case "Add":
                        var gem = gemFactory.ProduceGem(commandArgs[3]);
                        var weаpon = weapons[commandArgs[1]];
                        weаpon.AddGem(gem, int.Parse(commandArgs[2]));
                        break;
                    case "Remove":
                        weаpon = weapons[commandArgs[1]];
                        weаpon.Remove(int.Parse(commandArgs[2]));
                        break;
                    case "Print":
                        weаpon = weapons[commandArgs[1]];
                        weаpon.Print();
                        break;
                    case "Author":
                        Console.WriteLine("Author: {0}",custAtts[0].Author);
                        break;
                    case "Revision":
                        Console.WriteLine("Revision: {0}", custAtts[0].Revision);
                        break;
                    case "Description":
                        Console.WriteLine("Class description: {0}",custAtts[0].Description);
                        break;
                    case "Reviewers":
                        Console.WriteLine("Reviewers: {0}",string.Join(", ", custAtts[0].Reviewers));
                        break;
                }
                input = Console.ReadLine();
            }
        }

       
    }
}
