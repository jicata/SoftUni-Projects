namespace _02BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    class BlackBoxIntegerTests
    {
        static void Main(string[] args)
        {
            Type blackBoxIntType = typeof(BlackBoxInt);

            ConstructorInfo blackBoxConstructor = blackBoxIntType
                .GetConstructor(
                     BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                     null, 
                     Type.EmptyTypes, 
                     null);

            BlackBoxInt number = (BlackBoxInt) blackBoxConstructor.Invoke(new object[] { });

            FieldInfo[] fields = blackBoxIntType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            string fieldName = fields.FirstOrDefault().Name;

            string command = Console.ReadLine();
            while(command != "END")
            {
                string[] commandArgs = command.Split('_');
                string operation = commandArgs[0];
                int num = int.Parse(commandArgs[1]);

                MethodInfo method = blackBoxIntType
                    .GetMethod(
                        operation, 
                        BindingFlags.Instance | BindingFlags.NonPublic |  BindingFlags.Public);
                method.Invoke(number, new object[] { num});

                FieldInfo field = blackBoxIntType
                    .GetField(
                    fieldName, 
                    BindingFlags.Instance | BindingFlags.NonPublic);

                Console.WriteLine(field.GetValue(number));

                command = Console.ReadLine();
            }
        }
    }
}
