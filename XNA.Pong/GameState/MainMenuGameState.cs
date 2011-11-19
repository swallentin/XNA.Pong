using System;
using Game.Base;
using Game.Base.Interfaces;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;
using XNA.Pong.Scenes;
using XNA.Pong.Scenes.Controller;

namespace XNA.Pong.GameState
{
    public class MainMenuGameState : GameStateBase
    {
        private IController _MainMenuSceneController;
        
        public MainMenuGameState(IGameManager gameManager):base(gameManager)
        {
            _MainMenuSceneController = GameManager.SceneFactory.CreateScene("MainMenu");
            GameManager.SceneManager.Add(_MainMenuSceneController);

        }

        #region Overrides of GameStateBase

        public override void LoadContent()
        {
            _MainMenuSceneController.LoadContent();
        }

        public override void UnloadContent()
        {
            GameManager.SceneManager.Remove(_MainMenuSceneController);
            _MainMenuSceneController.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            _MainMenuSceneController.Update(gameTime);
        }


        #endregion
    }
}