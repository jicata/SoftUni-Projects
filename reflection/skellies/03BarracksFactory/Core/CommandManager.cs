namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Contracts;
    using Data;
    using Factories;

    public class CommandManager : ICommandInterpreter
    {
        [Inject] private IRepository repository = new UnitRepository();
        [Inject] private IUnitFactory factory = new UnitFactory();

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Type typeOfCommand = Assembly.GetExecutingAssembly().DefinedTypes
                .FirstOrDefault(x => x.Name.ToLower() == commandName.ToLower() + "command");
            IExecutable command = (IExecutable) Activator.CreateInstance(typeOfCommand, new object[] {data});
          
            return command;

        }

       

    }

}