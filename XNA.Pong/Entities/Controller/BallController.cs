using System;
using Game.Base;
using Game.Base.Entities;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using XNA.Pong.Entities.Model;
using XNA.Pong.Entities.View;
using XNA.Pong.Input.Ball;

namespace XNA.Pong.Entities.Controller
{
    public class BallController : SpriteEntityControllerBase, ICollisionObserver
    {
        protected IBallView View { get; set; }
        public IBall Ball { get; set; }
        public IGameManager GameManager { get; set; }


        public BallController(IBall spriteEntity, IBallState ballState, IGameManager gameManager)
        {
            Ball = spriteEntity;
            State = ballState;
            GameManager = gameManager;
        }

        public override IView GetView()
        {
            return View;
        }

        public override void LoadContent()
        {
            Ball.Scored = GameManager.ContentManager.Load<SoundEffect>("Supporters");
            Ball.Bounce = GameManager.ContentManager.Load<SoundEffect>("Bounce");
            GameManager.CollisionManager.RegisterCollisionObserver(Ball.Name, this);
        }

        public override void Update(GameTime gameTime)
        {
            State.Update(gameTime, this);
            Ball.MoveBall(gameTime);
        }

        public IBallState State
        {
            get; set; 
        }


        public void CollisionNotification(ISpriteEntity collidingWithSpriteEntity)
        {
            if (collidingWithSpriteEntity.Name == "Player1" || collidingWithSpriteEntity.Name == "Player2")
            {
                Ball.Direction = new Vector2(Ball.Direction.X * -1, Ball.Direction.Y);
                Ball.PlayBounce();
                return;
            }
        }
    }
}
