using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace XNA.Pong.Entities.Model
{
    public class Ball:SpriteEntity,IBall
    {
        private SoundEffect _ballScored;
        private SoundEffect _ballBounce;

        #region Implementation of IBall

        public void MoveBall(GameTime gameTime)
        {
            Position += Direction * Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void PlayScored()
        {
            Scored.Play();
        }

        public void PlayBounce()
        {
            Bounce.Play();
        }

        public SoundEffect Scored { get; set; }
        public SoundEffect Bounce { get; set; }

        #endregion
    }
}
