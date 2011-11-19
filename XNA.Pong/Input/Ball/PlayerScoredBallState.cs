using System;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using XNA.Pong.Entities.Controller;
using XNA.Pong.GameState;

namespace XNA.Pong.Input.Ball
{
    public class PlayerScoredBallState:IBallState
    {
        private const float ScoreWaitingDuration = 1.0f;
        private float _scoreCurrentWaitingFloat = 0.0f;
        protected GameScore GameScore;
        private readonly PlayerIndex _playerIndex;
        
        public PlayerScoredBallState(GameScore gameScore, PlayerIndex playerIndex)
        {
            _playerIndex = playerIndex;
            GameScore = gameScore;
        }

        #region Implementation of IBallState

        public void Update(GameTime gameTime, BallController ballController)
        {
            if (_scoreCurrentWaitingFloat == 0.0f)
            {
                ballController.Ball.PlayScored();

                if (_playerIndex == PlayerIndex.One)
                {
                    GameScore.Player1++;
                    ballController.Ball.Position = new Vector2(500, 500);
                    ballController.Ball.Direction = new Vector2(0.5f, 0.3f);
                    ballController.Ball.Velocity = Vector2.Zero;
                }
                if (_playerIndex == PlayerIndex.Two)
                {
                    GameScore.Player2++;
                    ballController.Ball.Position = new Vector2(500, 500);
                    ballController.Ball.Direction = new Vector2(-0.5f, -0.3f);
                    ballController.Ball.Velocity = Vector2.Zero;
                }
            }

            _scoreCurrentWaitingFloat += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_scoreCurrentWaitingFloat > ScoreWaitingDuration)
            {
                ballController.State = new StartBallState(ballController.Ball.Direction);
            }
        }

        #endregion
    }
}