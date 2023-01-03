using System;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Field;

namespace Minesweeper.Runtime.Model.InteractionsWithCell
{
    public class DigInteractionWithCell : IInteractionWithCell
    {
        private readonly ICellsField _cellsField;

        public DigInteractionWithCell(ICellsField cellsField)
        {
            _cellsField = cellsField ?? throw new ArgumentException("Cells field can't be null");
        }

        public void Interact(ICell cell) => _cellsField.OpenCell(cell);
    }
}