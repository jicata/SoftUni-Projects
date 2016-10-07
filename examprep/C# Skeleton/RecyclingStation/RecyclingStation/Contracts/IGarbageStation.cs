namespace RecyclingStation.Contracts
{
    using WasteDisposal.Interfaces;

    public interface IGarbageStation
    {
        IGarbageProcessor GarbageProcessor { get; }
        IManagementRequirement ManagementRequirement { get; }
        double EnergyBalance { get; set; }
        double CapitalBalance { get; set; }
    }
}
