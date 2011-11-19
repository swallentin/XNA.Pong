using System;
using System.Collections.Generic;
using Game.Base;
using Game.Base.Interfaces;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using Game.Base.Managers.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNA.Pong.Configuration;
using XNA.Pong.Entities.Controller;
using XNA.Pong.Entities.Controller.Ball;
using XNA.Pong.Entities.Controller.Padel;
using XNA.Pong.GameState;

namespace XNA.Pong.Scenes
{
    public interface IPlayingScene
    {
        ISpriteEntity Player1 { get; }
        ISpriteEntity Player2 { get; }
        ISpriteEntity Ball { get; }
        ISpriteEntity Background { get; }

    }
    internal class PlayingScene:IPlayingScene
    {
        #region Implementation of IPlayingScene

        private ISpriteEntity _player1;

        private ISpriteEntity _player2;

        private ISpriteEntity _ball;

        private ISpriteEntity _background;

        public ISpriteEntity Player1
        {
            get { return _player1; }
        }

        public ISpriteEntity Player2
        {
            get { return _player2; }
        }

        public ISpriteEntity Ball
        {
            get { return _ball; }
        }

        public ISpriteEntity Background
        {
            get { return _background; }
        }

        #endregion
    }

    public class PlayingSceneView:IView
    {
        private PlayingSceneController _controller;
        private IPlayingScene _model;

        public PlayingSceneView(PlayingSceneController controller, IPlayingScene model)
        {
            _controller = controller;
            _model = model;
        }

        #region Implementation of IView

        public ISpriteEntity[] GetSpriteEntitiesToRender(GameTime gameTime)
        {
            return new[]{_model.Background, _model.Player1, _model.Player2, _model.Ball};
        }

        public ITextEntity[] GetTextEntitiesToRender(GameTime gameTime)
        {
            return null;
        }

        #endregion
    }


    /// <summary>
    /// 
    /// </summary>
    public class PlayingSceneController : IController
    {
        #region Fields

        private ISpriteEntity player1;
        private ISpriteEntity player2;
        private ISpriteEntity ball;
        private ISpriteEntity background;
        private SoundEffect _ballBounce;
        private ICamera2D camera;
        private ISpriteEntity circle;

        private IGameManager _gameManager;
        private IPlayingScene _playingScene;
        private List<ISpriteEntity> _entitiesToRender;
        private GameScore _gameScore;
        private IView _hud;
        private IView _playingView;



        #endregion

        #region Ctors

        public PlayingSceneController(IPlayingScene playingScene, IGameManager gameManager)
        {
            _playingScene = playingScene;
            _gameManager = gameManager;
            _entitiesToRender = new List<ISpriteEntity>();
            
            _gameScore = new GameScore();
            _hud = new HudView(this, _playingScene);
            _playingView = new PlayingView
        }

        #endregion


        #region Methods

        public void LoadContent()
        {
            //Game.Components.Add((IGameComponent)camera);


            background = SpriteEntityFactory.CreateSprite("Background");
            _entities.Add(background);

            player1 = SpriteEntityFactory.CreateSprite("Padel1");
            camera.Focus = player1 as IFocusable;
            _entities.Add(player1);

            player2 = SpriteEntityFactory.CreateSprite("Padel2");
            _entities.Add(player2);



            ball = SpriteEntityFactory.CreateSprite("Ball");
            _entities.Add(ball);

            circle = SpriteEntityFactory.CreateSprite("Circle");
            _entities.Add(circle);

            _ballBounce = Game.Content.Load<SoundEffect>("Bounce");


            CollisionManager.RegisterCollision(ball);
            CollisionManager.RegisterCollision(player1);
            CollisionManager.RegisterCollision(player2);

            CollisionManager.RegisterCollisionObserver(ball.Name, ball.Controller as BallController);
            CollisionManager.RegisterCollisionObserver(player1.Name, player1.Controller as PadelKeyboardController);
            CollisionManager.RegisterCollisionObserver(player2.Name, player2.Controller as PadelKeyboardController);

            _hud.LoadContent(); ;
        }

        public override void UnloadContent()
        {
            CollisionManager.UnRegisterCollisionObserver(ball.Controller as BallController);
            _hud.UnloadContent();
        }

        

        //public override void Draw(GameTime gameTime)
        //{
        //    foreach (ISpriteEntity spriteEntity in _entities)
        //    {
        //        spriteEntity.Draw(gameTime);
        //    }
        //    _hud.Draw(gameTime);

        //    // This should be moved to the "HUD Scene"

        //    //textEntity.Text = GameManager["Player1Score"].ToString();
        //    //textEntity.Position = new Vector2(300, 100);
        //    //textEntity.Draw(gameTime);

        //    // This should be moved to the "HUD Scene"

        //    //textEntity.Position = new Vector2(Game.GraphicsDevice.Viewport.Width - 300, 100);
        //    //textEntity.Text = GameManager["Player2Score"].ToString();
        //    //textEntity.Draw(gameTime);
        //}


        public IView GetView()
        {
            return _
        }

        public void Update(GameTime gameTime)
        {

            KeyboardState currentState = Keyboard.GetState();

            if( currentState.IsKeyDown(Keys.Escape))
            {
                _gameManager.PopState();
            }
            


            ////camera.Focus = ball as IFocusable;

            //foreach (ISpriteEntity entity in _entities)
            //{
            //    entity.Update(gameTime);
            //}
            
            // Perform collisions detection and delegate it
            // entities collision detection

            //for (int i = 0; i < _entities.Count-1; i++)
            //{
            //    _collisionManager.PerformCollisionCheck(_entities[i], _entities[i + 1]);
            //}

            //CollisionManager.PerformCollisionCheck(ball, player1);
            //CollisionManager.PerformCollisionCheck(ball, player2);

        }


        #endregion
    }
}
