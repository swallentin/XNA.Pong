using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base.Interfaces;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using XNA.Pong.Scenes.Controller;
using XNA.Pong.Scenes.Model;

namespace XNA.Pong
{
    public class SceneFactory:GameComponent,ISceneFactory
    {
        #region Implementation of ISceneFactory

        private IGameManager _gameManager;

        public SceneFactory(Microsoft.Xna.Framework.Game game) : base(game)
        {
        }

        /// <summary>
        /// Gets the collision manager.
        /// </summary>
        /// <value>The collision manager.</value>
        public IGameManager GameManager
        {
            get
            {
                return _gameManager ?? (_gameManager = (IGameManager)Game.Services.GetService(typeof(IGameManager)));
            }
        }

        public IController CreateScene(string type)
        {
            if( type == "Hud" )
            {
                IHUDScene scene = new HUDScene();
                IController controller = new HUDSceneController(scene, GameManager );
                controller.LoadContent();
                return controller;
            }

            if( type == "MainMenu")
            {
                IMainMenuScene mainMenuScene = new MainMenuScene();
                IController controller = new MainMenuSceneController(mainMenuScene, GameManager);
                controller.LoadContent();
                return controller;
            }

            if (type == "Playing")
            {
                IPlayingScene playingScene = new PlayingScene();
                IController controller = new PlayingSceneController(playingScene, GameManager);
                controller.LoadContent();
                return controller;
            }

            //throw new TypeInitializationException(type,
            //                                      new Exception("SceneFactory can't create or load the type given"));
            return null;
        }

        #endregion
    }
}
