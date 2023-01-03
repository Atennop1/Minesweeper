namespace Minesweeper.Runtime.Model.Cells
{
    public interface ICell
    {
        bool IsOpened { get; }
        public bool IsFlagged { get; }
        CellData Data { get; }
        
        void Open();
        void SetFlag();
        void RemoveFlag();
    }
}