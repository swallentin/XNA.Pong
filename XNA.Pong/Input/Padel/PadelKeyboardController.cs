using Game.Base.Interfaces.Control;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using XNA.Pong.Entities;
using XNA.Pong.Entities.Controller;
using XNA.Pong.Entities.View;

namespace XNA.Pong.Input.Padel
{
    public abstract class PadelKeyboardController : KeyboardControllerBase, ICollisionObserver
    {
        private const int PadelSpeed = 160;
        private static readonly Vector2 MoveUp = new Vector2(0, -1);
        private static readonly Vector2 MoveDown = new Vector2(0, 1);
        private static readonly Vector2 Velocity = new Vector2(PadelSpeed, 500);
        private PadelEntityController _padelEntityController;


        public PadelKeyboardController(PadelEntityController entityController)
        {
            _padelEntityController = entityController;
        }

        public override void OnUpdate()
        {
            if (IsMovingDown())
            {
                // Move this to the padel entity
                // PadelEntity.MoveUp();
                _padelEntityController.Position += MoveDown * Velocity * (float)GameTime.ElapsedGameTime.TotalSeconds;
            }

            if( IsMovingUp())
            {
                // Move this to the padel entity
                // PadelEntity.MoveUp()
                _padelEntityController.Position += MoveUp * Velocity * (float)GameTime.ElapsedGameTime.TotalSeconds;
            }

            if (_padelEntityController.Position.Y < 0)
            {


                // Move this to the padel entity
                // PadelEntity.ResetPosition();
                _padelEntityController.Position = new Vector2(_padelEntityController.Position.X, 0);
            }
            if (_padelEntityController.Position.Y + _padelEntityController.Size.Height > _padelEntityController.Game.GraphicsDevice.Viewport.Height)
            {
                // Move this to the padel entity
                // PadelEntity.ResetPosition();
                _padelEntityController.Position = new Vector2(_padelEntityController.Position.X, _padelEntityController.Game.GraphicsDevice.Viewport.Height - _padelEntityController.Size.Height);
            }
        }

        public abstract bool IsMovingUp();
        public abstract bool IsMovingDown();

        public void CollisionNotification(ISpriteEntity collidingWithSpriteEntity)
        {
            if (collidingWithSpriteEntity.Name != "Ball")
            {
                return;
            }
            
            _padelEntityController.AnimateBallBounce();

        }

    }
}
