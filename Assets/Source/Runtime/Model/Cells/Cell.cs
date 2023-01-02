using System;
using Minesweeper.Runtime.Model.GameState;

namespace Minesweeper.Runtime.Model.Cells
{
    public class Cell : ICell
    {
        public CellData Data { get; }
        public bool IsOpened { get; private set; }
        
        private readonly IGameOverHandler _gameOverHandler;

        public Cell(IGameOverHandler gameOverHandler, CellData data)
        {
            Data = data;
            _gameOverHandler = gameOverHandler ?? throw new ArgumentException("GameOverHandler can't be null");
        }

        public void Open()
        {
            IsOpened = true;

            if (Data.IsMined)
                _gameOverHandler.Handle();
        }
    }
}