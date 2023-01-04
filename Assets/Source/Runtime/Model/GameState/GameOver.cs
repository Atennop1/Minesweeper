using System;
using System.Collections.Generic;
using System.Linq;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Root.SystemUpdates;
using Minesweeper.Runtime.View.GameState;

namespace Minesweeper.Runtime.Model.GameState
{
    public class GameOver : IGameOver, IUpdatable
    {
        public bool IsActivated { get; private set; }

        private readonly IGameOverView _gameOverView;
        private readonly IEnumerable<ICell> _cells;

        public GameOver(IGameOverView gameOverView, ICell[,] cells)
        {
            if (cells == null)
                throw new ArgumentException("Cells can't be null");

            _cells = from ICell item in cells select item;
            _gameOverView = gameOverView ?? throw new ArgumentException("GameOverView can't be null");
        }
        
        public void Update()
        {
            if (!IsActivated && _cells.Any(cell => cell.IsOpened && cell.Data.IsMined))
                Activate();
        }

        private void Activate()
        {
            _gameOverView.Display();
            IsActivated = true;
        }
    }
}