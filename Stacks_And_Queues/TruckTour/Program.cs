namespace TruckTour
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Queue<GasPump> pumps = new Queue<GasPump>();


            for (int i = 0; i < n; i++)
            {
                string[] pumpArgs = Console.ReadLine().Split();
                pumps.Enqueue(new GasPump(int.Parse(pumpArgs[0]), int.Parse(pumpArgs[1])));
            }
            GasPump starterPump = null;
            bool tvaE = false;
            int gasInTank = 0;
            int indexOfPump = 0;    
            int counter = 0;
            int counterAddUp = 1;

            while (pumps.Count > 0|| counter >= pumps.Count)
            {
                var currentPump = pumps.Dequeue();
                starterPump = currentPump;
                pumps.Enqueue(currentPump);
                gasInTank += currentPump.amountOfGas;
                while (gasInTank >= currentPump.distanceToNext)
                {
                    gasInTank -= currentPump.distanceToNext;
                    currentPump = pumps.Dequeue();
                    counterAddUp++;
                    if (currentPump == starterPump)
                    {
                        tvaE = true;
                        break;
                    }
                    pumps.Enqueue(currentPump);
                    gasInTank += currentPump.amountOfGas;
                    
                }
                if (tvaE)
                {
                    break;
                }
                gasInTank = 0;
                counter += counterAddUp;
                counterAddUp = 1;
            }
            Console.WriteLine(counter);
        }
    }

    public class GasPump
    {
        public int amountOfGas;
        public int distanceToNext;

        public GasPump(int amountOfGas, int distanceToNext)
        {
            this.amountOfGas = amountOfGas;
            this.distanceToNext = distanceToNext;
        }

        public override string ToString()
        {
            string info = string.Format("GAS: {0}; DISTANCE{1}", this.amountOfGas, this.distanceToNext);
            return info;
        }
    }
}
