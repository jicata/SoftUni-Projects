namespace WalkingGame.Models
{
    using Interfaces;
    using Microsoft.Xna.Framework;

    public abstract class FallingObject : GameObject, IFalling
    {
        public FallingObject(string name, float x, float y) : base(name, x, y)
        {
        }

        public virtual Rectangle GetBoundingBox()
        {
            return new Rectangle((int) this.X, (int) this.Y, this.Texture.Width, this.Texture.Height);
        }
        public abstract void ReactOnCollision(CharacterEntity character);

        
    }
}