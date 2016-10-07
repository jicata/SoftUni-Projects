namespace RecyclingStation.Contracts
{
    using System;

    public interface IManagementRequirement
    {
        double EnergyRequirement { get; set; }
        double CapitalRequirement { get; set; }
        Type GarbageType { get; set; }
    }
}
