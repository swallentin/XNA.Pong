using Game.Base.Interfaces.Controller;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNA.Pong.GameState;

namespace XNA.Pong.Entities.Controller.Ball
{
    public class PlayingBallState : IBallState
    {
        private IBallController _ballController;
        private IGameManager _gameManager;
        
        public PlayingBallState(IBallController ballController, IGameManager gameManager)
        {
            _ballController = ballController;
            _gameManager = gameManager;

        }
        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <param name="ballController">The ball controller.</param>
        public void Update(GameTime gameTime)
        {
            // Using these variables for brevity of this code.
            // Hopefully the compiler will realise im not doing to good in my code and optimize this.

            ICollisionManager collisionManager = _gameManager.CollisionManager;
            GraphicsDevice graphicsDevice = _gameManager.GraphicsDeviceManager.GraphicsDevice;

            GameScore gameScore = _gameManager["GameScore"] as GameScore;
            if (_ballController.Ball.Sprite.Position.X <= 0)
            {
                _ballController.State = new PlayerScoredBallState(_ballController, PlayerIndex.Two, _gameManager);
                return;
            }

            if (_ballController.Ball.Sprite.Position.X >= graphicsDevice.Viewport.Width)
            {
                _ballController.State = new PlayerScoredBallState(_ballController, PlayerIndex.One, _gameManager);
                return;
            }

            if (_ballController.Ball.Sprite.Position.Y < 0 || _ballController.Ball.Sprite.Position.Y + _ballController.Ball.Sprite.Size.Height > graphicsDevice.Viewport.Height)
            {
                _ballController.Ball.Sprite.Direction = new Vector2(_ballController.Ball.Sprite.Direction.X, -_ballController.Ball.Sprite.Direction.Y);
                _ballController.Ball.PlayBounce();
                _ballController.Ball.SpeedUp();
                return;
            }
            
            // Manual collision detection without using the ICollisionObserver pattern, we use this cause we don't have an entity to check collision against.
            if (collisionManager.PerformCollisionCheck(collisionManager.GetBoundingBox(_ballController.Ball.Sprite),
                                                       new Rectangle(0, 0, graphicsDevice.Viewport.Width, 0))
                ||
                collisionManager.PerformCollisionCheck(collisionManager.GetBoundingBox(_ballController.Ball.Sprite),
                                                       new Rectangle(0, graphicsDevice.Viewport.Height, graphicsDevice.Viewport.Width, 0)))
            {
                _ballController.Ball.Sprite.Direction = new Vector2(_ballController.Ball.Sprite.Direction.X, _ballController.Ball.Sprite.Direction.Y * -1);
                _ballController.Ball.PlayBounce();
                _ballController.Ball.SpeedUp();
                return;
            }
        }
    }
}