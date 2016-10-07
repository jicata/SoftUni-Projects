using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02KingsGambit.Models;

namespace _02KingsGambit
{
    class KingsGambit
    {
        static void Main(string[] args)
        {
            Dictionary<string, Soldier> soldiersByName = new Dictionary<string, Soldier>();
            King king = new King(Console.ReadLine());

            string[] guards = Console.ReadLine().Split();
            foreach (var guardName in guards)
            {
                RoyalGuard newGuard = new RoyalGuard(guardName);
                soldiersByName.Add(guardName,newGuard);
                king.KingAttacked += newGuard.OnKingUnderAttack;
            }

            string[] footmen = Console.ReadLine().Split();
            foreach (var footmanName in footmen)
            {
                Footman newFootman = new Footman(footmanName);
                soldiersByName.Add(footmanName, newFootman);
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
                        king.KingAttacked -= soldierToRemove.OnKingUnderAttack;
                        soldiersByName.Remove(parameters[1]);
                        break;
                }
                line = Console.ReadLine();
            }
        }
    }
}
