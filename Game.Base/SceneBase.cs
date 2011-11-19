using System;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;

namespace Game.Base
{
    public abstract class SceneBase:IScene
    {
        private readonly Microsoft.Xna.Framework.Game _game;
        private IGameManager _gameManager;

        protected SceneBase(Microsoft.Xna.Framework.Game game)
        {
            _game = game;
        }

        #region Implementation of IModel

        /// <summary>
        /// Gets the game manager.
        /// </summary>
        /// <value>The game manager.</value>
        public IGameManager GameManager
        {
            get { return _gameManager ?? (_gameManager = _game.Services.GetService(typeof (IGameManager)) as IGameManager); }
        }

        public abstract void LoadContent();
        public abstract void UnloadContent();

        #endregion
    }
}