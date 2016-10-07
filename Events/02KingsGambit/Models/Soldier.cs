using System;

namespace _02KingsGambit.Models
{
    public abstract class Soldier
    {
        protected Soldier(string name)
        {
            this.Name = name;
        }

        public string Name { get;private set; }

        public abstract void OnKingUnderAttack(object sender, EventArgs args);
    }
}
