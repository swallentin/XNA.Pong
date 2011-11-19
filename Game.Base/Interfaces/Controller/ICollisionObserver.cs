using Game.Base.Interfaces.Model;

namespace Game.Base.Interfaces.Controller
{
    public interface ICollisionObserver
    {
        void CollisionNotification(ISpriteEntity collidingWithSpriteEntity);
    }
}