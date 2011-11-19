using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base.Entities;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;

namespace XNA.Pong.Entities.View
{
    public class SpriteView:SpriteEntityView
    {
        private IController _controller;
        private ISpriteEntity _model;

        public SpriteView(IController controller, ISpriteEntity spriteEntity)
        {
            _controller = controller;
            _model = spriteEntity;
        }

        #region Overrides of SpriteEntityView

        public override ISpriteEntity[] GetSpriteEntitiesToRender(GameTime gameTime)
        {
            return new []{_model};
        }

        public override ITextEntity[] GetTextEntitiesToRender(GameTime gameTime)
        {
            return null;
        }

        #endregion
    }
}
