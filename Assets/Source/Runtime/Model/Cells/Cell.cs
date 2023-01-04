using System;

namespace Minesweeper.Runtime.Model.Cells
{
    public class Cell : ICell
    {
        public CellData Data { get; }
        public bool IsOpened { get; private set; }
        public bool IsFlagged { get; private set; }

        public Cell(CellData data) => Data = data;

        public void SetFlag()
        {
            if (IsFlagged)
                throw new ArgumentException("Can't set flag to cell with flag");
                
            IsFlagged = true;
        }

        public void RemoveFlag()
        {
            if (!IsFlagged)
                throw new ArgumentException("Can't remove flag from cell without flag");

            IsFlagged = false;
        }

        public void Open()
        {
            IsOpened = true;
            
            if (IsFlagged)
                RemoveFlag();
        }
    }
}