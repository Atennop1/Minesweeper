using System;
using Minesweeper.Runtime.Model.Field;

namespace Minesweeper.Runtime.Model.Settings
{
    public class CellsFieldDataContainer : IContainer<CellsFieldData>
    {
        private const string SAVE_PATH = "CellsFieldData";
        private readonly Container<CellsFieldData> _container;

        public CellsFieldDataContainer(Container<CellsFieldData> container)
            => _container = container ?? throw new ArithmeticException(nameof(container));

        public void Set(CellsFieldData value)
            => _container.Set(value, SAVE_PATH);

        public CellsFieldData Get()
            => _container.Get(SAVE_PATH);
    }
}