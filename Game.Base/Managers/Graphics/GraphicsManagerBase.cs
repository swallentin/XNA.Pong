using Game.Base.Interfaces.Model;
using Game.Base.Managers.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Base.Managers.Graphics
{
    public class GraphicsManagerBase : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private ISceneManager _sceneManager;

        public GraphicsManagerBase(Microsoft.Xna.Framework.Game game) : base(game)
        {
        }

        protected SpriteBatch SpriteBatch
        {
            get
            {
                if (_spriteBatch == null)
                {
                    _spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
                }
                return _spriteBatch;
            }
        }

        protected ISceneManager SceneManager
        {
            get
            {
                if (_sceneManager == null)
                {
                    _sceneManager = (ISceneManager)Game.Services.GetService(typeof(ISceneManager));
                }
                return _sceneManager;
            }
        }



    }
}