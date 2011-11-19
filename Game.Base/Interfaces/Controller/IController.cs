using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;

namespace Game.Base.Interfaces.Controller
{
    public interface IController
    {
        IGameManager GameManager { get; }
        IView GetView();
        void Update(GameTime gameTime);
        void LoadContent();
        void UnloadContent();
    }
}
