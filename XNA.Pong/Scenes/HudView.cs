using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base;
using Game.Base.Entities;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Game.Base.Managers.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNA.Pong.Entities;
using XNA.Pong.Entities.View;
using XNA.Pong.GameState;
using XNA.Pong.Scenes.Model;

namespace XNA.Pong.Scenes
{
    public class HudView:ViewBase,IGameScoreObserver
    {
        private IController _controller;
        private IHUDScene _entity;
        public HudView(IController controller, IHUDScene hudScene)
        {
            _controller = controller;
            _entity = hudScene;
            
        }


        public void LoadContent()
        {
            //player1 = SpriteEntityFactory.CreateSprite("Player1Scores") as PlayerScoredView;
            //player2 = SpriteEntityFactory.CreateSprite("Player2Scores") as PlayerScoredView;

            // RegisterObserver(this);

            //textEntity = new TextEntity(TextGraphicsManager);
            //textEntity.Scale = 2.0f;
            //textEntity.Effects = SpriteEffects.None;
            //textEntity.Color = Color.Red;
            //textEntity.Font = Game.Content.Load<SpriteFont>("SpriteFont1");
        }



        public void Draw(GameTime gameTime)
        {
            //player1.Draw(gameTime);
            //player2.Draw(gameTime);
            //// This should be moved to the "HUD Scene"

            //textEntity.Text = _gameScore.Player1.ToString();
            //textEntity.Position = new Vector2(300, 100);
            //textEntity.Draw(gameTime);

            //// This should be moved to the "HUD Scene"

            //textEntity.Text = _gameScore.Player2.ToString();
            //textEntity.Position = new Vector2(Game.GraphicsDevice.Viewport.Width - 300, 100);
            //textEntity.Draw(gameTime);
        }

        #region Implementation of IGameScoreObserver



        #endregion

        #region Overrides of ViewBase


        public void Notification(PlayerIndex playerIndex)
        {
            this.PlayerScored(playerIndex);
        }

        private void PlayerScored(PlayerIndex playerIndex)
        {
            // perform animation for player has scored.
        }

        #endregion

        #region Overrides of ViewBase

        public override ISpriteEntity[] GetSpriteEntitiesToRender(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override ITextEntity[] GetTextEntitiesToRender(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
