namespace WalkingGame.Models
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework.Graphics;

    public class HarmfulFallingObject: FallingObject
    {
        public HarmfulFallingObject(Texture2D texture, float x) : base(texture.Name, x, 0)
        {
            base.Texture = texture;
        }
        public override void ReactOnCollision(CharacterEntity character)
        {
            Task task = Task.Run(() => { Console.Beep(500, 500); });
            character.livesLeft --;
        }

        
    }
}
