using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace XNA.Pong.Entities.Model.Ball
{
    public interface IBall
    {
        void MoveBall(GameTime gameTime);
        void PlayScored();
        void PlayBounce();
        void SpeedUp();
        ISpriteEntity Sprite { get; set; }
        SoundEffect Scored { get; set; }
        SoundEffect Bounce { get; set; }
        Vector2 StartVelocity { get; set; }
    }
}