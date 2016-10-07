namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Linq;
    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class GarbageProcessor : IGarbageProcessor
    {
        public GarbageProcessor(IStrategyCollector strategyCollector)
        {
            this.StrategyCollector = strategyCollector;
        }

        public GarbageProcessor() : this(new StrategyCollector())
        {
        }

        public IStrategyCollector StrategyCollector { get; private set; }

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            Type type = garbage.GetType();
            DisposableAttribute disposalAttribute = (DisposableAttribute)type.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(DisposableAttribute));
            IGarbageDisposalStrategy currentStrategy;
            if (disposalAttribute == null || !this.StrategyCollector.GetDisposalStrategies.TryGetValue(disposalAttribute.GetType(), out currentStrategy))
            {
                throw new ArgumentException(
                    "The passed in garbage does not implement a supported Disposable Strategy Attribute.");
            }

            return currentStrategy.ProcessGarbage(garbage);
        }
    }
}
