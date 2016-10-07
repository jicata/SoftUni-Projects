namespace _05.SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Configuration;
    class Program
    {
        
        static void Main()
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] carDetails = line.Split();
                string model = carDetails[0];
                decimal fuelAmount = decimal.Parse(carDetails[1]);
                decimal fuelCost = decimal.Parse(carDetails[2]);
                cars.Add(new Car(model, fuelAmount, fuelCost));
            }
            string driveCommand = Console.ReadLine();
            while (driveCommand != "End")
            {
                string[] driveCommandDetails = driveCommand.Split();
                string model = driveCommandDetails[1];
                int distance = int.Parse(driveCommandDetails[2]);
                var car = cars.First(x => x.model == model);
                car.Drive(distance);
                driveCommand = Console.ReadLine();
            }
            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }

    class Car
    {
   
        public string model;
        public decimal fuelAmount;
        public decimal fuelCost;
        public int distanceTraveled = 0;

        public Car(string model, decimal fuelAmount, decimal fuelCost)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelCost = fuelCost;
        }

        public void Drive(int kilometers)
        {
            decimal fuelCost = this.fuelCost * kilometers;
            if (fuelCost > this.fuelAmount)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient fuel for the drive");
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                return;
            }
            this.distanceTraveled += kilometers;
            this.fuelAmount -= fuelCost;
        }

        public override string ToString()
        {
            return string.Format("{0} {1:f2} {2}", this.model, this.fuelAmount, this.distanceTraveled);
        }
    }
}
