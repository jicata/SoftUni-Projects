namespace _10InfernoInfinity.Weapons
{
    public class Knife : Weapon
    {
        private const int numberOfSockets = 2;
        private const int minDamage = 3;
        private const int maxDamage = 4;

        public Knife(string name,WeaponRarity rarity) 
            : base(name,numberOfSockets, minDamage, maxDamage, rarity)
        {
        }
    }
}
