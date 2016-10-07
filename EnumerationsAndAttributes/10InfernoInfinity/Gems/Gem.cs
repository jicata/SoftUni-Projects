namespace _10InfernoInfinity
{
    public abstract class Gem
    {
        private string kind;
        private GemClarity clarity;
        private int strengthBonus;
        private int agilityBonus;
        private int vitalityBonus;

        protected Gem(string kind, GemClarity clarity, int strengthBonus, int agilityBonus, int vitalityBonus)
        {
            this.Kind = kind;
            this.Clarity = clarity;
            this.StrengthBonus = strengthBonus;
            this.AgilityBonus = agilityBonus;
            this.VitalityBonus = vitalityBonus;
        }

        public int StrengthBonus
        {
            get
            {
                return strengthBonus;
            }

            set
            {
                strengthBonus = value + (int)this.clarity;
            }
        }

        public int AgilityBonus
        {
            get
            {
                return agilityBonus;
            }

            set
            {
                agilityBonus = value +(int)this.clarity;
            }
        }

        public int VitalityBonus
        {
            get
            {
                return vitalityBonus;
            }

            set
            {
                vitalityBonus = (int)this.clarity + value;
            }
        }

        public string Kind
        {
            get
            {
                return kind;
            }

            set
            {
                kind = value + (int)this.clarity;
            }
        }

        public GemClarity Clarity
        {
            get
            {
                return clarity;
            }

            set
            {
                clarity = value;
            }
        }
    }
}
