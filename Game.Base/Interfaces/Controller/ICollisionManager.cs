
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;

namespace Game.Base.Interfaces.Controller
{
    public interface ICollisionManager:ICollisionObservable
    {
        void PerformCollisionCheck(ISpriteEntity spriteEntityA, ISpriteEntity spriteEntityB);
        bool PerformCollisionCheck(Rectangle a, Rectangle b);
        Rectangle GetBoundingBox(ISpriteEntity spriteEntity); 
        void RegisterCollision(ISpriteEntity spriteEntity);
        void UnregisterCollision(ISpriteEntity spriteEntity);
    }
}
