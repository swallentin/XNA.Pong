using Game.Base.Interfaces.Controller;
using Microsoft.Xna.Framework;
using XNA.Pong.GameState;

namespace XNA.Pong.Entities.Controller.Ball
{
    public class PlayerScoredBallState:IBallState
    {
        private const float ScoreWaitingDuration = 1.0f;
        private float _scoreCurrentWaitingFloat = 0.0f;
        protected GameScore GameScore;
        private readonly PlayerIndex _playerIndex;

        private IBallController _ballController;
        private IGameManager _gameManager;
        
        public PlayerScoredBallState(IBallController ballController, PlayerIndex playerIndex, IGameManager gameManager)
        {
            _ballController = ballController;
            _playerIndex = playerIndex;
            _gameManager = gameManager;
            GameScore = gameManager["GameScore"] as GameScore;
        }

        #region Implementation of IBallState

        public void Update(GameTime gameTime)
        {
            if (_scoreCurrentWaitingFloat == 0.0f)
            {
                _ballController.Ball.PlayScored();

                if (_playerIndex == PlayerIndex.One)
                {
                    GameScore.Player1++;
                }
                if (_playerIndex == PlayerIndex.Two)
                {
                    GameScore.Player2++;
                }
            }

            _scoreCurrentWaitingFloat += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_scoreCurrentWaitingFloat > ScoreWaitingDuration)
            {
                _ballController.State = new StartBallState(_ballController, _gameManager, _playerIndex);
            }
        }

        #endregion
    }
}