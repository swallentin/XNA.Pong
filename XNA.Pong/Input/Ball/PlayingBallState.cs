using Game.Base.Interfaces.Controller;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNA.Pong.Entities.Controller;
using XNA.Pong.GameState;

namespace XNA.Pong.Input.Ball
{
    public class PlayingBallState : IBallState
    {
        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <param name="ballController">The ball controller.</param>
        public void Update(GameTime gameTime, BallController ballController)
        {
            // Using these variables for brevity of this code.
            // Hopefully the compiler will realise im not doing to good in my code and optimize this.

            ICollisionManager collisionManager = ballController.GameManager.CollisionManager;
            GraphicsDevice graphicsDevice = ballController.GameManager.GraphicsDevice;

            GameScore gameScore = ballController.GameManager["GameScore"] as GameScore;
            if (ballController.Ball.Position.X <= 0)
            {
                ballController.State = new PlayerScoredBallState(gameScore, PlayerIndex.Two);
                return;
            }

            if (ballController.Ball.Position.X >= graphicsDevice.Viewport.Width)
            {
                ballController.State = new PlayerScoredBallState(gameScore, PlayerIndex.One);
                return;
            }

            if (ballController.Ball.Position.Y < 0 || ballController.Ball.Position.Y + ballController.Ball.Size.Height > 800)
            {
                ballController.Ball.Direction = new Vector2(ballController.Ball.Direction.X, -ballController.Ball.Direction.Y);
                ballController.Ball.PlayBounce();
                return;
            }
            
            // Manual collision detection without using the ICollisionObserver pattern, we use this cause we don't have an entity to check collision against.
            if (collisionManager.PerformCollisionCheck(collisionManager.GetBoundingBox(ballController.Ball),
                                                       new Rectangle(0, 0, graphicsDevice.Viewport.Width, 0))
                ||
                collisionManager.PerformCollisionCheck(collisionManager.GetBoundingBox(ballController.Ball),
                                                       new Rectangle(0, graphicsDevice.Viewport.Height, graphicsDevice.Viewport.Width, 0)))
            {
                ballController.Ball.Direction = new Vector2(ballController.Ball.Direction.X, ballController.Ball.Direction.Y * -1);
                ballController.Ball.PlayBounce();
                return;
            }
        }
    }
}