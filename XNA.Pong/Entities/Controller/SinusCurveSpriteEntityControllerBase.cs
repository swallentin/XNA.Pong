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
    public class SinusCurveSpriteEntityControllerBase:SpriteEntityControllerBase
    {
        private readonly IView _view;
        private readonly ISpriteEntity _spriteEntity;

        public SinusCurveSpriteEntityControllerBase(ISpriteEntity spriteEntity, IGameManager gameManager)
            : base(gameManager)
        {
            _spriteEntity = spriteEntity;
            _view = new SinusCurveSpriteEntityView(this, _spriteEntity);
        }

        #region Overrides of SpriteEntityControllerBase

        public override IView GetView()
        {
            return _view;
        }

        #endregion
    }
}
