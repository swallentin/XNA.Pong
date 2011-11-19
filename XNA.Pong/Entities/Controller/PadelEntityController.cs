using System;
using Game.Base.Entities;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.View;
using Game.Base.Texture;
using XNA.Pong.Entities.Model;
using XNA.Pong.Entities.View;

namespace XNA.Pong.Entities.Controller
{
    public class PadelEntityController:SpriteEntityControllerBase
    {
        private const float BounceAnimationDuration = 0.2f;
        private float _bounceCurrentBounceAnimationDuration = 0.0f;
        private bool _isPlayingBounceAnimation;
        public IGameManager GameManager { get; set; }
        private IPadel Padel { get; set; }
        private IPadelView View { get; set; }

        public PadelEntityController(IPadel padel, IGameManager gameManager)
        {
            GameManager = gameManager;
            Padel = padel;
            View = new PadelView(padel, this);

        }

        public void AnimateBallBounce()
        {
            _isPlayingBounceAnimation = true;
            ToggleTexture();
        }

        public void ToggleTexture()
        {
            if( _isPlayingBounceAnimation )
            {
                GameManager.TextureManager.LoadTexture("PlanetBeam2", Padel);
            }
            else
            {
                GameManager.TextureManager.LoadTexture("PlanetBeam", Padel);
            }
        }

        public override IView GetView()
        {
            return View;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (_isPlayingBounceAnimation && BounceAnimationDuration > _bounceCurrentBounceAnimationDuration)
            {
                _bounceCurrentBounceAnimationDuration += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                _isPlayingBounceAnimation = false;
                _bounceCurrentBounceAnimationDuration = 0.0f;
                ToggleTexture();
            }
        }
    }
}
