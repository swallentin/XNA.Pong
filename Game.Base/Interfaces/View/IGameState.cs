using Game.Base.Interfaces.Controller;
using Microsoft.Xna.Framework;

namespace Game.Base.Interfaces.View
{
    public interface IGameState
    {
        void LoadContent();
        void UnloadContent();
        void Update(GameTime gameTime);

        bool IsActive { get; set; }
        IGameManager GameManager { get; }
    }
}
