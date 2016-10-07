namespace WalkingGame.AnimationHandling.Animators
{
    using System;
    using System.Collections.Generic;
    using AnimationHandler;
    using Factories;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Models;

    public class FallingStuffAnimator : Animator
    {
        public List<FallingObject> fallingEntites = new List<FallingObject>(); 
        

        public FallingStuffAnimator()
        {
            
        }
        public override void UpdateAnimation(GameTime gameTime, Vector2 velocity)
        {
            var rand = new Random().Next(2);
            List<FallingObject> outOfScreenObjects = new List<FallingObject>();
            var entity = FallingEntityFactory.ProduceEntity(gameTime);
            if (entity != null)
            {
                this.fallingEntites.Add(entity);
            }
            foreach (var fallingEntite in this.fallingEntites)
            {
                fallingEntite.Y++;
                if (fallingEntite.Y > Globals.GLOBAL_HEIGHT)
                {
                    outOfScreenObjects.Add(fallingEntite);
                }
            }
            foreach (var outOfScreenObject in outOfScreenObjects)
            {
                this.fallingEntites.Remove(outOfScreenObject);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var entity in this.fallingEntites)
            {
                Vector2 vector = new Vector2(entity.X, entity.Y);

                spriteBatch.Draw(entity.Texture, vector, Color.White);
            }
        }

        public override void BufferFrames()
        {
         

        }
    }
}
