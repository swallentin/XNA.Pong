namespace XNA.Pong.GameState
{
    public interface IGameScoreObservable
    {
        void RegisterObserver(IGameScoreObserver gameScoreObservable);
        void UnregisterObserver(IGameScoreObserver gameScoreObservable);
    }
}