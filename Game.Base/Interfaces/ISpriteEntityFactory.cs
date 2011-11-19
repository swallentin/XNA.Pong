using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;

namespace Game.Base.Interfaces
{
    public interface ISpriteEntityFactory
    {
        IGameManager GameManager { get; }
        IController CreateSpriteController(string type);
        ISpriteEntity CreateSprite(string type);
    }
}
