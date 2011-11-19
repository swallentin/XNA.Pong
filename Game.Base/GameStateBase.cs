using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base.Interfaces;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;

namespace Game.Base
{
    public abstract class GameStateBase: IGameState
    {
        private readonly IGameManager _gameManager;
        
        protected GameStateBase( IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        #region Implementation of gameState

        public abstract void LoadContent();
        public abstract void UnloadContent();
        public abstract void Update(GameTime gameTime);

        public bool IsActive { get; set; }

        public IGameManager GameManager
        {
            get { return _gameManager; }
        }

        #endregion
    }
}
