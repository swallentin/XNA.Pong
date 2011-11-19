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
    public class PlayingSceneView:ViewBase
    {
        private IController _controller;
        private IPlayingScene _playingScene;
        private List<ISpriteEntity> _entities;
        
        public PlayingSceneView(IController controller, IPlayingScene playingScene)
        {
            _playingScene = playingScene;
            _controller = controller;
            _entities = new List<ISpriteEntity>();

        }

        #region Overrides of ViewBase

        public override ISpriteEntity[] GetSpriteEntitiesToRender(GameTime gameTime)
        {
            _entities.Clear();

            //_entities.Add(_playingScene.Background);
            _entities.AddRange(_playingScene.Player1.GetView().GetSpriteEntitiesToRender(gameTime));
            _entities.AddRange(_playingScene.Player2.GetView().GetSpriteEntitiesToRender(gameTime));
            _entities.AddRange(_playingScene.Ball.GetView().GetSpriteEntitiesToRender(gameTime));

            return _entities.ToArray();
        }

        public override ITextEntity[] GetTextEntitiesToRender(GameTime gameTime)
        {
            return new ITextEntity[]{};
        }

        #endregion
    }
}
