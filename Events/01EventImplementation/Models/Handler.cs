using System;

namespace _01EventImplementation.Models
{
    public class Handler
    {
        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine("Dispatcher's name changed to {0}.", args.Name);
        }
    }
}
