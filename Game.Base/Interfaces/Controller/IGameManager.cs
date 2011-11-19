using System;
using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using Game.Base.Managers.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Base.Interfaces.Controller
{
    public interface IGameManager
    {
        object this[String key] { get; set; }

        bool IsRunning
        {
            get;
            set;
        }
    
        void Initalize();

        void ChangeState(IGameState gameState);

        void PushState(IGameState gameState);

        void PopState();

        void Quit();

        ITextureManager TextureManager { get; }
        ISpriteGraphicsManager SpriteGraphicsManager { get; }
        ITextGraphicsManager TextGraphicsManager { get; }
        ISpriteEntityFactory SpriteEntityFactory { get; }
        ICollisionManager CollisionManager { get; }
        ContentManager ContentManager { get; }
        ISceneFactory SceneFactory{ get; }
        ISceneManager SceneManager { get; }
        GraphicsDeviceManager GraphicsDeviceManager { get; }

    }
}
