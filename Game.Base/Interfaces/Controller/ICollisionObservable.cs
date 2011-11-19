
namespace Game.Base.Interfaces.Controller
{
    public interface ICollisionObservable
    {
        void RegisterCollisionObserver(string entityName, ICollisionObserver collisionObserver);
        void UnRegisterCollisionObserver(ICollisionObserver collisionObserver);
    }
}