namespace Minesweeper.Runtime.Root.SystemUpdates
{
    public interface ISystemUpdate
    {
        void UpdateAll();
        void AddUpdatable(IUpdatable updatable);
        void RemoveUpdatable(IUpdatable updatable);
    }
}