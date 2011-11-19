using System;
using Game.Base.Interfaces;
using Microsoft.Xna.Framework;
using XNA.Pong.Entities.Model.Ball;

namespace XNA.Pong.GameState
{
    public class BallPlayingState:IState<IBall>
    {
        private BallPlayingState _instance;

        protected BallPlayingState()
        {}

        public BallPlayingState Instance
        {
            get { return _instance ?? (_instance = new BallPlayingState()); }
        }

        #region Implementation of IState<StateSample>

        public void Update(ref IBall entity)
        {
            throw new NotImplementedException();
        }

        public void Load(ref IBall entity)
        {
            throw new NotImplementedException();
        }

        public void Unload(ref IBall entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}