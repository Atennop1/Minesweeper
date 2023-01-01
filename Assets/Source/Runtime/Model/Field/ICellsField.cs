using Minesweeper.Runtime.Model.Cells;

namespace Minesweeper.Runtime.Model.Field
{
    public interface ICellsField
    {
        void OpenCell(ICell cell);
    }
}