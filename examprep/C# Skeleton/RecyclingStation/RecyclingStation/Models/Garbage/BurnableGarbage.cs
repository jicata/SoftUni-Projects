namespace RecyclingStation.Models
{
    using WasteDisposal.Attributes;
    using WasteDisposal.Interfaces;

    [Burnable]
    public class BurnableGarbage : Garbage
    {
        public BurnableGarbage(string name, double weight, double volPerKg) 
            : base(name, weight, volPerKg)
        {
        }
    }
}
