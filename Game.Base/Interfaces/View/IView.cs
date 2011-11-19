using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;

namespace Game.Base.Interfaces.View
{
    public interface IView
    {
        ISpriteEntity[] GetSpriteEntitiesToRender(GameTime gameTime);
        ITextEntity[] GetTextEntitiesToRender(GameTime gameTime);
    }
}
