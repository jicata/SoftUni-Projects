namespace _10InfernoInfinity
{
    using System;
    using Gems;

    public class GemFactory
    {
        public Gem ProduceGem(string commandArg)
        {
            string[] typeAndClarity = commandArg.Split();
            GemClarity clarity = (GemClarity) Enum.Parse(typeof(GemClarity), typeAndClarity[0]);
            switch (typeAndClarity[1])
            {
                case "Ruby":
                    return new Ruby(clarity);
                    break;
                case "Emerald":
                    return new Emerald(clarity);
                    break;
                case "Amethyst":
                    return new Amethyst(clarity);
                default:
                    return null;
            }
        }
    }
}
