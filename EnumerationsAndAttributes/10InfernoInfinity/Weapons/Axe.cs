namespace _10InfernoInfinity.Weapons
{
    public class Axe : Weapon
    {
        private const int numberOfSockets = 4;
        private const int minDamage = 5;
        private const int maxDamage = 10;

        public Axe(string name, WeaponRarity rarity)
            : base(name, numberOfSockets, minDamage, maxDamage, rarity)
        {
        }
    }
}
