namespace Minesweeper.Runtime.Model.Cells
{
    public class MinedCell : ICell
    {
        public bool IsOpened { get; }
        public bool IsFlagged { get; }
        public CellData Data { get; }

        public MinedCell(CellData data)
        {
            Data = data;
        }

        public void Open() { }
        public void SetFlag() { }
        public void RemoveFlag() { }
    }
}