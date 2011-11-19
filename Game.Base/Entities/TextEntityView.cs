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
    public class TextEntityView:IView
    {
        public IController Controller { get; set; }
        public ITextEntity Model { get; set; }

        public TextEntityView(IController controller, ITextEntity model)
        {
            Controller = controller;
            Model = model;
        }

        #region Implementation of IView

        public ISpriteEntity[] GetSpriteEntitiesToRender(GameTime gameTime)
        {
            return null;
        }

        public ITextEntity[] GetTextEntitiesToRender(GameTime gameTime)
        {
            return new [] {Model };
        }

        #endregion
    }
}
