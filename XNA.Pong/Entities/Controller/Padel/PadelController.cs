using Game.Base.Entities;
using Game.Base.Helpers;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using Game.Base.Managers.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using XNA.Pong.Entities.Model;
using XNA.Pong.Entities.Model.Padel;
using XNA.Pong.Entities.View;
using XNA.Pong.Entities.View.Padel;

namespace XNA.Pong.Entities.Controller.Padel
{
    public class PadelController : SpriteEntityControllerBase, ICollisionObserver, IPadelController
    {
        private const float BounceAnimationDuration = 0.2f;
        private float _bounceCurrentBounceAnimationDuration = 0.0f;
        private bool _isPlayingBounceAnimation;
        public IPadel Padel { get; set; }
        private IPadelView View { get; set; }
        private const int PadelSpeed = 160;
        private static readonly Vector2 PadelMoveUp = new Vector2(0, -1);
        private static readonly Vector2 PadelMoveDown = new Vector2(0, 1);
        private const float MaxY = 0.85f;

        public PadelController(IPadel padel, IGameManager gameManager) : base(gameManager)
        {
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
                GameManager.TextureManager.LoadTexture("PlanetBeam2", Padel.Sprite);
            }
            else
            {
                GameManager.TextureManager.LoadTexture("PlanetBeam", Padel.Sprite);
            }
        }

        public override IView GetView()
        {
            return View;
        }


        public void MoveUp(GameTime gameTime)
        {
             Padel.Sprite.Position += PadelMoveUp * Padel.Sprite.Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void MoveDown(GameTime gameTime)
        {
            Padel.Sprite.Position += PadelMoveDown * Padel.Sprite.Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (Padel.Sprite.Position.Y < 0)
            {
                // Move this to the padel entity
                // PadelEntity.ResetPosition();
                Padel.Sprite.Position = new Vector2(Padel.Sprite.Position.X, 0);
            }

            if (Padel.Sprite.Position.Y > SpriteHelper.GetAbsoluteHeight(MaxY, GameManager.GraphicsDeviceManager))
            {
                // Move this to the padel entity
                // PadelEntity.ResetPosition();
                Padel.Sprite.Position = new Vector2(Padel.Sprite.Position.X, SpriteHelper.GetAbsoluteHeight(MaxY, GameManager.GraphicsDeviceManager));
            }

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

        public override void LoadContent()
        {
            Padel.Bounce = GameManager.ContentManager.Load<SoundEffect>("Bounce");
            GameManager.CollisionManager.RegisterCollisionObserver(Padel.Sprite.Name, this);
            GameManager.CollisionManager.RegisterCollision(Padel.Sprite);
        }

        public void CollisionNotification(ISpriteEntity collidingWithSpriteEntity)
        {
            if (collidingWithSpriteEntity.Name == "Player1" || collidingWithSpriteEntity.Name == "Player2")
            {
                Padel.Sprite.Direction = new Vector2(Padel.Sprite.Direction.X * -1, Padel.Sprite.Direction.Y);
                Padel.PlayBounce();
                return;
            }
        }


    }
}
