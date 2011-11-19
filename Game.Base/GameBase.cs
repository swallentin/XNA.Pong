using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Game.Base.Configuration;
using Game.Base.Interfaces.Controller;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Base
{
    public class GameBase:Microsoft.Xna.Framework.Game
    {
        public GameBase()
        {
            Services.AddService(typeof(GraphicsDeviceManager), new GraphicsDeviceManager(this));
            
        }

        protected override void Initialize()
        {
            Services.AddService(typeof(ContentManager), Content);

            PrepareManagers();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Services.AddService(typeof(SpriteBatch), new SpriteBatch(GameManager.GraphicsDeviceManager.GraphicsDevice));

            base.LoadContent();
        }

        private void PrepareManagers()
        {
            foreach (Manager manager in ConfigurationManager.Instance.Managers)
            {
                GameComponent baseManager =
                    ManagerActivator.CreateInstance(Type.GetType(manager.Value), this) as GameComponent;
                Components.Add(baseManager);
                Services.AddService(Type.GetType(manager.InterfaceType), baseManager);
            }
        }


        private IGameManager _gameManager;
        public IGameManager GameManager
        {
            get
            {
                return _gameManager ?? (_gameManager = (IGameManager)Services.GetService(typeof(IGameManager)));
            }
        }




    }
}
