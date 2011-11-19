using Game.Base;
using Game.Base.Interfaces;
using Game.Base.Interfaces.Control;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace XNA.Pong.Input
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class KeyboardControllerBase:IController
    {
        private GameTime _gameTime;
        private KeyboardState _previousState;
        private KeyboardState _currentState;

        public void Update(GameTime gameTime)
        {
            CurrentState = Keyboard.GetState();
            GameTime = gameTime;

            OnUpdate();

            PreviousState = CurrentState;
        }

        /// <summary>
        /// Called when [update].
        /// 
        /// Handler hook to simplify management of states. The base class manages the state
        /// </summary>
        public virtual void OnUpdate() {}

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

        public GameTime GameTime
        {
            get { return _gameTime; }
            set { _gameTime = value; }
        }

        #endregion

    }
}