using System;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using XNA.Pong.Entities.Model.Ball;
using XNA.Pong.Entities.View.Padel;

namespace XNA.Pong.Entities.Controller.Padel
{
    public class AIInputController:PadelInputController
    {
        public Keys MoveUpKey { get; set; }
        public Keys MoveDownKey{ get; set; }
        public IBall Ball { get; set; }

        public AIInputController(IPadelController controller, IGameManager gameManager, PlayerIndex playerIndex)
            : base(controller, gameManager, playerIndex)
        {
        }

        public override bool IsMovingUp()
        {
            return Ball.Sprite.Position.Y < PadelController.Padel.Sprite.Position.Y;
        }

        public override bool IsMovingDown()
        {
            return Ball.Sprite.Position.Y > PadelController.Padel.Sprite.Position.Y;
        }

        #region Overrides of SpriteEntityControllerBase



        #endregion
    }
}
