using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNA.Pong.Configuration;

namespace XNA.Pong.Scenes
{
    public class MenuScene : SceneBase
    {
        private IEntity screen;
        private ICamera2D camera;

        public MenuScene(Microsoft.Xna.Framework.Game game) : base(game)
        {
            camera = new Camera2D(Game);
            //Game.Components.Add((IGameComponent)camera);

            screen = EntityFactory.CreateSprite("default");
            MenuConfiguration menuConfiguration = Game.Content.Load<MenuConfiguration>("Menu.Config");
            screen.LoadContent(menuConfiguration.AssetName);
            screen.Scale = menuConfiguration.Scale;

        }


        public override void LoadContent()
        {
            
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.BackToFront, SaveStateMode.SaveState, camera.Transform);
                SpriteBatch.Draw(screen.SpriteTexture, screen.Position, screen.Source, screen.Color, screen.Rotation, screen.Origin, screen.Scale, SpriteEffects.None, 0);
            SpriteBatch.End();
        }

        


    }
}
