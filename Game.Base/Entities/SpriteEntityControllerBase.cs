using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;

namespace Game.Base.Entities
{
    public abstract class SpriteEntityControllerBase:IController
    {
        private readonly IGameManager _gameManager;

        protected SpriteEntityControllerBase(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        #region Implementation of IController

        public IGameManager GameManager
        {
            get { return _gameManager; }
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <returns></returns>
        public abstract IView GetView();

        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public virtual void Update(GameTime gameTime){}

        /// <summary>
        /// Loads the content.
        /// </summary>
        public virtual void LoadContent(){}

        /// <summary>
        /// Unloads the content.
        /// </summary>
        public virtual void UnloadContent(){}

        #endregion
    }
}
