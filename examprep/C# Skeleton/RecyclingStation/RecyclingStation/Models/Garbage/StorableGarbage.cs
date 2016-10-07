namespace RecyclingStation.Models
{
    using WasteDisposal.Attributes;

    [Storable]
    public class StorableGarbage : Garbage
    {
        public StorableGarbage(string name, double weight, double volPerKg)
            : base(name, weight, volPerKg)
        {
        }
    }
}
