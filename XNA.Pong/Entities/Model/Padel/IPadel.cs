using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework.Audio;

namespace XNA.Pong.Entities.Model.Padel
{
    public interface IPadel
    {
        ISpriteEntity Sprite { get; set; }
        void PlayBounce();
        SoundEffect Bounce { get; set; }
    }
}