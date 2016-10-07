using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05KingsGambitExtended.Models;

namespace _05KingsGambitExtended
{
    public class SoldierDeathEventArgs : EventArgs
    {
        public SoldierDeathEventArgs(string name, KingUnderAttackEventHandler respondMethod)
        {
            this.Name = name;
            this.RespondMethod = respondMethod;
        }

        public string Name { get; private set; }

        public KingUnderAttackEventHandler RespondMethod { get; private set; }
    }
}
