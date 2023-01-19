using System;
using Minesweeper.Runtime.Tools.SaveSystem;

namespace Minesweeper.Runtime.Model.Settings
{
    public sealed class Container<T>
    {
        private readonly BinaryStorage _binaryStorage = new();
        private readonly T _defaultValue;

        public Container(T defaultValue)
            => _defaultValue = defaultValue ?? throw new ArgumentNullException(nameof(defaultValue));

        public void Set(T value, string path)
            => _binaryStorage.Save(value, path);

        public T Get(string path)
            => _binaryStorage.LoadOrDefault(path, _defaultValue);
    }
}