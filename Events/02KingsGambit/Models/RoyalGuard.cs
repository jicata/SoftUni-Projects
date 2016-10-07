using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02KingsGambit.Models
{
    public class RoyalGuard : Soldier
    {
        public RoyalGuard(string name) : base(name)
        {
        }

        public override void OnKingUnderAttack(object sender, EventArgs args)
        {
            Console.WriteLine("Royal Guard {0} is defending!", this.Name);
        }
    }
}
