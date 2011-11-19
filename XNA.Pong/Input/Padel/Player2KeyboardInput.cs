using Microsoft.Xna.Framework.Input;
using XNA.Pong.Entities;
using XNA.Pong.Entities.Controller;
using XNA.Pong.Entities.View;

namespace XNA.Pong.Input.Padel
{
    public class Player2KeyboardInput:PadelKeyboardController
    {
        public Player2KeyboardInput(PadelEntityController entityController) : base(entityController)
        {
        }

        public override bool IsMovingUp()
        {
            return CurrentState.IsKeyDown(Keys.PageUp);
        }

        public override bool IsMovingDown()
        {
            return CurrentState.IsKeyDown(Keys.PageDown);
        }
    }
}
