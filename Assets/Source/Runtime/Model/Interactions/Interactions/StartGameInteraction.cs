using System;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Root;

namespace Minesweeper.Runtime.Model.Interactions
{
    public class StartGameInteraction : IInteraction
    {
        private readonly MainCellsFieldRoot _mainCellsFieldRoot;

        public StartGameInteraction(MainCellsFieldRoot mainCellsFieldRoot)
        {
            _mainCellsFieldRoot = mainCellsFieldRoot
                ? mainCellsFieldRoot
                : throw new ArgumentException("CellsFieldRoot can't be null");
        }

        public void Interact(ICell cell) => _mainCellsFieldRoot.Compose(cell.Data);
    }
}