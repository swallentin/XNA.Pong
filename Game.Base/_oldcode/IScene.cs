using Microsoft.Xna.Framework;

namespace Game.Base.Interfaces
{
    public interface IScene
    {
        void LoadContent();
        void UnloadContent();
        void Update(GameTime gameTime);
        void Draw(GameTime gameTimet);

    }
}
