namespace RecyclingStation.GarbageDispositionStrategies
{
    using Models;
    using WasteDisposal.Interfaces;
    public class StorableGarbageStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            var garbageVolume = garbage.Weight * garbage.VolumePerKg;

            double energyUsed = 0;
            double energyProduced = 0.13 * garbageVolume;
            double revenue = 0;
            double cost = 0.65 * garbageVolume;

            var processingData = new ProcessingData(energyProduced - energyUsed, revenue - cost);
            return processingData;
        }
    }
}
