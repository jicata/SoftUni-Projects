namespace _03BarracksFactory.Core.Commands
{
    using Attributes;
    using Contracts;
    using Factories;

    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory factory;


        public AddCommand(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            var unit = factory.CreateUnit(Data[1]);
            this.repository.AddUnit(unit);
            return Data[1] + " added!";
        }
    }
}
