using Game.Base.Interfaces;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Base
{
    public abstract class ViewBase:IView
    {
        #region Implementation of IView

        public abstract ISpriteEntity[] GetSpriteEntitiesToRender(GameTime gameTime);
        public abstract ITextEntity[] GetTextEntitiesToRender(GameTime gameTime);

        #endregion
    }
}