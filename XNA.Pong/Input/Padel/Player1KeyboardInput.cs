using Microsoft.Xna.Framework.Input;
using XNA.Pong.Entities;
using XNA.Pong.Entities.Controller;
using XNA.Pong.Entities.View;

namespace XNA.Pong.Input.Padel
{
    public class Player1KeyboardInput:PadelKeyboardController
    {
        public Player1KeyboardInput(PadelEntityController entityController) : base(entityController)
        {
        }

        public override bool IsMovingUp()
        {
            return CurrentState.IsKeyDown(Keys.Q);
        }

        public override bool IsMovingDown()
        {
            return CurrentState.IsKeyDown(Keys.A);
        }
    }
}
