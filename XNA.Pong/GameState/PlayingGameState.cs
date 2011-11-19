using System;
using Game.Base;
using Game.Base.Interfaces.Controller;
using Microsoft.Xna.Framework;
using XNA.Pong.Scenes;
using XNA.Pong.Scenes.View;

namespace XNA.Pong.GameState
{
    public class PlayingGameState : GameStateBase
    {

        #region Fields

        private IController _playingController;

        #endregion

        #region Ctors

        public PlayingGameState( IGameManager gameManager)
            : base( gameManager)
        {
            _playingController = GameManager.SceneFactory.CreateScene("Playing");
            GameManager.SceneManager.Add(_playingController);
        }

        #endregion

        #region Overrides of GameStateBase

        #endregion

        #region Overrides of GameStateBase

        public override void LoadContent()
        {
            _playingController.LoadContent();
        }

        public override void UnloadContent()
        {
            GameManager.SceneManager.Remove(_playingController);
            _playingController.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            _playingController.Update(gameTime);
        }

        #endregion
    }
}
