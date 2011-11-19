using System;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using XNA.Pong.Entities.View.Padel;

namespace XNA.Pong.Entities.Controller.Padel
{
    public class PlayerInputController:PadelInputController
    {
        public Keys MoveUpKey { get; set; }
        public Keys MoveDownKey{ get; set; }

        public PlayerInputController(IPadelController controller, IGameManager gameManager, PlayerIndex playerIndex) : base(controller, gameManager, playerIndex)
        {
        }

        public override bool IsMovingUp()
        {
            return CurrentState.IsKeyDown(MoveUpKey) || CurrentGamePadState.ThumbSticks.Left.Y > 0;
        }

        public override bool IsMovingDown()
        {
            return CurrentState.IsKeyDown(MoveDownKey) || CurrentGamePadState.ThumbSticks.Left.Y < 0;
        }

        #region Overrides of SpriteEntityControllerBase



        #endregion
    }
}
