using Microsoft.Xna.Framework;

namespace Game.Base.Interfaces
{
    public interface IGameState:IGame
    {
        void LoadContent();
        void UnloadContent();
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);

        bool IsActive { get; set; }
    }
}
