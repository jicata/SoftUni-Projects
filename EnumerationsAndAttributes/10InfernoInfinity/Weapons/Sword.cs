namespace _10InfernoInfinity.Weapons
{
    public class Sword : Weapon
    {
        private const int numberOfSockets = 3;
        private const int minDamage = 4;
        private const int maxDamage = 6;

        public Sword(string name, WeaponRarity rarity)
            : base(name,numberOfSockets, minDamage, maxDamage, rarity)
        {
        }
    }
}
