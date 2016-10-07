namespace _03BarracksFactory.Core.Commands
{
    using Attributes;
    using Contracts;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data):base(data)
        {
        }

        public override string Execute()
        {
            return repository.RemoveUnit(Data[1]);
        }
    }
}
