namespace WalkingGame
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Models;

    public class CharacterEntity : GameObject
    {
        public int livesLeft = 3;   
        public CharacterEntity(GraphicsDevice graphicsDevice) 
            : base("Character", Globals.GLOBAL_WIDTH / 2, Globals.GLOBAL_HEIGHT - 16)
        {
            if (base.Texture == null)
            {
                using (var stream = TitleContainer.OpenStream("Content/charactersheet.png"))
                {
                    base.Texture = Texture2D.FromStream(graphicsDevice, stream);
                }
            }
        }
    }
}
