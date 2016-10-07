namespace RecyclingStation.Models
{
    using WasteDisposal.Attributes;

    [Recyclable]
    public class RecyclableGarbage:Garbage
    {
        public RecyclableGarbage(string name, double weight, double volPerKg) 
            : base(name, weight, volPerKg)
        {
        }
    }
}
