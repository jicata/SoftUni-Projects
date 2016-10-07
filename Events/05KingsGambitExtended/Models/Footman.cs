using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05KingsGambitExtended.Models
{
    public class Footman : Soldier
    {
        private const int FootmanHits = 2;

        public Footman(string name) : base(name,FootmanHits)
        {
        }

        public override void OnKingUnderAttack(object sender, EventArgs args)
        {
            Console.WriteLine("Footman {0} is panicking!", this.Name);
        }
    }
}
