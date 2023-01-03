using System;
using Minesweeper.Runtime.Model.GameState;

namespace Minesweeper.Runtime.Model.Cells
{
    public class Cell : ICell
    {
        public CellData Data { get; }
        public bool IsOpened { get; private set; }
        public bool IsFlagged { get; private set; }
        
        private readonly IGameOverHandler _gameOverHandler;

        public Cell(IGameOverHandler gameOverHandler, CellData data)
        {
            Data = data;
            _gameOverHandler = gameOverHandler ?? throw new ArgumentException("GameOverHandler can't be null");
        }

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

            if (Data.IsMined)
                _gameOverHandler.Handle();
        }
    }
}