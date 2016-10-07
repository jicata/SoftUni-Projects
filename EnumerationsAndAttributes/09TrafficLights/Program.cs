namespace _09TrafficLights
{
    using System;
    using System.Collections.Generic;

    public enum LightColor
    {
        Red,
        Green,
        Yellow
    }

    public class TrafficLight
    {
        private LightColor currentColor;

        public TrafficLight(LightColor currentColor)
        {
            this.currentColor = currentColor;
        }

        public LightColor CurrentColor
        {
            get
            {
                return currentColor;
            }
        }

        public void ChangeColor()
        {
            int color = (int)this.currentColor;
            color = (color + 1) % 3;
            this.currentColor =(LightColor)Enum.Parse(typeof(LightColor),color.ToString());
        }
    }

    class Program
    {
        static void Main()
        {
            List<TrafficLight> trafficLights = new List<TrafficLight>();
            string[] inputColors = Console.ReadLine().Split();
            for (int i = 0; i < inputColors.Length; i++)
            {
                trafficLights.Add(new TrafficLight((LightColor)Enum.Parse(typeof(LightColor), inputColors[i])));
            }
            int numberOfRotations = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfRotations; i++)
            {
                foreach (var trafficLight in trafficLights)
                {
                    trafficLight.ChangeColor();
                    Console.Write(trafficLight.CurrentColor + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
