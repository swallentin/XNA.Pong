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
    public abstract class TextEntityControllerBase:IController
    {
        public ITextEntity Model { get; set; }
        public IView View { get; set; }
        private IGameManager _gameManager;

        protected TextEntityControllerBase(ITextEntity textEntity, IGameManager gameManager)
        {
            Model = textEntity;
            _gameManager = gameManager;
        }
        
        #region Implementation of IController

        public IGameManager GameManager
        {
            get { return _gameManager; }
        }

        public virtual IView GetView()
        {
            return View ?? (View = new TextEntityView(this, Model));
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void LoadContent()
        {
            // perform load stuff on the model
        }

        public virtual void UnloadContent()
        {
            // perform unload stuff on the model
        }

        #endregion
    }
}
