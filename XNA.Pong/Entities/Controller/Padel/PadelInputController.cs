using System;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using XNA.Pong.Entities.Controller.Ball;

namespace XNA.Pong.Entities.Controller.Padel
{
    public abstract class PadelInputController : InputControllerBase
    {
        public IPadelController PadelController { get; private set; }

        protected PadelInputController(IPadelController controller, IGameManager gameManager, PlayerIndex playerIndex)
            : base(gameManager, playerIndex)
        {
            PadelController = controller;
        }

        public override void OnUpdate(GameTime gameTime)
        {
            if (IsMovingUp())
            {
                PadelController.MoveUp(gameTime);
            }
            if (IsMovingDown())
            {
                PadelController.MoveDown(gameTime);
            }
            PadelController.Update(gameTime);
        }

        public override void LoadContent()
        {
            PadelController.LoadContent();
        }
        public override void UnloadContent()
        {
            PadelController.UnloadContent();
        }

        public abstract bool IsMovingUp();
        public abstract bool IsMovingDown();

        #region Implementation of ICollisionObserver

        public override Game.Base.Interfaces.View.IView GetView()
        {
            return PadelController.GetView();
        }

        #endregion
    }
}
