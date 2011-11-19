using Microsoft.Xna.Framework;

namespace Game.Base.Interfaces
{
    public interface IState<T>
    {
        void Update(GameTime gameTime, ref T state);
        void Load(ref T state);
        void Unload(ref T state);
    }
}