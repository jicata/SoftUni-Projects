using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WalkingGame
{
    using AnimationHandler;
    using AnimationHandling;
    using AnimationHandling.Animators;
    using Factories;
    using Handlers;
    using Handlers.InputHandler;

    public class Game1 : Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private CharacterEntity character;
        private CharacterAnimator characterAnimator;
        private FallingStuffAnimator fallingStuffAnimator;
        private PlayerInputHandler inputHandler;
        private CollisionHandler collisionHandler;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            AssetBufferer.BufferImages(this.Content);
            this.character = new CharacterEntity(this.GraphicsDevice);
            this.characterAnimator = new CharacterAnimator(this.character);
            this.inputHandler = new PlayerInputHandler(this.character);
            this.fallingStuffAnimator = new FallingStuffAnimator();
            this.collisionHandler = new CollisionHandler(this.character, this.fallingStuffAnimator.fallingEntites);
            this.graphics.PreferredBackBufferWidth = Globals.GLOBAL_WIDTH;
            this.graphics.PreferredBackBufferHeight = Globals.GLOBAL_HEIGHT;
            this.graphics.ApplyChanges();
            base.Initialize();
        }

       
        protected override void LoadContent()
        {
           
            spriteBatch = new SpriteBatch(GraphicsDevice);  
          
        }

     
        protected override void UnloadContent()
        {
       
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
                return;
            }

            var charMovement = this.inputHandler.Move(gameTime);
           this.collisionHandler.CheckForCollision();
            this.characterAnimator.UpdateAnimation(gameTime, charMovement);
            this.fallingStuffAnimator.UpdateAnimation(gameTime, Vector2.Zero);
            base.Update(gameTime);
            this.Window.Title = string.Format("X : {0} Y : {1} ", this.character.X,
                this.character.Y);
        }

  
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            if (this.character.livesLeft != 0)
            {
                this.spriteBatch.Begin();
                this.characterAnimator.Draw(this.spriteBatch);
                this.fallingStuffAnimator.Draw(this.spriteBatch);
                this.spriteBatch.End();
            }
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
