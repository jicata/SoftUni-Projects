namespace RecyclingStation.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using GarbageDispositionStrategies;
    using WasteDisposal.Attributes;
    using WasteDisposal.Interfaces;

    public class GarbageStation : IGarbageStation
    {
        private IGarbageProcessor garbageProcessor;
        private IManagementRequirement managementRequirement;

        public GarbageStation(IStrategyCollector strategyCollector, IGarbageProcessor garbageProcessor)
        {
            this.garbageProcessor = garbageProcessor;
            this.managementRequirement = null;
            this.BufferPresetStrategies();
        }

        public IGarbageProcessor GarbageProcessor
        {
            get { return this.garbageProcessor; }
        }

        public IManagementRequirement ManagementRequirement
        {
            get { return this.managementRequirement; }
        }

        public double EnergyBalance { get; set; }

        public double CapitalBalance { get; set; }

        private bool EvaluateWasteAgainstManagementRequirement(IWaste waste)
        {
            if (this.managementRequirement != null && waste.GetType() == this.ManagementRequirement.GarbageType)
            {
                bool capitalBalanceFulfilled = this.CapitalBalance >= this.ManagementRequirement.CapitalRequirement;
                bool energyBalanceFulfilled = this.EnergyBalance >= this.ManagementRequirement.EnergyRequirement;

                if (!capitalBalanceFulfilled || !energyBalanceFulfilled)
                {
                    return false;
                }
            }
            return true;
        }

        private void BufferPresetStrategies()
        {
            IGarbageDisposalStrategy burnStrat = new BurnableGarbageStrategy();
            IGarbageDisposalStrategy recycStrat = new RecyclableGarbageStrategy();
            IGarbageDisposalStrategy storeStrat = new StorableGarbageStrategy();

            this.GarbageProcessor.StrategyCollector.AddStrategy(new BurnableAttribute().GetType(), burnStrat);
            this.GarbageProcessor.StrategyCollector.AddStrategy(new RecyclableAttribute().GetType(), recycStrat);
            this.GarbageProcessor.StrategyCollector.AddStrategy(new StorableAttribute().GetType(), storeStrat);
        }

        public void ProcessWaste(IWaste waste)
        {
            if (this.EvaluateWasteAgainstManagementRequirement(waste))
            {
                var resultOfProcess = this.GarbageProcessor.ProcessWaste(waste);
                this.EnergyBalance += resultOfProcess.EnergyBalance;
                this.CapitalBalance += resultOfProcess.CapitalBalance;
            }
            else
            {
                Console.WriteLine("Mi ne");
            }
        }
    }
}
