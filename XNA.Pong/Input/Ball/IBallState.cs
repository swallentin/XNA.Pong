using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using XNA.Pong.Entities.Controller;

namespace XNA.Pong.Input.Ball
{
    public interface IBallState
    {
        void Update(GameTime gameTime, BallController ballController);
    }
}