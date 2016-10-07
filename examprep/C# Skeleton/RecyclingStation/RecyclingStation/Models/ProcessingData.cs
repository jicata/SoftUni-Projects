namespace RecyclingStation.Models
{
    using WasteDisposal.Interfaces;
    public class ProcessingData : IProcessingData
    {
        public double EnergyBalance { get; }
        public double CapitalBalance { get; }

        public ProcessingData(double energyBalance, double capitalBalance)
        {
            this.EnergyBalance = energyBalance;
            this.CapitalBalance = capitalBalance;
        }
    }
}
