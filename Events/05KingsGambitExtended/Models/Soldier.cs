using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05KingsGambitExtended.Interfaces;

namespace _05KingsGambitExtended.Models
{
    public delegate void SoldierDeathEventHandler(object sender, SoldierDeathEventArgs args);

    public abstract class Soldier : IAttackable
    {
        public event SoldierDeathEventHandler SoldierDeath;

        protected Soldier(string name,int hitsLeft)
        {
            this.Name = name;
            this.HitsLeft = hitsLeft;
        }

        public string Name { get; private set; }

        protected int HitsLeft { get; set; }

        public abstract void OnKingUnderAttack(object sender, EventArgs args);

        public void RespondToAttack()
        {
            this.HitsLeft--;
            if (this.HitsLeft == 0)
            {
                OnSoldierDeath(new SoldierDeathEventArgs(this.Name, OnKingUnderAttack));
            }
        }

        protected void OnSoldierDeath(SoldierDeathEventArgs args)
        {
            if (SoldierDeath != null)
            {
                SoldierDeath(this, args);
            }
        }
    }
}
