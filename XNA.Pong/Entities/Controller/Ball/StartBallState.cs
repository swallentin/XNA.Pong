using System;
using Game.Base.Helpers;
using Game.Base.Interfaces.Controller;
using Microsoft.Xna.Framework;

namespace XNA.Pong.Entities.Controller.Ball
{
    public class StartBallState : IBallState
    {
        private IBallController _controller;
        private IGameManager _gameManager;
        private PlayerIndex _playerIndex;

        public StartBallState(IBallController controller, IGameManager gameManager, PlayerIndex playerIndex)
        {
            _controller = controller;
            _gameManager = gameManager;
            _playerIndex = playerIndex;
        }

        public void Update(GameTime gameTime )
        {
            _controller.Ball.Sprite.Position = SpriteHelper.GetAbsolutePosition( new Vector2(0.5f, 0.5f), _gameManager.GraphicsDeviceManager);
            if( PlayerIndex.One.Equals(_playerIndex))
            {
                _controller.Ball.Sprite.Direction = new Vector2(-0.5f, -0.5f);
            }
            else if( PlayerIndex.Two.Equals(_playerIndex))
            {
                _controller.Ball.Sprite.Direction = new Vector2(0.5f, 0.5f);
            }
            _controller.State = new PlayingBallState(_controller, _gameManager);
        }

    }
}