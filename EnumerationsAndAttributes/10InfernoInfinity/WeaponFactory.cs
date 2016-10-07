namespace _10InfernoInfinity
{
    using System;
    using Weapons;

    public class WeaponFactory
    {
        public Weapon ProduceWeapon(string typeAndRarity, string name)
        {
            string[] typeAndRaritySplit = typeAndRarity.Split();
            WeaponRarity rarity = (WeaponRarity) Enum.Parse(typeof(WeaponRarity), typeAndRaritySplit[0]);
            switch (typeAndRaritySplit[1])
            {
                case "Axe":
                    return new Axe(name, rarity);
                    break;
                case "Sword":
                    return new Sword(name, rarity);
                    break;
                case "Knife":
                    return new Knife(name, rarity);
                    break;
                default:
                    return null;
            }
        }
    }
}
