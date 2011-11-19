using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using XNA.Pong.Scenes.Model;

namespace XNA.Pong.Scenes.View
{
    public class MainMenuSceneView : ViewBase
    {
        private IMainMenuScene _model;
        private IController _controller;

        public MainMenuSceneView(IController controller, IMainMenuScene model)
        {
            _model = model;
            _controller = controller;
        }
        
        #region Overrides of ViewBase

        public override ISpriteEntity[] GetSpriteEntitiesToRender(GameTime gameTime)
        {
            return new ISpriteEntity[]{_model.Background};
        }

        public override ITextEntity[] GetTextEntitiesToRender(GameTime gameTime)
        {
            return _model.MenuItems.ToArray();
        }

        #endregion
    }
}
