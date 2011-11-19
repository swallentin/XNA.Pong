using System;
using Game.Base;
using Game.Base.Interfaces;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;

namespace XNA.Pong.Scenes
{
    public class InstructionsView : ViewBase
    {
        private ISpriteEntity background;

        public InstructionsView(Microsoft.Xna.Framework.Game game) : base(game)
        {
        }

        public override void LoadContent()
        {

            background = SpriteEntityFactory.CreateSprite("OptionsScreen");
        }

        public override void UnloadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
        }


        public override void  Draw(GameTime gameTime)
        {
        }
    }
}