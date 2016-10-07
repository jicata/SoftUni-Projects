using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05KingsGambitExtended.Models
{
    public class RoyalGuard : Soldier
    {
        private const int RoyalGuardHits = 3;

        public RoyalGuard(string name) : base(name,RoyalGuardHits)
        {
        }

        public override void OnKingUnderAttack(object sender, EventArgs args)
        {
            Console.WriteLine("Royal Guard {0} is defending!", this.Name);
        }
    }
}
