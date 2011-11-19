using System;
using Game.Base;
using Game.Base.Interfaces;
using Microsoft.Xna.Framework;

namespace XNA.Pong.Input
{
    public abstract class PlayerScoredBallStateBase:IBallState
    {
        private IGameManager _gameManager;
        public virtual void Update(ISpriteEntity spriteEntity, GameTime gameTime, BallInput ballInput)
        {
            ballInput.PlayScored();
            _gameManager = ((IGameManager)spriteEntity.Game.Services.GetService(typeof(IGameManager)));
            int score = (int)_gameManager[PlayerScoreKey];
            score++;
            _gameManager[PlayerScoreKey] = score;
        }

        protected abstract string PlayerScoreKey { get; }

    }
}