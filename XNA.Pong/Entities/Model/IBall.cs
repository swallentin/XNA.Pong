using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace XNA.Pong.Entities.Model
{
    public interface IBall:ISpriteEntity
    {
        void MoveBall(GameTime gameTime);
        void PlayScored();
        void PlayBounce();
        SoundEffect Scored { get; set; }
        SoundEffect Bounce { get; set; }
    }
}