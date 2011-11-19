using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;

namespace Game.Base.Entities
{
    public abstract class SpriteEntityView:IView
    {
        #region Implementation of IView

        /// <summary>
        /// Gets the sprite entities to render.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <returns></returns>
        public abstract ISpriteEntity[] GetSpriteEntitiesToRender(GameTime gameTime);

        /// <summary>
        /// Gets the text entities to render.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <returns></returns>
        public abstract ITextEntity[] GetTextEntitiesToRender(GameTime gameTime);

        #endregion
    }
}
