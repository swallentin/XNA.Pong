using System;
using Game.Base.Entities;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace XNA.Pong.Entities.Model.Ball
{
    public class Ball:IBall
    {
        public Ball(ISpriteEntity spriteEntity)
        {
            Sprite = spriteEntity;
            StartVelocity = Sprite.Velocity;
        }

        #region Implementation of IBall

        public void MoveBall(GameTime gameTime)
        {
            Sprite.Position += Sprite.Direction * Sprite.Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void PlayScored()
        {
            Scored.Play();
        }

        public void PlayBounce()
        {
            Bounce.Play();
        }

        public void SpeedUp()
        {
            Sprite.Velocity *= 1.1f;
        }

        public ISpriteEntity Sprite
        {
            get; set; 
        }

        public SoundEffect Scored { get; set; }
        public SoundEffect Bounce { get; set; }

        public Vector2 StartVelocity
        {
            get; set;
        }

        #endregion
    }
}
