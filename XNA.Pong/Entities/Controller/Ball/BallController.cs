using System;
using Game.Base.Entities;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using XNA.Pong.Entities.Model.Ball;
using XNA.Pong.Entities.View.Ball;
using XNA.Pong.GameState;

namespace XNA.Pong.Entities.Controller.Ball
{
    public interface IBallController
    {
        IBallState State { get; set; }
        IBall Ball { get; set; }
        GameScore GameScore { get; set; }
    }

    public class BallController : SpriteEntityControllerBase, ICollisionObserver, IBallController
    {
        protected IBallView View { get; set; }
        public IBall Ball { get; set; }

        public GameScore GameScore
        {
            get; set;
        }

        private bool _isLoaded = false;
        public IBallState State
        {
            get;
            set;
        }

        public BallController(IBall spriteEntity, IGameManager gameManager):base(gameManager)
        {
            Ball = spriteEntity;
            State = new StartBallState(this, gameManager, PlayerIndex.One);
            View = new BallView(Ball, this );
            GameScore = GameManager["GameScore"] as GameScore;
        }

        public override IView GetView()
        {
            return View;
        }

        public override void LoadContent()
        {
            if( _isLoaded )
            {
                return;
            }

            Ball.Scored = GameManager.ContentManager.Load<SoundEffect>("Supporters");
            Ball.Bounce = GameManager.ContentManager.Load<SoundEffect>("Bounce");

            GameManager.CollisionManager.RegisterCollisionObserver(Ball.Sprite.Name, this);
            GameManager.CollisionManager.RegisterCollision(Ball.Sprite);
            _isLoaded = true;
        }

        public override void UnloadContent()
        {
            GameManager.CollisionManager.UnRegisterCollisionObserver(this);
        }

        public override void Update(GameTime gameTime)
        {
            State.Update(gameTime);
            Ball.MoveBall(gameTime);
        }

        public void CollisionNotification(ISpriteEntity collidingWithSpriteEntity)
        {
            if (collidingWithSpriteEntity.Name == "Player1" || collidingWithSpriteEntity.Name == "Player2")
            {
                Ball.Sprite.Direction = new Vector2(Ball.Sprite.Direction.X * -1, Ball.Sprite.Direction.Y);
                Ball.PlayBounce();
                return;
            }
        }
    }
}
