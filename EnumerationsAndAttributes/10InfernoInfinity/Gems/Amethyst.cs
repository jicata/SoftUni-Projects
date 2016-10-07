namespace _10InfernoInfinity.Gems
{
    public class Amethyst : Gem
    {
        private const string kind = "Amethyst";
        private const int strengthBonus = 2;
        private const int agilityBonus = 8;
        private const int vitalityBonus = 4;

        public Amethyst(GemClarity clarity) 
            : base(kind, clarity, strengthBonus, agilityBonus, vitalityBonus)
        {
        }
    }
}
