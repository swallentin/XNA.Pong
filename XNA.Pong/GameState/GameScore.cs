using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace XNA.Pong.GameState
{
    public class GameScore:IGameScoreObservable
    {
        protected Hashtable CollisionObserverContainer;
        private int _player1;
        private int _player2;

        public GameScore()
        {
            CollisionObserverContainer= new Hashtable();

            // We're creating the game score object so we don't need to notify any one.
            _player1 = 0;
            _player2 = 0;
        }

        public int Player2
        {
            get { return _player2; }
            set
            {
                _player2 = value;
                NotifyObserver(PlayerIndex.Two);
            }
        }

        private void NotifyObserver(PlayerIndex playerIndex)
        {
            foreach (IGameScoreObserver gameScoreObserver in CollisionObserverContainer.Keys)
            {
                gameScoreObserver.Notification(playerIndex);
            }
        }

        public int Player1
        {
            get { return _player1; }
            set { 
                _player1 = value;
                NotifyObserver(PlayerIndex.One);
            }
        }

        #region Implementation of IGameScoreObservable

        public void RegisterObserver(IGameScoreObserver gameScoreObserver)
        {
            CollisionObserverContainer.Add(gameScoreObserver, gameScoreObserver);
        }

        public void UnregisterObserver(IGameScoreObserver gameScoreObserver)
        {
            CollisionObserverContainer.Remove(gameScoreObserver);
        }

        #endregion
    }
}
