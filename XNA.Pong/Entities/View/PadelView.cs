using System;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using XNA.Pong.Entities.Controller;
using XNA.Pong.Entities.Model;

namespace XNA.Pong.Entities.View
{
    public class PadelView : IPadelView
    {
        private IPadel Padel { get; set; }
        private PadelEntityController Controller { get; set; }


        public PadelView(IPadel padel, PadelEntityController padelEntityController)
        {
            Padel = padel;
            Controller = padelEntityController;

        }

        #region Implementation of IView

        public ISpriteEntity[] GetSpriteEntitiesToRender(GameTime gameTime)
        {
            return new[] {Padel};
        }

        public ITextEntity[] GetTextEntitiesToRender(GameTime gameTime)
        {
            return null;
        }

        #endregion
    }
}