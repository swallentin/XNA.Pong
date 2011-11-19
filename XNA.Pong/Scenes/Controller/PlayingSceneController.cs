using System;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;
using XNA.Pong.Entities.Controller.Ball;
using XNA.Pong.Entities.Controller.Padel;
using XNA.Pong.Entities.Model.Padel;
using XNA.Pong.Scenes.Model;
using XNA.Pong.Scenes.View;

namespace XNA.Pong.Scenes.Controller
{
    public class PlayingSceneController:IController
    {
        private readonly IView _playingView;
        private IPlayingScene _model;
        
        public PlayingSceneController(IPlayingScene model, IGameManager gameManager)
        {
            _gameManager = gameManager;
            _playingView = new PlayingSceneView(this, model);
            _model = model;
        }

        #region Implementation of IController

        private readonly IGameManager _gameManager;
        
        public IGameManager GameManager
        {
            get { return _gameManager; }
        }

        public IView GetView()
        {
            return _playingView;
        }

        public void Update(GameTime gameTime)
        {
            _model.Player1.Update(gameTime);
            _model.Player2.Update(gameTime);
            _model.Ball.Update(gameTime);
        }

        public void LoadContent()
        {
            _model.Background = GameManager.SpriteEntityFactory.CreateSprite("Background");
            _model.Player1 = GameManager.SpriteEntityFactory.CreateSpriteController("Padel1");
            _model.Player1.LoadContent();

            _model.Player2 = GameManager.SpriteEntityFactory.CreateSpriteController("AIPadel");
            _model.Player2.LoadContent();

            _model.Ball = GameManager.SpriteEntityFactory.CreateSpriteController("Ball");
            _model.Ball.LoadContent();

            if (_model.Player2 is AIInputController)
            {
                ((AIInputController) _model.Player2).Ball = ((IBallController) _model.Ball).Ball;
            }
        }

        public void UnloadContent()
        {
        }

        #endregion
    }
}