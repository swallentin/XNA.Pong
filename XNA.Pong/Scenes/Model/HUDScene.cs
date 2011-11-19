using System;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using XNA.Pong.Entities;
using XNA.Pong.Entities.View;

namespace XNA.Pong.Scenes.Model
{
    public class HUDScene:IHUDScene
    {
        #region Implementation of IModel


        #endregion

        #region Implementation of IHUDSceneModel

        public ITextEntity ScoreTextEntity { get; private set; }
        public int GetPlayerScore(PlayerIndex playerIndex)
        {
            throw new NotImplementedException();
        }

        public ISpriteEntity Player1ScoreEntity { get; set; }
        public ISpriteEntity Player2ScoreEntity { get; set; }



        #endregion
    }
}