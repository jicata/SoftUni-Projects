namespace _10InfernoInfinity
{
    public class Ruby : Gem
    {
        private const string kind = "Ruby";
        private const int strengthBonus = 7;
        private const int agilityBonus = 2;
        private const int vitalityBonus = 5;

        public Ruby(GemClarity clarity) 
            : base(kind, clarity, strengthBonus, agilityBonus, vitalityBonus)
        {
        }
    }
}
