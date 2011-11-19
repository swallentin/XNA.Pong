using System;
using System.Collections.Generic;
using Game.Base;
using Microsoft.Xna.Framework;
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
    internal class EntityManager:DrawableGameComponent
    {
        #region Fields

        private readonly ContentManager _contentManager;
        private SpriteBatch _spriteBatch;
        private readonly Microsoft.Xna.Framework.Game _game;
        private CollisionManager _collisionManager;
        private IEntity player1;
        private IEntity player2;
        private IEntity ball;

        private List<IEntity> _entities;

        #endregion

        #region Ctors

        public EntityManager(ContentManager contentManager, Microsoft.Xna.Framework.Game game) : base(game)
        {
            _contentManager = contentManager;
            _entities = new List<IEntity>();
            _collisionManager = new CollisionManager();
        }

        #endregion


        #region Methods

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
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
            if( type == "Padel1")
            {
                entity = EntityFactory.Instance.CreateSprite("Padel");

                PadelConfiguration padelConfiguration = _contentManager.Load<PadelConfiguration>("Padel.Config");
                entity.LoadContent(_contentManager, padelConfiguration.AssetName);
                entity.Scale = padelConfiguration.Scale;
                entity.Position = new Vector2(padelConfiguration.Position, (Game.GraphicsDevice.Viewport.Height / 2)-(entity.Size.Height/2) );
                entity.Input = new Player1KeyboardInput();
                entity.Name = "Player1";
                player1 = entity;
            }

            if (type == "Padel2")
            {
                entity = EntityFactory.Instance.CreateSprite("Padel");
                PadelConfiguration padelConfiguration = _contentManager.Load<PadelConfiguration>("Padel.Config");
                entity.LoadContent(_contentManager, padelConfiguration.AssetName);
                entity.Scale = padelConfiguration.Scale;
                entity.Position = new Vector2(Game.GraphicsDevice.Viewport.Width - entity.Size.Width - padelConfiguration.Position, (Game.GraphicsDevice.Viewport.Height / 2) - (entity.Size.Height / 2));
                entity.Input = new Player2KeyboardInput();
                entity.Name = "Player2";
                player2 = entity;
            }

            if( type == "Ball")
            {
                entity = EntityFactory.Instance.CreateSprite("Ball");
                BallConfiguration ballConfiguration = _contentManager.Load<BallConfiguration>("Ball.Config");
                entity.LoadContent(_contentManager, ballConfiguration.AssetName);
                entity.Scale = ballConfiguration.Scale;
                entity.Position = new Vector2((Game.GraphicsDevice.Viewport.Width / 2) - (entity.Size.Width / 2), (Game.GraphicsDevice.Viewport.Height / 2) - (entity.Size.Height / 2));
                BallInput input = new BallInput();
                _collisionManager.Collision += new CollisionEventHandler(input.BallInput_Collision);
                entity.Input = input;
                ball = entity;
            }
            if( type== "WallUpper")
            {
                
            }
            
            if( type == "WallLower")
            {
                
            }
            

            _entities.Add(entity);
        }

        

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            foreach (IEntity entity in _entities)
            {
                _spriteBatch.Draw(entity.SpriteTexture, entity.Position, entity.Source,entity.Color, entity.Rotation, entity.Origin,entity.Scale,SpriteEffects.None, 0);
            }
            _spriteBatch.End();
        }


        public override void Update(GameTime gameTime)
        {
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

            _collisionManager.PerformCollisionCheck(player1, ball);
            _collisionManager.PerformCollisionCheck(player2, ball);

        }


        #endregion
    }

    public delegate void CollisionEventHandler(object sender, CollisionEventArgs s);

    public class CollisionManager
    {
        public event CollisionEventHandler Collision;

        protected virtual void OnCollision(CollisionEventArgs s)
        {

            // insert code so that event is only triggered to correct entities
            if( Collision != null)
            {
                Collision(this, s);
            }
        }

        public void PerformCollisionCheck(IEntity entityA, IEntity entityB)
        {
            Rectangle a = GetBoundingBox(entityA);
            Rectangle b = GetBoundingBox(entityB);

            if( PerformCollisionCheck(a, b) )
            {
                Collision(null, new CollisionEventArgs(entityA, entityB));
            }
        }

        public bool PerformCollisionCheck(Rectangle a, Rectangle b)
        {
            return a.Intersects(b);
        }

        public Rectangle GetBoundingBox(IEntity entity)
        {
            return new Rectangle((int)entity.Position.X, (int)entity.Position.Y, entity.Size.Width, entity.Size.Height);
        }


    }
}
