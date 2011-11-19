using System;
using Game.Base.Interfaces;
using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;
using XNA.Pong.Scenes;

namespace XNA.Pong.GameState
{
    public class InstructionsGameState : IGameState
    {
        private IView _instructions;
        public InstructionsGameState(Microsoft.Xna.Framework.Game game)
        {
            Game = game;
            _instructions = new InstructionsView(Game);
        }

        public Microsoft.Xna.Framework.Game Game
        {
            get; set; 
        }

        public void LoadContent()
        {
            _instructions.LoadContent(); ;
        }

        public void UnloadContent()
        {
            _instructions.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            _instructions.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            _instructions.Draw(gameTime);
        }

        public bool IsActive
        {
            get; set;
        }
    }
}