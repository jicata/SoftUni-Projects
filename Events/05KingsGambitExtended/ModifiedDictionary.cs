using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05KingsGambitExtended.Models;

namespace _05KingsGambitExtended
{
    public class ModifiedDictionary : Dictionary<string,Soldier>
    {
        public void HandleSoldierDeath(object sender, SoldierDeathEventArgs args)
        {
            this.Remove(args.Name);
        }
    }
}
