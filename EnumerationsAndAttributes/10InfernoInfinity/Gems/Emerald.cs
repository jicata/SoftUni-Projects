namespace _10InfernoInfinity.Gems
{
    public class Emerald : Gem
    {
        private const string kind = "Emerald";
        private const int strengthBonus = 1;
        private const int agilityBonus = 4;
        private const int vitalityBonus = 9;

        public Emerald(GemClarity clarity) 
            : base(kind, clarity, strengthBonus, agilityBonus, vitalityBonus)
        {
        }
    }
}
