using System;
using System.Collections.Generic;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNA.Pong.Scenes.Model
{
    public class MainMenuScene:IMainMenuScene
    {
        private IList<MainMenuItem> _menuItems;
        private ISpriteEntity _background;
        private SoundEffect _menuChange;
        private SoundEffect _menuSelected;
        
        public MainMenuScene()
        {
            _menuItems = new List<MainMenuItem>();  
        }

        #region Implementation of IMainMenuScene

        public IList<MainMenuItem> MenuItems
        {
            get { return _menuItems; }
        }

        public ISpriteEntity Background
        {
            get { return _background; }
            set { _background = value; }
        }

        public void PlayMenuChange()
        {
            _menuChange.Play(0.6f, 1.0f, 0.0f);
        }

        public void PlayMenuSelected()
        {
            _menuSelected.Play(0.6f, 1.0f, 0.0f);
        }

        public SoundEffect MenuChange
        {
            get { return _menuChange; }
            set { _menuChange = value; }
        }

        public SoundEffect MenuSelected
        {
            get { return _menuSelected; }
            set { _menuSelected = value; }
        }

        public SpriteFont Font
        {
            get; set; 
        }

        #endregion
    }
}