namespace _03BarracksFactory.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Commands;
    using Contracts;

    class Engine : IRunnable
    {
        [Inject] private IRepository repository;
        [Inject] private IUnitFactory factory;

        private ICommandInterpreter interpreter;

        public Engine(IRepository repository, IUnitFactory unitFactory, ICommandInterpreter interpreter)
        {
            this.repository = repository;
            this.factory = unitFactory;
            this.interpreter = interpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    var command = interpreter.InterpretCommand(data, commandName);
                    command = InjectDependencies(command);
                    string result = command
                        .Execute();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        private IExecutable InjectDependencies(IExecutable command)
        {

            FieldInfo[] fieldsOfCommand = command.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.GetCustomAttributes(typeof(InjectAttribute)).Any()).ToArray(); ;

            FieldInfo[] fieldsOfEngine = typeof(Engine)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.GetCustomAttributes(typeof(InjectAttribute)).Any()).ToArray();

            foreach (var fieldOfCommand in fieldsOfCommand)
            {
                var correctField = fieldsOfEngine.First(x => x.Name == fieldOfCommand.Name);
                fieldOfCommand.SetValue(command,correctField.GetValue(this));
                //fieldOfCommand.SetValue(command, );


            }

            return command;
        }


    }
}