namespace Minesweeper.Runtime.Tools.SaveSystem
{
    public interface IStorage
    {
        void Save<T>(T item, string path);
        T Load<T>(string path);
        T LoadOrDefault<T>(string path, T defaultValue);

        bool Exists(string path);
        void DeleteSave(string path);
    }
}