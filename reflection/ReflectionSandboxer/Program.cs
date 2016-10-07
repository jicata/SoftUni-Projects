namespace ReflectionSandbox
{
    using System;
    using System.Linq;
    using System.Reflection;
    using _02BlackBoxInteger;

    class Program
    {
        static void Main()
        {
            Type bbType = typeof(BlackBoxInt);
         
            ConstructorInfo blackboxConstructor =
                bbType.GetConstructor(
                    BindingFlags.Instance
                    | BindingFlags.Public
                    | BindingFlags.NonPublic,
                    null,
                    Type.EmptyTypes,
                    null);

            BlackBoxInt bbint = (BlackBoxInt)blackboxConstructor.Invoke(new object[] { });

            FieldInfo[] fields = bbType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            string fieldName = fields.First().Name;

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] commandArgs = command.Split('_');
                string commandName = commandArgs[0];
                int commandValue = Int32.Parse(commandArgs[1]);

                var method = bbType.GetMethod(commandName, BindingFlags.Instance | BindingFlags.NonPublic);
                method.Invoke(bbint, new object[] { commandValue });

                FieldInfo field = bbType.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
                Console.WriteLine(field.GetValue(bbint));
                command = Console.ReadLine();

            }
        }
    }
}
