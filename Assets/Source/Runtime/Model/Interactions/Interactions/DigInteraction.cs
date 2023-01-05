using System;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Field;

namespace Minesweeper.Runtime.Model.Interactions
{
    public class DigInteraction : IInteraction
    {
        private readonly ICellsField _cellsField;

        public DigInteraction(ICellsField cellsField)
        {
            _cellsField = cellsField ?? throw new ArgumentException("Cells field can't be null");
        }

        public void Interact(ICell cell)
        {
            if (!cell.IsFlagged)
                _cellsField.OpenCell(cell);
        }
    }
}