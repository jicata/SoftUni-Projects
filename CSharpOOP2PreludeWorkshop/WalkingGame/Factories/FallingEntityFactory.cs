namespace WalkingGame.Factories
{
    using System;
    using System.IO;
    using AnimationHandling;
    using Microsoft.Xna.Framework;
    using Models;
    using Models.FallingObjects;

    public static class FallingEntityFactory
    {
        private static double lastCall;
        private static int harmfulObjects;
        public static FallingObject ProduceEntity(GameTime gameTime)
        {
            int randomIndex = new Random().Next() % AssetBufferer.textures.Count;
            
            if (harmfulObjects < 10)
            {
                if (lastCall + 0.5 <= gameTime.TotalGameTime.TotalSeconds)
                {
                    lastCall = gameTime.TotalGameTime.TotalSeconds;
                    harmfulObjects++;
                    string random = Path.GetRandomFileName();
                    return new HarmfulFallingObject(AssetBufferer.textures[randomIndex],
                        new Random(random.GetHashCode()).Next(0, Globals.GLOBAL_WIDTH));
                }

            }
            else if(harmfulObjects >= 10 && lastCall + 0.5 <= gameTime.TotalGameTime.TotalSeconds)
            {
                harmfulObjects = 0;
                return new HelpfulFallingObject(AssetBufferer.specialTexture, new Random().Next(0, Globals.GLOBAL_WIDTH));
                
            }
            return null;


        }
    }
}
