using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using XNA.Pong.Entities.Controller.Ball;
using XNA.Pong.Entities.Controller.Padel;
using XNA.Pong.Entities.Model.Ball;
using XNA.Pong.Entities.Model.Padel;

namespace XNA.Pong.Scenes.Model
{
    public class PlayingScene:IPlayingScene
    {
        #region Implementation of IPlayingScene

        public IController Player1 { get; set; }
        public IController Player2 { get; set; }
        public IController Ball { get; set; }
        public ISpriteEntity Background { get; set; }

        #endregion
    }
}