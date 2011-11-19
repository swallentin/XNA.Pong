using System;
using System.Collections.Generic;
using Game.Base.Interfaces;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using Game.Base.Managers.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Base.Managers.Game
{
    public class GameManager:DrawableGameComponent, IGameManager
    {
        #region Fields
        
        private Stack<IGameState> _gameStates;
        private Dictionary<string, object> _gameValues;

        #endregion

        #region Ctor

        public GameManager(Microsoft.Xna.Framework.Game game):base(game)
        {
            IsRunning = true;
            _gameStates = new Stack<IGameState>();
            _gameValues = new Dictionary<string, object>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified key.
        /// </summary>
        /// <value></value>
        public virtual object this[string key]
        {
            get { return _gameValues[key]; }
            set
            {
                _gameValues[key] = value;
            }
        }

        public bool IsRunning
        {
            get; set;
        }

        #endregion

        public void Initalize()
        {
            
        }

        /// <summary>
        /// Removes the current running state and insert the state provide.
        /// </summary>
        /// <param name="gameState">State of the game.</param>
        public void ChangeState(IGameState gameState)
        {
            PopStack();
            
            gameState.LoadContent();
            _gameStates.Push(gameState);
        }

        private void PopStack()
        {
            if( _gameStates.Count <= 0)
            {
                throw new InvalidProgramException("ChangeState() or PopState failed cause of empty gamestate stack");
            }
            _gameStates.Peek().UnloadContent();
            _gameStates.Pop();
        }

        /// <summary>
        /// Pushes the provided state in to the game state stack.
        /// </summary>
        /// <param name="gameState">State of the game.</param>
        public void PushState(IGameState gameState)
        {
            if (_gameStates.Count > 0)
            {
                _gameStates.Peek().UnloadContent();
            }
            _gameStates.Push(gameState);
            //_gameStates.Peek().LoadContent();
        }

        /// <summary>
        /// Pops the current running state from the game state stack.
        /// This will also trigger UnloadContent from the current running state;
        /// </summary>
        public void PopState()
        {
            PopStack();
        }

        /// <summary>
        /// Quits this instance.
        /// </summary>
        public void Quit()
        {
            Game.Exit();
        }

        #region Static Members

        private SpriteBatch _spriteBatch;
        /// <summary>
        /// Gets the sprite batch.
        /// </summary>
        /// <value>The sprite batch.</value>
        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch ?? (_spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch))); }
        }

        private ICollisionManager _collisionManager;
        /// <summary>
        /// Gets the collision manager.
        /// </summary>
        /// <value>The collision manager.</value>
        public ICollisionManager CollisionManager
        {
            get
            {
                return _collisionManager ?? (_collisionManager = (ICollisionManager)Game.Services.GetService(typeof(ICollisionManager)));
            }
        }

        private ContentManager _contentManager;
        /// <summary>
        /// Gets the content manager.
        /// </summary>
        /// <value>The content manager.</value>
        public ContentManager ContentManager
        {
            get
            {
                return _contentManager ?? (_contentManager = (ContentManager)Game.Services.GetService(typeof(ContentManager)));
            }
        }

        private ISceneFactory _sceneFactory;

        /// <summary>
        /// Gets the scene factory.
        /// </summary>
        /// <value>The scene factory.</value>
        public ISceneFactory SceneFactory
        {
            get { return _sceneFactory ?? (_sceneFactory = (ISceneFactory)Game.Services.GetService(typeof(ISceneFactory))); }
        }

        private ISpriteEntityFactory _spriteEntityFactory;
        /// <summary>
        /// Gets the spriteEntity factory.
        /// </summary>
        /// <value>The spriteEntity factory.</value>
        public ISpriteEntityFactory SpriteEntityFactory
        {
            get
            {
                return _spriteEntityFactory ?? (_spriteEntityFactory = (ISpriteEntityFactory)Game.Services.GetService(typeof(ISpriteEntityFactory)));
            }
        }

        private ISpriteGraphicsManager _spriteGraphicsManager;
        public ISpriteGraphicsManager SpriteGraphicsManager
        {
            get
            {
                return _spriteGraphicsManager ??
                       (_spriteGraphicsManager = (ISpriteGraphicsManager)Game.Services.GetService(typeof(ISpriteGraphicsManager)));

            }
        }

        private ITextGraphicsManager _textGraphicsManager;
        public ITextGraphicsManager TextGraphicsManager
        {
            get
            {
                return _textGraphicsManager ??
                       (_textGraphicsManager = (ITextGraphicsManager)Game.Services.GetService(typeof(ITextGraphicsManager)));

            }
        }

        private ITextureManager _textureManager;
        public ITextureManager TextureManager
        {
            get
            {
                return _textureManager ??
                    (_textureManager = (ITextureManager)Game.Services.GetService(typeof(ITextureManager)));
            }
        }


        private ISceneManager _sceneManager;

        public ISceneManager SceneManager
        {
            get
            {
                return _sceneManager ??
                       (_sceneManager = (ISceneManager) Game.Services.GetService(typeof (ISceneManager)));
            }
        }

        private GraphicsDeviceManager _graphicsDeviceManager;

        public GraphicsDeviceManager GraphicsDeviceManager
        {
            get
            {
                return _graphicsDeviceManager ??
                       (_graphicsDeviceManager = (GraphicsDeviceManager) Game.Services.GetService(typeof (GraphicsDeviceManager)));
            }
        }


        #endregion
    }
}
