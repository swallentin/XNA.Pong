using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using XNA.Pong.Entities.Controller.Ball;
using XNA.Pong.Entities.Model.Ball;

namespace XNA.Pong.Entities.View.Ball
{
    public class BallView:IBallView
    {
        private IBall Ball { get; set; }
        private BallController Controller { get; set; }


        public BallView(IBall ball, BallController controller)
        {
            Ball =ball;
            Controller  = controller;
        }


        public ISpriteEntity[] GetSpriteEntitiesToRender(GameTime gameTime)
        {
            return new[] {Ball.Sprite};
        }

        public ITextEntity[] GetTextEntitiesToRender(GameTime gameTime)
        {
            return null;
        }
    }
}
