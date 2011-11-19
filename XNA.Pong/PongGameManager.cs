using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base;
using Game.Base.Managers.Game;
using XNA.Pong.GameState;

namespace XNA.Pong
{
    public class PongGameManager:GameManager
    {
        public PongGameManager(Microsoft.Xna.Framework.Game game) : base(game)
        {
            GameScore = new GameScore();
        }

        public GameScore GameScore
        {
            get { return base["GameScore"] as GameScore; }
            set { base["GameScore"] = value; }
        }
    }
}
