using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;

namespace Game.Base.Interfaces
{
    public interface ISceneFactory
    {
        IGameManager GameManager { get; }
        IController CreateScene(string type);
    }
}