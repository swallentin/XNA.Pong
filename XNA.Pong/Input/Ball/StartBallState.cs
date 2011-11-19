using System;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using XNA.Pong.Entities.Controller;

namespace XNA.Pong.Input.Ball
{
    public class StartBallState : IBallState
    {
        private Vector2 _velocity, _direction, _position;

        public StartBallState()
        {
            _position = new Vector2(400, 300);
            _direction = new Vector2(-0.5f, -0.3f);
            _velocity = new Vector2(300, 300);
        }

        public StartBallState(Vector2 direction)
        {
            _direction = direction;
            _position = new Vector2(400, 300);
            _velocity = new Vector2(300, 300);
        }

        public void Update(GameTime gameTime, BallController ballController)
        {
            ballController.Ball.Position = _position;
            ballController.Ball.Direction = _direction;
            ballController.Ball.Velocity = _velocity;
            ballController.State = new PlayingBallState();
        }
    }
}