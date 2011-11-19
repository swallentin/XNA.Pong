using System.Collections.Generic;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace XNA.Pong.Scenes.Model
{
    public interface IMainMenuScene
    {
        IList<MainMenuItem> MenuItems { get; }
        ISpriteEntity Background { get; set; }
        void PlayMenuChange();
        void PlayMenuSelected();
        SoundEffect MenuChange { get; set; }
        SoundEffect MenuSelected { get; set; }
        SpriteFont Font { get; set; }
    }
}