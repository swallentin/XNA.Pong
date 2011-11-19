using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base.Interfaces;
using Microsoft.Xna.Framework;

namespace Game.Base.Managers.State
{
    public class StateManager<TEntityType>
    {
        #region Fields

        private TEntityType _owner;
        private IState<TEntityType> _currentState;
        private IState<TEntityType> _previousState;
        private IState<TEntityType> _globalState;



        #endregion

        public StateManager(TEntityType owner)
        {
            _owner = owner;
            CurrentState = null;
            PreviousState = null;
            GlobalState = null;
        }

        public IState<TEntityType> CurrentState
        {
            get { return _currentState; }
            set { _currentState = value; }
        }

        public IState<TEntityType> PreviousState
        {
            get { return _previousState; }
            set { _previousState = value; }
        }

        public IState<TEntityType> GlobalState
        {
            get { return _globalState; }
            set { _globalState = value; }
        }

        public void Update()
        {
            if( GlobalState != null)
            {
                GlobalState.Update(ref _owner);
            }

            if( CurrentState!= null )
            {
                CurrentState.Update(ref _owner);
            }
        }

        public void ChangeState(ref IState<TEntityType> newState)
        {
            PreviousState = CurrentState;
            CurrentState.Unload(ref _owner);
            CurrentState = newState;
            CurrentState.Load(ref _owner);
        }

        public void RevertToPreviousState()
        {
            ChangeState(ref _previousState);
        }

        public bool IsInState(ref IState<TEntityType> state)
        {
            return state.GetType().Equals(_currentState);
        }
    }
}
