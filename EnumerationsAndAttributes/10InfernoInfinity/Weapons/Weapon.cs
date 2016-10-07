namespace _10InfernoInfinity
{
    using System;
    using System.Linq;

    [CustomClassAttributes("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public abstract class Weapon
    {
        private string name;
        private Gem[] sockets;
        private int minDamage;
        private int maxDamage;
        private int strength = 0;
        private int agility = 0;
        private int vitality = 0;
        WeaponRarity rarity;

        protected Weapon(string name,int numberOfSockets, int minDamage, int maxDamage, WeaponRarity rarity)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.sockets = new Gem[numberOfSockets];
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
        }

        public Gem[] Sockets
        {
            get
            {
                return sockets;
            }
        }

        public int MinDamage
        {
            get
            {
                return minDamage;
            }

            protected set
            {
                minDamage = value * (int)rarity;
            }
        }

        public int MaxDamage
        {
            get
            {
                return maxDamage;
            }

            protected set
            {
                maxDamage = value * (int)rarity; 
            }
        }

        public WeaponRarity Rarity
        {
            get
            {
                return rarity;
            }

            protected set
            {
                rarity = value;
            }
        }

        public int Strength
        {
            get
            {
                return strength;
            }

            set
            {
                strength = value;
            }
        }

        public int Agility
        {
            get
            {
                return agility;
            }

            set
            {
                agility = value;
            }
        }

        public int Vitality
        {
            get
            {
                return vitality;
            }

            set
            {
                vitality = value;
            }
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

        public virtual void AddGem(Gem gem, int index)
        {
            if (index < 0 || index >= this.Sockets.Length)
            {
                return;
            }
            this.sockets[index] = gem;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= this.Sockets.Length)
            {
                return;
            }
            this.sockets[index] = null;
        }

        public void Print()
        {
            int minDamageBonus = 0;
            int maxDamageBonus = 0;
            int totalAgility = 0;
            int totalStrength = 0;
            int totalVitality = 0;

            var gems = this.sockets.Where(x => x != null);
            foreach (var gem in gems)
            {
                minDamageBonus += gem.StrengthBonus*2 + gem.AgilityBonus;
                maxDamageBonus += gem.StrengthBonus*3 + gem.AgilityBonus*4;
                totalAgility += gem.AgilityBonus;
                totalStrength += gem.StrengthBonus;
                totalVitality += gem.VitalityBonus;
            }
            Console.WriteLine("{0}: {1}-{2} Damage, +{3} Strength, +{4} Agility, +{5} Vitality", 
                this.Name, this.MinDamage + minDamageBonus, this.MaxDamage + maxDamageBonus, totalStrength, totalAgility, totalVitality);

        }
    }
}