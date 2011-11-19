using Game.Base.Interfaces.Model;

namespace Game.Base.Interfaces.View
{
    public interface ISceneManager
    {
        ISpriteEntity[] GetSpriteEntitiesToRender();
        ITextEntity[] GetTextEntitiesToRender();
    }
}