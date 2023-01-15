using System;
using Minesweeper.Runtime.View.Cells;

namespace Minesweeper.Runtime.Model.Cells
{
    public class Cell : ICell
    {
        public CellData Data { get; }
        public bool IsOpened { get; private set; }
        public bool IsFlagged { get; private set; }

        private readonly ICellView _cellView;

        public Cell(ICellView cellView, CellData data)
        {
            Data = data;
            _cellView = cellView ?? throw new ArgumentException("CellView can't be null");
            _cellView.InitCell(this);
        }

        public void SetFlag()
        {
            if (IsFlagged)
                throw new ArgumentException("Can't set flag to cell with flag");
            
            _cellView.InitCell(this);
            
            IsFlagged = true;
            _cellView.Display();
        }

        public void RemoveFlag()
        {
            if (!IsFlagged)
                throw new ArgumentException("Can't remove flag from cell without flag");

            _cellView.InitCell(this);
            
            IsFlagged = false;
            _cellView.Display();
        }

        public void Open()
        {
            IsOpened = true;
            IsFlagged = false;
            _cellView.Display();
        }
    }
}