namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type t = Assembly.GetExecutingAssembly().DefinedTypes.FirstOrDefault(x => x.Name == unitType);
            Type t1 = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == unitType);
            IUnit unit = (IUnit)Activator.CreateInstance(t1);
            return unit;
        }
    }
}
