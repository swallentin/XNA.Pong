using System;
using Game.Base;
using Game.Base.Entities;
using Game.Base.Helpers;
using Game.Base.Interfaces;

using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNA.Pong.Entities;
using XNA.Pong.Entities.Controller;
using XNA.Pong.Entities.Controller.Ball;
using XNA.Pong.Entities.Controller.Padel;
using XNA.Pong.Entities.Model;
using XNA.Pong.Entities.Model.Ball;
using XNA.Pong.Entities.Model.Padel;
using XNA.Pong.Entities.View;

namespace XNA.Pong
{
    internal sealed class SpriteEntityFactory : GameComponent, ISpriteEntityFactory
    {
        private ISpriteLoader _spriteLoader;
        #region Ctors

        public SpriteEntityFactory(Microsoft.Xna.Framework.Game game):base(game)
        {
        }

        public override void Initialize()
        {
            _spriteLoader = new SpriteLoader(GameManager);
            base.Initialize();
        }

        #endregion

        #region Properties

        private IGameManager _gameManager;
        /// <summary>
        /// Gets the collision manager.
        /// </summary>
        /// <value>The collision manager.</value>
        public IGameManager GameManager
        {
            get
            {
                return _gameManager ?? (_gameManager = (IGameManager)Game.Services.GetService(typeof(IGameManager)));
            }
        }

        #endregion

        /// <summary>
        /// Creates the sprite.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public IController CreateSpriteController(string type)
        {
            IController controller = null;

            if (type == "Padel1")
            {
                ISpriteEntity spriteEntity = CreateSprite(type);
                spriteEntity.Position = SpriteHelper.GetAbsolutePosition(spriteEntity.Position, GameManager.GraphicsDeviceManager);
                IPadel model = new Padel(spriteEntity);
                IPadelController padelController = new PadelController(model, GameManager);
                PlayerInputController playerController = new PlayerInputController(padelController, GameManager, PlayerIndex.One);
                playerController.MoveUpKey = Keys.Q;
                playerController.MoveDownKey = Keys.A;
                return playerController;
            }

            if (type == "Padel2")
            {
                ISpriteEntity spriteEntity = CreateSprite(type);
                spriteEntity.Position = SpriteHelper.GetAbsolutePosition(spriteEntity.Position, GameManager.GraphicsDeviceManager);
                IPadel model = new Padel(spriteEntity);
                IPadelController padelController = new PadelController(model, GameManager);
                PlayerInputController playerController = new PlayerInputController(padelController, GameManager, PlayerIndex.Two);
                playerController.MoveUpKey = Keys.PageUp;
                playerController.MoveDownKey = Keys.PageDown;
                return playerController;
            }


            if (type == "AIPadel")
            {
                ISpriteEntity spriteEntity = CreateSprite("Padel2"); ;
                spriteEntity.Position = SpriteHelper.GetAbsolutePosition(spriteEntity.Position, GameManager.GraphicsDeviceManager);
                IPadel model = new Padel(spriteEntity);
                IPadelController padelController = new PadelController(model, GameManager);
                
                AIInputController aiInputController = new AIInputController(padelController, GameManager, PlayerIndex.Two);
                
                return aiInputController;
            }

            if (type == "Ball")
            {
                ISpriteEntity spriteEntity = new SpriteEntity();
                _spriteLoader.LoadSprite("Ball", ref spriteEntity);
                //spriteEntity.Texture = GameManager.ContentManager.Load<Texture2D>(ballConfiguration.AssetName);
                //spriteEntity.Scale = ballConfiguration.Scale;
                //spriteEntity.Color = Color.Cyan;
                //spriteEntity.Position = new Vector2((Game.GraphicsDevice.Viewport.Width / 2) - (spriteEntity.Size.Width / 2), (Game.GraphicsDevice.Viewport.Height / 2) - (spriteEntity.Size.Height / 2));
                spriteEntity.Position = SpriteHelper.GetAbsolutePosition(spriteEntity.Position, GameManager.GraphicsDeviceManager);
                IBall model = new Ball(spriteEntity);
                controller = new BallController(model, GameManager);
                //model.Name = "Ball";
                return controller;

            }

            //if( type == "MainBackground")
            //{
            //    controller = CreateDefaultSprite("Pong Title Screen");
            //    //controller = CreateBackground();
            //    //controller.LoadContent("Pong Title Screen");
            //    //controller.Name = "TitleScreen";
            //}

            //if (type == "Background")
            //{
            //    controller = CreateBackground();
            //    controller.LoadContent("Grass");
            //    controller.Size = new Rectangle(0, 0, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height);
            //}

            //if( type=="Circle")
            //{
            //    controller = new SinusCurveSpriteEntity(new NullController(), new NullGraphicsManager(), Game);
            //    controller.LoadContent("Pixel");
            //    controller.Name = "Circle";
            //}

            //if( type=="Player1Scores")
            //{
            //    controller = new PlayerScoredView(new NullController(), new NullGraphicsManager(), Game);
            //    controller.LoadContent("Player1Scores");
            //    controller.Name = "Player1Scores";
            //    controller.Position = new Vector2(300, 250);
            //}
            //if( type== "Player2Scores")
            //{
            //    controller = new PlayerScoredView(new NullController(), new NullGraphicsManager(), Game);
            //    controller.LoadContent("Player2Scores");
            //    controller.Name = "Player2Scores";
            //    controller.Position = new Vector2(300, 250);
            //}

            ThrowTypeInitializationExeption(type);
            return null;
        }

        public ISpriteEntity CreateSprite(string type)
        {
            if( "MainMenuBackground".Equals(type) )
            {
                ISpriteEntity spriteEntity = new SpriteEntity();
                _spriteLoader.LoadSprite("Background", ref spriteEntity);
                return spriteEntity;
            }

            if ("Background".Equals(type))
            {
                ISpriteEntity spriteEntity = new SpriteEntity();
                _spriteLoader.LoadSprite("PlayingBackground", ref spriteEntity);
                return spriteEntity;
            }

            if ("Padel1".Equals(type))
            {
                ISpriteEntity spriteEntity = new SpriteEntity();
                _spriteLoader.LoadSprite(type, ref spriteEntity);
                return spriteEntity;
            }

            if ("Padel2".Equals(type))
            {
                ISpriteEntity spriteEntity = new SpriteEntity();
                _spriteLoader.LoadSprite(type, ref spriteEntity);
                return spriteEntity;
            }

            if ("Ball".Equals(type))
            {
                ISpriteEntity spriteEntity = new SpriteEntity();
                _spriteLoader.LoadSprite("Ball", ref spriteEntity);
                return spriteEntity;
            }

            ThrowTypeInitializationExeption(type);
            
            return null;
        }

        private void ThrowTypeInitializationExeption(string type)
        {
            //throw new TypeInitializationException(type,
            //                                      new Exception("SpriteEntityFactory can't create or load the type given. 'CreateSprite()'"));
        }

        private IController CreateDefaultSprite(string contentFile)
        {
            ISpriteEntity background = new SpriteEntity();
            _spriteLoader.LoadSprite(contentFile, ref background);
            return new SpriteController(background, GameManager);
        }

        private IController CreateDefault()
        {
            return new SpriteController(new SpriteEntity(), GameManager);
        }
        
    }
}

  