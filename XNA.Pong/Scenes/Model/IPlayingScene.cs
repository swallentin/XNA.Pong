using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using XNA.Pong.Entities.Controller.Ball;
using XNA.Pong.Entities.Controller.Padel;
using XNA.Pong.Entities.Model.Ball;
using XNA.Pong.Entities.Model.Padel;
using XNA.Pong.GameState;

namespace XNA.Pong.Scenes.Model
{
    public interface IPlayingScene
    {
        IController Player1 { get; set; }
        IController Player2 { get; set; }
        IController Ball { get; set; }
        ISpriteEntity Background { get; set; }
    }
}