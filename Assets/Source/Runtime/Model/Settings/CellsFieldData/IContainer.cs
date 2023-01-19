namespace Minesweeper.Runtime.Model.Settings
{
    public interface IContainer<T>
    {
        void Set(T value);
        T Get();
    }
}