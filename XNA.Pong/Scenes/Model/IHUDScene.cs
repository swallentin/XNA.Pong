using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using XNA.Pong.Entities;
using XNA.Pong.Entities.View;
using XNA.Pong.GameState;

namespace XNA.Pong.Scenes.Model
{
    public interface IHUDScene:IScene
    {
        ITextEntity ScoreTextEntity { get; }
        int GetPlayerScore(PlayerIndex playerIndex);
        ISpriteEntity Player1ScoreEntity { get; set; }
        ISpriteEntity Player2ScoreEntity { get; set; }
    }
}