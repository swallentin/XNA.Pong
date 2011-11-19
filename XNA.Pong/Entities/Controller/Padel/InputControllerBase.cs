using Game.Base.Entities;
using Game.Base.Interfaces.Controller;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace XNA.Pong.Entities.Controller.Padel
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class InputControllerBase : SpriteEntityControllerBase
    {
        private KeyboardState _previousState;
        private GamePadState _currentGamePadState;
        private KeyboardState _currentState;
        private GamePadState _previousGamePadState;
        private PlayerIndex _playerIndex;

        protected InputControllerBase(IGameManager gameManager, PlayerIndex playerIndex) : base(gameManager)
        {
            PlayerIndex = playerIndex;
        }

        public override void Update(GameTime gameTime)
        {
            CurrentState = Keyboard.GetState();
            CurrentGamePadState = GamePad.GetState(PlayerIndex);

            OnUpdate(gameTime);

            PreviousState = CurrentState;
            PreviousGamePadState = CurrentGamePadState;

        }

        /// <summary>
        /// Called when [update].
        /// 
        /// Handler hook to simplify management of states. The base class manages the state
        /// </summary>
        public virtual void OnUpdate(GameTime gameTime) {}

        #region Properties

        public KeyboardState PreviousState
        {
            get { return _previousState; }
            set { _previousState = value; }
        }

        public KeyboardState CurrentState
        {
            get { return _currentState; }
            set { _currentState = value; }
        }

        public GamePadState CurrentGamePadState
        {
            get { return _currentGamePadState; }
            set { _currentGamePadState = value; }
        }

        public GamePadState PreviousGamePadState
        {
            get { return _previousGamePadState; }
            set { _previousGamePadState = value; }
        }

        public PlayerIndex PlayerIndex
        {
            get { return _playerIndex; }
            set { _playerIndex = value; }
        }

        #endregion

    }
}