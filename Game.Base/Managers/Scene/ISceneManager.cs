using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;

namespace Game.Base.Managers.Scene
{
    public interface ISceneManager:IView
    {
        void Update(GameTime gameTime);
        void Add(IController controller);
        void Remove(IController controller);
    }
}