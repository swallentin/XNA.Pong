using Game.Base.Helpers;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNA.Pong.GameState;
using XNA.Pong.Scenes.Model;
using XNA.Pong.Scenes.View;

namespace XNA.Pong.Scenes.Controller
{
    public class MainMenuSceneController:IController
    {
        private readonly IMainMenuScene _mainMenuScene;
        private readonly IView _view;
        private readonly IGameManager _gameManager;
        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;
        private GamePadState _currentGamePadState;
        private GamePadState _previousGamePadState;
        private const float UpdateInterval = 0.1f;
        private float _timeSinceLastUpdate = 0.0f;
        private bool _isLoaded = false;
        

        public MainMenuSceneController(IMainMenuScene mainMenuScene, IGameManager gameManager)
        {
            _mainMenuScene = mainMenuScene;
            _view = new MainMenuSceneView(this, mainMenuScene);
            _gameManager = gameManager;
        }

        public IGameManager GameManager
        {
            get { return _gameManager; }
        }

        public int SelectedItemIndex { get; set; }

        public IView GetView()
        {
            return _view;
        }

        public void LoadContent()
        {
            if( _isLoaded )
            {
                return;
            }
            _mainMenuScene.Background = GameManager.SpriteEntityFactory.CreateSprite("MainMenuBackground");
            _mainMenuScene.MenuChange = GameManager.ContentManager.Load<SoundEffect>("sound30");
            _mainMenuScene.MenuSelected = GameManager.ContentManager.Load<SoundEffect>("sound31");
            _mainMenuScene.Font = GameManager.ContentManager.Load<SpriteFont>("SpriteFont1");
            _mainMenuScene.MenuItems.Add(new MainMenuItem(_mainMenuScene.Font, "Play", SpriteHelper.GetAbsolutePosition(new Vector2(0.5f, 0.3f), GameManager.GraphicsDeviceManager)));
            _mainMenuScene.MenuItems.Add(new MainMenuItem(_mainMenuScene.Font, "Instructions", SpriteHelper.GetAbsolutePosition(new Vector2(0.5f, 0.4f), GameManager.GraphicsDeviceManager)));
            _mainMenuScene.MenuItems.Add(new MainMenuItem(_mainMenuScene.Font, "Quit", SpriteHelper.GetAbsolutePosition(new Vector2(0.5f, 0.5f), GameManager.GraphicsDeviceManager)));
            
            _isLoaded = true;
        }

        public void UnloadContent()
        {

        }

        public void UpdateSelectedItem(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _timeSinceLastUpdate += elapsed;

            if (_timeSinceLastUpdate < UpdateInterval)
            {
                return;
            }

            if (IsSelected())
            {
                _mainMenuScene.PlayMenuSelected();
                if (SelectedItemIndex == 0)
                {
                    GameManager.PushState(new PlayingGameState(GameManager));
                }
                if (SelectedItemIndex == 1)
                {
                    //GameManager.PushState(new InstructionsGameState(null));
                }
                if (SelectedItemIndex == 2)
                {
                    GameManager.Quit();
                }
                return;
            }



            if (IsMovingUp())
            {
                SelectedItemIndex--;
                _mainMenuScene.PlayMenuChange();
            }

            if (IsMovingDown())
            {
                SelectedItemIndex++;
                _mainMenuScene.PlayMenuChange();
            }

            for (int i = 0; i < _mainMenuScene.MenuItems.Count; i++)
            {
                _mainMenuScene.MenuItems[i].Color = Color.Black;
                if( i == SelectedItemIndex )
                {
                    _mainMenuScene.MenuItems[i].Color = Color.Red;
                }
            }

            if (SelectedItemIndex < 0)
            {
                SelectedItemIndex = _mainMenuScene.MenuItems.Count - 1;
            }

            if (SelectedItemIndex >= _mainMenuScene.MenuItems.Count)
            {
                SelectedItemIndex = 0;
            }


            _timeSinceLastUpdate -= UpdateInterval;
        }

        public void Update(GameTime gameTime)
        {
            _currentKeyboardState = Keyboard.GetState();
            _currentGamePadState = GamePad.GetState(PlayerIndex.One);

            UpdateSelectedItem(gameTime);

            _previousKeyboardState = _currentKeyboardState;
            _previousGamePadState = _currentGamePadState;
        }

        private bool IsMovingUp()
        {
            return _currentKeyboardState.IsKeyDown(Keys.Up) || _currentGamePadState.ThumbSticks.Left.Y > 0.0f;
        }

        private bool IsMovingDown()
        {
            return _currentKeyboardState.IsKeyDown(Keys.Down) || _currentGamePadState.ThumbSticks.Left.Y < 0.0f;
        }
        private bool IsSelected()
        {
            return _currentKeyboardState.IsKeyDown(Keys.Enter) || _currentGamePadState.Buttons.A == ButtonState.Pressed;
        }
    }
}