namespace WalkingGame.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Models;

    public class CollisionHandler
    {
        private CharacterEntity character;
        List<FallingObject> fallingEntities;

        public CollisionHandler(CharacterEntity character, List<FallingObject> fallingEntities)
        {
            this.character = character;
            this.fallingEntities = fallingEntities;
        }

        public void CheckForCollision()
        {
            FallingObject entity = null;
            foreach (var fallingEntity in this.fallingEntities)
            {
               var rect = new Rectangle((int)this.character.X, (int)this.character.Y, 16,16);
                if (rect.Intersects(fallingEntity.GetBoundingBox()))
                {
                    
                    fallingEntity.ReactOnCollision(this.character);
                    entity = fallingEntity;
                    break;
                }
            }
            this.fallingEntities.Remove(entity);
        }
    }
}
