using Microsoft.Xna.Framework;

namespace Game.Base.Interfaces
{
    public interface ICollisionManager
    {
        void PerformCollisionCheck(ISpriteEntity spriteEntityA, ISpriteEntity spriteEntityB);
        bool PerformCollisionCheck(Rectangle a, Rectangle b);
        Rectangle GetBoundingBox(ISpriteEntity spriteEntity); 
        event CollisionEventHandler Collision;
    }
}
