namespace RecyclingStation.GarbageDispositionStrategies
{
    using Models;
    using WasteDisposal.Interfaces;
    public class RecyclableGarbageStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            var garbageVolume = garbage.Weight * garbage.VolumePerKg;

            double energyUsed = 0;
            double energyProduced = 0.5 * garbageVolume;
            double revenue = 400 * garbage.Weight;
            double cost = 0;

            var processingData = new ProcessingData(energyProduced - energyUsed, revenue - cost);
            return processingData;

        }
    }
}
