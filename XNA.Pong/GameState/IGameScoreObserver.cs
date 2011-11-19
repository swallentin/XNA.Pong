using Microsoft.Xna.Framework;

namespace XNA.Pong.GameState
{
    public interface IGameScoreObserver
    {
        void Notification(PlayerIndex playerIndex);
    }
}