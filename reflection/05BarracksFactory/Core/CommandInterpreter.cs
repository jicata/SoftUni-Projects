namespace _03BarracksFactory.Core
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using Attributes;
    using Contracts;
    using Commands;
    using System.Linq;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandsNamespacePath = "_03BarracksFactory.Core.Commands.";
        private const string CommandSuffix = "Command";

        private IUnitFactory unitFactory;
        private IRepository repository;

        public CommandInterpreter(IUnitFactory unitFactory, IRepository repository)
        {
            this.unitFactory = unitFactory;
            this.repository = repository;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string commandFullName = 
                CommandsNamespacePath + 
                CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + 
                CommandSuffix;

            object[] commandParameters = new object[] { data };

            IExecutable command = null;
            try
            {
              command = (Command)Activator.CreateInstance(Type.GetType(commandFullName), commandParameters);
            }
            catch
            {
                throw new InvalidOperationException("Invalid command!");
            }

            command = this.InjectDependencies(command);
            return command;
        }

        private IExecutable InjectDependencies(IExecutable command)
        {
            FieldInfo[] fieldsOfCommand = command.GetType()
                                              .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo[] fieldsOfInterpreter = typeof(CommandInterpreter)
                                              .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fieldsOfCommand)
            {
                var fieldAttribute = field.GetCustomAttribute(typeof(InjectAttribute));
                if(fieldAttribute != null)
                {
                    if(fieldsOfInterpreter.Any(x => x.FieldType == field.FieldType))
                    {
                        field.SetValue(command,
                            fieldsOfInterpreter.First(x => x.FieldType == field.FieldType)
                            .GetValue(this));
                    }
                }
            }

            return command;
        }
    }
}
