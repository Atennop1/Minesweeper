using Minesweeper.Runtime.Model.Cells;

namespace Minesweeper.Runtime.Model.Field
{
    public interface ICellsField
    {
        CellsFieldData FieldData { get; }
        ICell[,] Cells { get; }
        void OpenCell(ICell cell);
    }
}