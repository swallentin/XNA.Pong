using Game.Base;

using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using XNA.Pong.GameState;
using XNA.Pong.Scenes;
using IGameComponent = Microsoft.Xna.Framework.IGameComponent;
using IGameState = Game.Base.Interfaces.View.IGameState;

namespace XNA.Pong
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class PongGame : GameBase
    {
        public PongGame()
        {
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            ((IGameManager)Services.GetService(typeof(IGameManager))).PushState(new MainMenuGameState(GameManager));
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering Controller, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GameManager.GraphicsDeviceManager.GraphicsDevice.Clear(Color.Black);
            //SpriteBatch _spriteBatch = new SpriteBatch(GameManager.GraphicsDeviceManager.GraphicsDevice);
            //ISpriteEntity sprite = GameManager.SpriteEntityFactory.CreateSprite("MainMenuBackground");

            //GameManager.GraphicsDeviceManager.GraphicsDevice.Clear(Color.Cyan);
            
            //SpriteBatch _spriteBatch = new SpriteBatch(GameManager.GraphicsDeviceManager.GraphicsDevice);
            //ISpriteEntity sprite = GameManager.SpriteEntityFactory.CreateSprite("MainMenuBackground");
            
            //_spriteBatch.Begin();
            //_spriteBatch.Draw(sprite.Texture, sprite.Position, Color.Blue);
            //_spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
