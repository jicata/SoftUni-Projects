using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02KingsGambit.Models
{
    public class Footman : Soldier
    {
        public Footman(string name) : base(name)
        {
        }

        public override void OnKingUnderAttack(object sender, EventArgs args)
        {
            Console.WriteLine("Footman {0} is panicking!",this.Name);
        }
    }
}
