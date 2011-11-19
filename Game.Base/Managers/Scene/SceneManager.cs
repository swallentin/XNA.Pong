using System;
using System.Collections.Generic;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;

namespace Game.Base.Managers.Scene
{
    public class SceneManager:GameComponent, ISceneManager
    {
        #region Implementation of ISceneManager

        private readonly List<IController> _scenes;
        private readonly List<ISpriteEntity> _entitiesToRender;
        private readonly List<ITextEntity> _textEntitiesToRender;

        private readonly List<IController> _scenesToUpdate;

        public SceneManager(Microsoft.Xna.Framework.Game game) : base(game)
        {
            _scenes = new List<IController>();
            _entitiesToRender = new List<ISpriteEntity>();
            _textEntitiesToRender = new List<ITextEntity>();
            _scenesToUpdate = new List<IController>();
        }

        public override void Update(GameTime gameTime)
        {
            _scenesToUpdate.Clear();
            _scenesToUpdate.AddRange(_scenes);

            // the controller can cancel the update cause it want's to change the game state so we need it to wait with removing it.
            foreach (IController controller in _scenesToUpdate)
            {
                controller.Update(gameTime);
            }
        }

        public void Add(IController controller)
        {
            _scenes.Add(controller);
        }

        

        public void Remove(IController controller)
        {
            _scenes.Remove(controller);
        }

        public ISpriteEntity[] GetSpriteEntitiesToRender(GameTime gameTime)
        {
            _entitiesToRender.Clear();
            foreach (IController controller in _scenes)
            {
                _entitiesToRender.AddRange(controller.GetView().GetSpriteEntitiesToRender(gameTime));
            }
            return _entitiesToRender.ToArray();
        }

        public ITextEntity[] GetTextEntitiesToRender(GameTime gameTime)
        {
            _textEntitiesToRender.Clear();
            foreach (IController controller in _scenes)
            {
                _textEntitiesToRender.AddRange(controller.GetView().GetTextEntitiesToRender(gameTime));
            }
            return _textEntitiesToRender.ToArray();
        }

        #endregion
    }
}