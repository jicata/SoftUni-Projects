namespace WalkingGame.AnimationHandling
{
    using System;
    using System.Collections.Generic;
    using AnimationHandler;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class CharacterAnimator : Animator
    {
        private CharacterEntity character;
        List<Animation> animations = new List<Animation>();
        public Animation currentAnimation;
        public CharacterAnimator(CharacterEntity character)
        {
            this.character = character;
            this.BufferFrames();
        }

      
        public override void UpdateAnimation(GameTime gameTime,Vector2 velocity)
        {
            if (velocity != Vector2.Zero)
            {
                bool movingHorizontally = Math.Abs(velocity.X) > Math.Abs(velocity.Y);
                if (movingHorizontally)
                {
                    if (velocity.X > 0)
                    {
                        currentAnimation = this.animations.Find(x=>x.Name == "WalkRight");
                    }
                    else
                    {
                        currentAnimation = this.animations.Find(x => x.Name == "WalkLeft");
                    }
                }
                else
                {
                    if (velocity.Y > 0)
                    {
                        currentAnimation = this.animations.Find(x => x.Name == "WalkDown");
                    }
                    else
                    {
                        currentAnimation = this.animations.Find(x => x.Name == "WalkUp");
                    }
                }
            }
            else
            {
                // If the character was walking, we can set the standing animation
                // according to the walking animation that is playing:
                if (currentAnimation == null)
                {
                    currentAnimation = this.animations.Find(x => x.Name == "StandDown");
                }
                else if (currentAnimation.Name == "WalkRight")
                {
                    currentAnimation = this.animations.Find(x => x.Name == "StandRight");
                }
                else if (currentAnimation.Name == "WalkLeft")
                {
                    currentAnimation = this.animations.Find(x => x.Name == "StandLeft");
                }
                else if (currentAnimation.Name == "WalkUp")
                {
                    currentAnimation = this.animations.Find(x => x.Name == "StandUp");
                }
                else if (currentAnimation.Name == "WalkDown")
                {
                    currentAnimation = this.animations.Find(x => x.Name == "StandDown");
                }
                

                // if none of the above code hit then the character
                // is already standing, so no need to change the animation.
            }


            currentAnimation.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 topLeftPos = new Vector2(this.character.X, this.character.Y);
            Color tint = Color.White;

            var sourceRectangle = this.currentAnimation.CurrentRectangle;

            spriteBatch.Draw(this.character.Texture, topLeftPos, sourceRectangle, tint);
        }

        public override void BufferFrames()
        {
            var walkDown = new Animation("WalkDown");
            walkDown.AddFrame(new Rectangle(0, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(16, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(0, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(32, 0, 16, 16), TimeSpan.FromSeconds(.25));
            

            var walkUp = new Animation("WalkUp");
            walkUp.AddFrame(new Rectangle(144, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(160, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(144, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(176, 0, 16, 16), TimeSpan.FromSeconds(.25));

            var walkLeft = new Animation("WalkLeft");
            walkLeft.AddFrame(new Rectangle(48, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(64, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(48, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(80, 0, 16, 16), TimeSpan.FromSeconds(.25));

            var walkRight = new Animation("WalkRight");
            walkRight.AddFrame(new Rectangle(96, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(112, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(96, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(128, 0, 16, 16), TimeSpan.FromSeconds(.25));

            this.animations.Add(walkDown);
            this.animations.Add(walkUp);
            this.animations.Add(walkLeft);
            this.animations.Add(walkRight);

            // Standing animations only have a single frame of animation:
            var standDown = new Animation("StandDown");
            standDown.AddFrame(new Rectangle(0, 0, 16, 16), TimeSpan.FromSeconds(.25));

            var standUp = new Animation("StandUp");
            standUp.AddFrame(new Rectangle(144, 0, 16, 16), TimeSpan.FromSeconds(.25));

            var standLeft = new Animation("StandLeft");
            standLeft.AddFrame(new Rectangle(48, 0, 16, 16), TimeSpan.FromSeconds(.25));

            var standRight = new Animation("StandRight");
            standRight.AddFrame(new Rectangle(96, 0, 16, 16), TimeSpan.FromSeconds(.25));
        
            this.animations.Add(standDown);
            this.animations.Add(standUp);
            this.animations.Add(standLeft);
            this.animations.Add(standRight);
        }
    }
}
