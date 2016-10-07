using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05KingsGambitExtended.Models;

namespace _05KingsGambitExtended
{
    class KingsGambitExtended
    {
        static void Main(string[] args)
        {
            ModifiedDictionary soldiersByName = new ModifiedDictionary();
            King king = new King(Console.ReadLine());

            string[] guards = Console.ReadLine().Split();
            foreach (var guardName in guards)
            {
                RoyalGuard newGuard = new RoyalGuard(guardName);
                soldiersByName.Add(guardName, newGuard);
                newGuard.SoldierDeath += soldiersByName.HandleSoldierDeath;
                newGuard.SoldierDeath += king.OnSoldierDeath;
                king.KingAttacked += newGuard.OnKingUnderAttack;
            }

            string[] footmen = Console.ReadLine().Split();
            foreach (var footmanName in footmen)
            {
                Footman newFootman = new Footman(footmanName);
                soldiersByName.Add(footmanName, newFootman);
                newFootman.SoldierDeath += soldiersByName.HandleSoldierDeath;
                newFootman.SoldierDeath += king.OnSoldierDeath;
                king.KingAttacked += newFootman.OnKingUnderAttack;
            }

            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] parameters = line.Split();
                switch (parameters[0])
                {
                    case "Attack":
                        king.RespondToAttack();
                        break;
                    case "Kill":
                        Soldier soldierToRemove = soldiersByName[parameters[1]];
                        soldierToRemove.RespondToAttack();
                        break;
                }
                line = Console.ReadLine();
            }
        }
    }
}
