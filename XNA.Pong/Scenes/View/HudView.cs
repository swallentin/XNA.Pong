using System;
using System.Collections.Generic;
using Game.Base;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using XNA.Pong.GameState;
using XNA.Pong.Scenes.Controller;
using XNA.Pong.Scenes.Model;

namespace XNA.Pong.Scenes.View
{
    public class HudView : ViewBase
    {
        private IHUDScene _hudScene;
        private IController _hudSceneController;
        private List<ISpriteEntity> _spriteEntiesToRender;
        private List<ITextEntity> _textEntiesToRender;

        public HudView(IController controller, IHUDScene scene)
        {
            _hudSceneController = controller;
            _hudScene = scene;
            _spriteEntiesToRender = new List<ISpriteEntity>();
            _textEntiesToRender = new List<ITextEntity>();
        }

        #region Overrides of ViewBase

        public override ISpriteEntity[] GetSpriteEntitiesToRender(GameTime gameTime)
        {
            _spriteEntiesToRender.Clear();

            //_spriteEntiesToRender.AddRange(_hudSceneModel.Player1ScoreEntity.GetView().GetSpriteEntitiesToRender(gameTime));
            //_spriteEntiesToRender.AddRange(_hudSceneModel.Player2ScoreEntity.GetView().GetSpriteEntitiesToRender(gameTime));

            return _spriteEntiesToRender.ToArray();
        }

        public override ITextEntity[] GetTextEntitiesToRender(GameTime gameTime)
        {
            return null;
        }

        #endregion

        #region Implementation of IGameScoreObserver



        #endregion
    }
}