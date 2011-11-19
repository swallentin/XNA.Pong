using System;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;
using XNA.Pong.GameState;
using XNA.Pong.Scenes.Model;

namespace XNA.Pong.Scenes.Controller
{
    public class HUDSceneController : IController, IGameScoreObserver
    {
        private IHUDScene _hudScene;
        private IView _hudView;
        private IGameManager _gameManager;
        
        #region Implementation of IController

        public HUDSceneController(IHUDScene hudScene, IGameManager gameManager)
        {
            _hudScene = hudScene;
            _hudView = new HudView(this, hudScene);
            _gameManager = gameManager;
        }

        public IGameManager GameManager
        {
            get { return _gameManager; }
        }

        public IView GetView()
        {
            return _hudView;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void LoadContent()
        {
            //_hudSceneModel.Player1ScoreEntity = GameManager.SpriteEntityFactory.CreateSprite("Player1");
            //_hudSceneModel.Player1ScoreEntity = GameManager.SpriteEntityFactory.CreateSprite("Player2");
        }

        public void UnloadContent()
        {
        }

        public void Notification(PlayerIndex playerIndex)
        {
            if (playerIndex == PlayerIndex.One)
            {
                //_hudSceneModel.Player1ScoreEntity.PlayScored();
            }
            else if (playerIndex == PlayerIndex.Two)
            {
                //_hudSceneModel.Player1ScoreEntity.PlayScored();
            }
        }

        #endregion
    }
}