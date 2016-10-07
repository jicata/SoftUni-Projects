namespace RecyclingStation.GarbageDispositionStrategies
{
    using Models;
    using WasteDisposal.Interfaces;
    public class BurnableGarbageStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            var garbageVolume = garbage.Weight * garbage.VolumePerKg;

            double energyUsed = 0.2 * garbageVolume;
            double energyProduced = garbageVolume;
            double revenue = 0;
            double cost = 0;

            var processingData = new ProcessingData(energyProduced - energyUsed, revenue - cost);
            return processingData;
        }
    }
}
