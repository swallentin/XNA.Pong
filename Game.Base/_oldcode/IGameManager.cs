using System;

namespace Game.Base.Interfaces
{
    public interface IGameManager
    {
        object this[String key] { get; set; }

        bool IsRunning
        {
            get;
            set;
        }
    
        void Initalize();

        void ChangeState(IGameState gameState);

        void PushState(IGameState gameState);

        void PopState();
    }
}
