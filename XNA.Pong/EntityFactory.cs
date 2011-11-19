using System;
using Game.Base;
using Game.Base.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using XNA.Pong.Configuration;
using XNA.Pong.Entities;
using XNA.Pong.Input;

namespace XNA.Pong
{
    internal sealed class EntityFactory : GameComponent, IEntityFactory
    {

        #region Ctors

        public EntityFactory(Microsoft.Xna.Framework.Game game):base(game)
        {
        }

        #endregion

        #region Properties

        private ICollisionManager _collisionManager;
        /// <summary>
        /// Gets the collision manager.
        /// </summary>
        /// <value>The collision manager.</value>
        public ICollisionManager CollisionManager
        {
            get
            {
                return _collisionManager ?? (_collisionManager = (ICollisionManager)Game.Services.GetService(typeof(ICollisionManager)));
            }
        }

        private ISpriteGraphics _spriteGraphics;
        private ISpriteGraphics SpriteGraphics
        {
            get
            {
                return _spriteGraphics ?? (_spriteGraphics = (ISpriteGraphics)Game.Services.GetService(typeof(ISpriteGraphics)));
            }
        }

        #endregion

        /// <summary>
        /// Creates the sprite.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public ISpriteEntity CreateSprite(string type)
        {
            ISpriteEntity spriteEntity = null;
            if (type == "Padel1")
            {
                spriteEntity = CreatePadel();

                PadelConfiguration padelConfiguration = Game.Content.Load<PadelConfiguration>("Padel.Config");
                //spriteEntity.SpriteTexture = _textureManager.GetTexture("PlanetBeam");
                spriteEntity.LoadContent(padelConfiguration.AssetName);
                spriteEntity.Scale = padelConfiguration.Scale;
                spriteEntity.Position = new Vector2(padelConfiguration.Position, (Game.GraphicsDevice.Viewport.Height / 2) - (spriteEntity.Size.Height / 2));
                spriteEntity.Input = new Player1KeyboardInput();
                spriteEntity.Name = "Player1";
                
            }

            if (type == "Padel2")
            {
                spriteEntity = CreatePadel();
                PadelConfiguration padelConfiguration = Game.Content.Load<PadelConfiguration>("Padel.Config");
                spriteEntity.LoadContent(padelConfiguration.AssetName);
                spriteEntity.Scale = padelConfiguration.Scale;
                spriteEntity.Position = new Vector2(Game.GraphicsDevice.Viewport.Width - spriteEntity.Size.Width - padelConfiguration.Position, (Game.GraphicsDevice.Viewport.Height / 2) - (spriteEntity.Size.Height / 2));
                spriteEntity.Input = new Player2KeyboardInput();
                spriteEntity.Name = "Player2";
            }

            if (type == "Ball")
            {
                spriteEntity = CreateBall();
                BallConfiguration ballConfiguration = Game.Content.Load<BallConfiguration>("Ball.Config");
                spriteEntity.LoadContent(ballConfiguration.AssetName);
                spriteEntity.Scale = ballConfiguration.Scale;
                spriteEntity.Color = Color.Cyan;
                spriteEntity.Position = new Vector2((Game.GraphicsDevice.Viewport.Width / 2) - (spriteEntity.Size.Width / 2), (Game.GraphicsDevice.Viewport.Height / 2) - (spriteEntity.Size.Height / 2));
                BallInput input = new BallInput(new StartBallState());
                CollisionManager.Collision += new CollisionEventHandler(input.BallInput_Collision);
                spriteEntity.Input = input;
            }

            if( type == "MainBackground")
            {
                spriteEntity = CreateBackground();
                spriteEntity.LoadContent("Pong Title Screen");
                spriteEntity.Name = "TitleScreen";
            }

            if (type == "Background")
            {
                spriteEntity = CreateBackground();
                spriteEntity.LoadContent("Grass");
                spriteEntity.Size = new Rectangle(0, 0, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height);
            }

            if( type=="Circle")
            {
                spriteEntity = new SinusCurveSpriteEntity(new NullInput(), new NullGraphics(), Game);
                spriteEntity.LoadContent("Pixel");
                spriteEntity.Name = "Circle";
            }

            if( spriteEntity!=null)
            {
                spriteEntity.Graphics = SpriteGraphics;
            }

            return spriteEntity;
        }

        private ISpriteEntity CreatePadel()
        {
            return new SpriteEntity(new NullInput(), new NullGraphics(), Game);
        }

        private ISpriteEntity CreateBall()
        {
            return new SpriteEntity(new NullInput(), new NullGraphics(), Game);
        }
        private ISpriteEntity CreateBackground()
        {
            return new SpriteEntity(new NullInput(), new NullGraphics(), Game);
        }

        private ISpriteEntity CreateDefault()
        {
            return new SpriteEntity(new NullInput(), new NullGraphics(), Game);
        }
        
    }
}

  