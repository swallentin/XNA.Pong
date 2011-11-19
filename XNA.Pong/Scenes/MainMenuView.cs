using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base;
using Game.Base.Entities;
using Game.Base.Interfaces;

using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNA.Pong.GameState;
using XNA.Pong.Scenes.Controller;
using XNA.Pong.Scenes.Model;

namespace XNA.Pong.Scenes
{
    public class MainMenuView: ViewBase
    {
        private IMainMenuScene _scene;
        private MainMenuSceneController _controller;
        private List<ITextEntity> _textEntitiesToRender;

        public MainMenuView(MainMenuSceneController controller, IMainMenuScene mainMenuScene)
        {
            _controller = controller;
            _scene = mainMenuScene;
            _textEntitiesToRender = new List<ITextEntity>();
        }

        #region Overrides of ViewBase

        public Color GetColorForItem(int index)
        {
            return index == _controller.SelectedItemIndex ? _scene.MenuItems[index].SelectedColor : _scene.MenuItems[index].Color;
        }

        #endregion

        #region Overrides of ViewBase

        public override ISpriteEntity[] GetSpriteEntitiesToRender(GameTime gameTime)
        {
            return null;
        }

        public override ITextEntity[] GetTextEntitiesToRender(GameTime gameTime)
        {
            _textEntitiesToRender.Clear();

            foreach (MainMenuItem mainMenuItem in _scene.MenuItems)
            {
                ITextEntity textEntity = new TextEntity();
                textEntity.Font = _controller.GameManager.ContentManager.Load<SpriteFont>("SpriteFont1");
                textEntity.Text = mainMenuItem.Text;
                textEntity.Position = mainMenuItem.Position;
                textEntity.Color = mainMenuItem.SelectedColor;
                textEntity.Effects = SpriteEffects.None;
                textEntity.Rotation = 0;
                textEntity.Scale = 3.0f;
                
                _textEntitiesToRender.Add(textEntity);
            }

            return _textEntitiesToRender.ToArray();
        }

        #endregion
    }
}
