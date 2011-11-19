using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base.Entities;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using XNA.Pong.Entities.View;

namespace XNA.Pong.Entities.Controller
{
    public class SpriteController:SpriteEntityControllerBase
    {
        private ISpriteEntity _model;
        private IView _view;

        public SpriteController(ISpriteEntity mode, IGameManager gameManager) : base(gameManager)
        {
            _model = mode;
            _view = new SpriteView(this, _model);
        }

        #region Overrides of SpriteEntityControllerBase

        public override IView GetView()
        {
            return _view;
        }

        #endregion
    }
}
