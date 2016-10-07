using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02KingsGambit.Interfaces;

namespace _02KingsGambit.Models
{
    public delegate void KingUnderAttackEventHandler(object sender, EventArgs args);

    class King : IAttackable
    {
        public event KingUnderAttackEventHandler KingAttacked;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void RespondToAttack()
        {
            Console.WriteLine("King {0} is under attack!",this.Name);
            OnKingAttacked(new EventArgs());
        }

        protected void OnKingAttacked(EventArgs args)
        {
            if (KingAttacked != null)
            {
                KingAttacked(this, args);
            }
        }
    }
}
