using System;
using Game.Base.Entities;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;

namespace XNA.Pong.Entities.View
{

    public interface IPlayerScoredView
    {
        ISpriteEntity Sprite { get; set; }
    }
    public class PlayerScoredView:SpriteEntityView
    {
        private const float Duration = 1.0f;
        private float _currentDuration = 0.0f;
        private bool _isPlaying = false;
        public ISpriteEntity Model { get; set; }

        internal PlayerScoredView(IController controller, ISpriteEntity model)
        {
            Model = model;
        }

        public void PlayScored()
        {
            _isPlaying = true;
            _currentDuration = 0.0f;
        }

        public override ISpriteEntity[] GetSpriteEntitiesToRender(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (_isPlaying && Duration > _currentDuration)
            {
                _currentDuration += (float)gameTime.ElapsedGameTime.TotalSeconds;
                return new[] {Model};
            }

            _isPlaying = false;
            _currentDuration = 0.0f;

            return null;
        }

        public override ITextEntity[] GetTextEntitiesToRender(GameTime gameTime)
        {
            return null;
        }
    }
}
