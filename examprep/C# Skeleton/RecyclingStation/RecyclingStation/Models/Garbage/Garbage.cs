namespace RecyclingStation.Models
{
    using WasteDisposal.Interfaces;
    public abstract class Garbage : IWaste
    {
        private string name;
        private double weight;
        private double volPerKg;

        public Garbage(string name, double weight, double volPerKg)
        {
            this.Name = name;
            this.Weight = weight;
            this.volPerKg = volPerKg;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public double VolumePerKg
        {
            get { return this.volPerKg; }
        }

        public double Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }

    }
}
