using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base;
using Game.Base.Interfaces;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace XNA.Pong.GameState
{
    public class GameStateManager:DrawableGameComponent
    {
        #region Fields

        IList<IGameState> _gameStates = new List<IGameState>();
        IList<IGameState> _gameStatesToUpdate = new List<IGameState>();

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStateManager"/> class.
        /// </summary>
        /// <param name="game">The Game that the game component should be attached to.</param>
        public GameStateManager(Microsoft.Xna.Framework.Game game) : base(game) {}

        #endregion

        private bool _isInitialized;


        /// <summary>
        /// Initializes the component. Override this method to load any non-graphics resources and query for any required services.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            _isInitialized = true;
        }

        /// <summary>
        /// Called when graphics resources need to be loaded. Override this method to load any component-specific graphics resources.
        /// </summary>
        protected override void LoadContent()
        {
            foreach (IGameState gameState in _gameStates)
            {
                gameState.LoadContent();
            }
        }

        protected override void UnloadContent()
        {
            foreach (IGameState gameState in _gameStates)
            {
                gameState.UnloadContent(); ;
            }
        }

        public override void Update(GameTime gameTime)
        {
            _gameStatesToUpdate.Clear();

            foreach (IGameState gameState in _gameStates)
            {
                _gameStatesToUpdate.Add(gameState);
            }

            bool otherGameStateHasFocus = !Game.IsActive;
            bool coverByOtherGameState = false;

            while(_gameStatesToUpdate.Count > 0)
            {
                int screenCount = _gameStatesToUpdate.Count - 1;
                IGameState gameState = _gameStatesToUpdate[screenCount];

                _gameStatesToUpdate.RemoveAt(screenCount);
                gameState.Update(gameTime, otherGameStateHasFocus, coverByOtherGameState);

                if( gameState.GameState == GameStateTypes.TransitionOn ||
                    gameState.GameState == GameStateTypes.Active )
                {
                    if( !otherGameStateHasFocus)
                    {
                        // handle input
                        // this should really be abstracted to a "generic gamestate" that is a popup
                    }
                    otherGameStateHasFocus = true;
                }

                if( !gameState.IsPopup)
                {
                    coverByOtherGameState = true;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (IGameState gameState in _gameStates)
            {
                // this should as well be abstracted to contain the logic inside the gamestate object not the manager
                if( gameState.GameState == GameStateTypes.Hidden )
                    continue;

                gameState.Draw(gameTime);
            }
        }

        /// <summary>
        /// Adds the state of the game.
        /// </summary>
        /// <param name="gameState">State of the game.</param>
        public void AddGameState(IGameState gameState)
        {

            if( _isInitialized)
            {
                gameState.LoadContent();
            }

            _gameStates.Add(gameState);
        }

        /// <summary>
        /// Removes the state of the game.
        /// </summary>
        /// <param name="gameState">State of the game.</param>
        public void RemoveGameState(IGameState gameState)
        {
            _gameStates.Remove(gameState);
            _gameStatesToUpdate.Remove(gameState);
        }

        

    }
}
