namespace Minesweeper.Runtime.Model.GameState
{
    public interface IGameStart
    {
        bool IsActivated { get; }
        void Activate();
    }
}