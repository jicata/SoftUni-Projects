using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01EventImplementation.Models;

namespace _01EventImplementation
{
    class EventImplementation
    {
        static void Main(string[] args)
        {
            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler();

            dispatcher.ChangedName += handler.OnDispatcherNameChange;

            string line = Console.ReadLine();
            while (line != "End")
            {
                dispatcher.Name = line;
                line = Console.ReadLine();
            }
        }
    }
}
