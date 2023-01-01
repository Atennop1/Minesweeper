namespace Minesweeper.Runtime.Model.Cells
{
    public interface ICell
    {
        CellData Data { get; }
        bool IsOpened { get; }
        void Open();
    }
}