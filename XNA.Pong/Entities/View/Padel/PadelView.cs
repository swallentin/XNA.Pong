using System;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using XNA.Pong.Entities.Controller;
using XNA.Pong.Entities.Controller.Padel;
using XNA.Pong.Entities.Model;
using XNA.Pong.Entities.Model.Padel;
using XNA.Pong.Entities.View.Padel;

namespace XNA.Pong.Entities.View.Padel
{
    public class PadelView : IPadelView
    {
        private IPadel Padel { get; set; }
        private PadelController Controller { get; set; }


        public PadelView(IPadel padel, PadelController padelController)
        {
            Padel = padel;
            Controller = padelController;

        }

        #region Implementation of IView

        public ISpriteEntity[] GetSpriteEntitiesToRender(GameTime gameTime)
        {
            return new[] {Padel.Sprite};
        }

        public ITextEntity[] GetTextEntitiesToRender(GameTime gameTime)
        {
            return null;
        }

        #endregion
    }
}