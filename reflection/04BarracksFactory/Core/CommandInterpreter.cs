namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;
    using Commands;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

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

            Type t =
                Assembly.GetExecutingAssembly()
                    .DefinedTypes.FirstOrDefault(
                        x => x.Name == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandSuffix);
            object[] commandParameters = new object[]
            {
                data,
                repository,
                unitFactory
            };

            IExecutable command = null;
            try
            {
              command = (Command)Activator.CreateInstance(t, commandParameters);
            }
            catch
            {
                throw new InvalidOperationException("Invalid command!");
            }

            return command;
        }
    }
}
