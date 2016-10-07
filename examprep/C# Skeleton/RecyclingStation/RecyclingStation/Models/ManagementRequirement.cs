namespace RecyclingStation.Models
{
    using System;
    using Contracts;

    public class ManagementRequirement : IManagementRequirement
    {
        public double EnergyRequirement { get; set; }
        public double CapitalRequirement { get; set; }
        public Type GarbageType { get; set; }
    }
}
