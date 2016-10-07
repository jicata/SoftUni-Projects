namespace WalkingGame.Models.FallingObjects
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework.Graphics;

    public class HelpfulFallingObject : FallingObject
    {
        public HelpfulFallingObject(Texture2D texture, float x) : base(texture.Name, x, 0)
        {
            base.Texture = texture;
        }

        public override void ReactOnCollision(CharacterEntity character)
        {
            Task task = Task.Run(() => { Console.Beep(1500, 500); });
            if (character.livesLeft++ > 3)
            {
                character.livesLeft = 3;
            }
            else
            {
                character.livesLeft++;
            }         
        }

    }
}
