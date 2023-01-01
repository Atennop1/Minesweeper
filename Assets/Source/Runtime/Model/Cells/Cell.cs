namespace Minesweeper.Runtime.Model.Cells
{
    public class Cell : ICell
    {
        public CellData Data { get; }
        public bool IsOpened { get; private set; }
        

        public Cell(CellData data) => Data = data;
        public void Open() =>  IsOpened = true;
    }
}