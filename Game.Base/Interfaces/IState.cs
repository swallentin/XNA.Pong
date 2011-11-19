using Microsoft.Xna.Framework;

namespace Game.Base.Interfaces
{
    public interface IState<TEntityType>
    {
        void Update(ref TEntityType entity);
        void Load(ref TEntityType entity);
        void Unload(ref TEntityType entity);
    }
}