using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Field;

namespace Minesweeper.Runtime.Factories
{
    public interface ICellsFactory
    {
        ICell[,] Create(CellsFieldData cellsFieldData);
    }
}