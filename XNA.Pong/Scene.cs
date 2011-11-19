using System;
using System.Collections.Generic;
using Game.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using XNA.Pong;
using XNA.Pong.Configuration;
using XNA.Pong.Input;

namespace XNA.Pong
{
    /// <summary>
    /// 
    /// </summary>
    internal class Scene : DrawableGameComponent
    {
        #region Fields

        private IEntity player1;
        private IEntity player2;
        private IEntity ball;
        private IEntity background;
        private SoundEffect ballBounce;
        private ICamera2D camera;

        private List<IEntity> _entities;

        #endregion

        #region Ctors

        public Scene(Microsoft.Xna.Framework.Game game)
            : base(game)
        {
            _entities = new List<IEntity>();
            camera = new Camera2D(Game);
        }

        #endregion


        #region Methods

        protected override void LoadContent()
        {
            Game.Components.Add((IGameComponent)camera);
            Add("Background");
            Add("Padel1");
            Add("Padel2");
            Add("Ball");

            
            ballBounce = Game.Content.Load<SoundEffect>("Bounce");
            base.LoadContent();
        }

        /// <summary>
        /// Creates the sprite.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public void Add(string type)
        {
            IEntity entity = null;
            if (type == "Padel1")
            {
                entity = EntityFactory.CreateSprite("Padel");

                PadelConfiguration padelConfiguration = Game.Content.Load<PadelConfiguration>("Padel.Config");
                entity.LoadContent(padelConfiguration.AssetName);
                entity.Scale = padelConfiguration.Scale;
                entity.Position = new Vector2(padelConfiguration.Position, (Game.GraphicsDevice.Viewport.Height / 2) - (entity.Size.Height / 2));
                entity.Input = new Player1KeyboardInput();
                entity.Name = "Player1";
                player1 = entity;
                camera.Focus = player1 as IFocusable;

            }

            if (type == "Padel2")
            {
                entity = EntityFactory.CreateSprite("Padel");
                PadelConfiguration padelConfiguration = Game.Content.Load<PadelConfiguration>("Padel.Config");
                entity.LoadContent( padelConfiguration.AssetName);
                entity.Scale = padelConfiguration.Scale;
                entity.Position = new Vector2(Game.GraphicsDevice.Viewport.Width - entity.Size.Width - padelConfiguration.Position, (Game.GraphicsDevice.Viewport.Height / 2) - (entity.Size.Height / 2));
                entity.Input = new Player2KeyboardInput();
                entity.Name = "Player2";
                player2 = entity;
            }

            if (type == "Ball")
            {
                entity = EntityFactory.CreateSprite("Ball");
                BallConfiguration ballConfiguration = Game.Content.Load<BallConfiguration>("Ball.Config");
                entity.LoadContent( ballConfiguration.AssetName);
                entity.Scale = ballConfiguration.Scale;
                entity.Color = Color.Black;
                entity.Position = new Vector2((Game.GraphicsDevice.Viewport.Width / 2) - (entity.Size.Width / 2), (Game.GraphicsDevice.Viewport.Height / 2) - (entity.Size.Height / 2));
                BallInput input = new BallInput(new StartBallState());
                CollisionManager.Collision += new CollisionEventHandler(input.BallInput_Collision);
                entity.Input = input;
                ball = entity;
                
            }
            if (type == "Background")
            {
                entity = EntityFactory.CreateSprite("Background");
                entity.LoadContent("Grass");
                entity.Size = new Rectangle(0, 0, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height);
                background = entity;
            }

            _entities.Add(entity);
        }


        private SpriteBatch _spriteBatch;
        public SpriteBatch SpriteBatch
        {
            get
            {
                if( _spriteBatch == null)
                {
                    _spriteBatch = (SpriteBatch) Game.Services.GetService(typeof (SpriteBatch));
                }
                return _spriteBatch;
            }
        }

        private CollisionManager _collisionManager;
        public CollisionManager CollisionManager
        {
            get
            {
                if( _collisionManager == null )
                {
                    _collisionManager = (CollisionManager) Game.Services.GetService(typeof (CollisionManager));
                }
                return _collisionManager;
            }
        }

        private IEntityFactory _entityFactory;
        public IEntityFactory EntityFactory
        {
            get
            {
                if (_entityFactory == null)
                {
                    _entityFactory = (IEntityFactory)Game.Services.GetService(typeof(IEntityFactory));
                }
                return _entityFactory;  
            }
        }


        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.BackToFront, SaveStateMode.SaveState, camera.Transform);
            foreach (IEntity entity in _entities)
            {
                SpriteBatch.Draw(entity.SpriteTexture, entity.Position, entity.Source, entity.Color, entity.Rotation, entity.Origin, entity.Scale, SpriteEffects.None, 0);
            }
            SpriteBatch.End();
        }


        public override void Update(GameTime gameTime)
        {
            //camera.Focus = ball as IFocusable;

            foreach (IEntity entity in _entities)
            {
                entity.Update(gameTime);
            }
            
            // Perform collisions detection and delegate it
            // entities collision detection

            //for (int i = 0; i < _entities.Count-1; i++)
            //{
            //    _collisionManager.PerformCollisionCheck(_entities[i], _entities[i + 1]);
            //}

            CollisionManager.PerformCollisionCheck(ball, player1);
            CollisionManager.PerformCollisionCheck(ball, player2);



            

        }


        #endregion
    }
}
