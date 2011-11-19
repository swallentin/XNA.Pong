using System;
using Game.Base.Entities;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace XNA.Pong.Entities.Model.Padel
{
    public class Padel:IPadel
    {
        #region Implementation of IPadel

        public Padel(ISpriteEntity spriteEntity)
        {
            Sprite = spriteEntity;
            //Sprite.Origin = new Vector2(Sprite.Size.Width/2, Sprite.Size.Height/2);
        }

        public ISpriteEntity Sprite
        {
            get; set;
        }

        public void PlayBounce()
        {
            Bounce.Play();
        }

        public SoundEffect Bounce
        {
            get; set;
        }

        

        #endregion
    }
}
