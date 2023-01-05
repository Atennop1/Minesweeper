using System;
using System.Collections.Generic;
using System.Linq;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Field;
using Minesweeper.Runtime.Root.SystemUpdates;
using Minesweeper.Runtime.View.GameState;

namespace Minesweeper.Runtime.Model.GameState
{
    public class GameWin : IGameWin, IUpdatable
    {
        public bool IsActivated { get; private set; }

        private readonly ICellsField _cellsField;
        private readonly IGameOver _gameOver;
        private readonly IGameWinView _gameWinView;

        private readonly IEnumerable<ICell> _cellsEnumerable;

        public GameWin(ICellsField cellsField, IGameOver gameOver, IGameWinView gameWinView)
        {
            _cellsField = cellsField ?? throw new ArgumentException("CellsField can't be null");
            _gameOver = gameOver ?? throw new ArgumentException("GameOver can't be null");
            _gameWinView = gameWinView ?? throw new ArgumentException("GameWinView can't be null");

            _cellsEnumerable = from ICell item in _cellsField.Cells select item;
        }

        public void Update()
        {
            if ((_cellsEnumerable.Count(cell => cell.IsFlagged && cell.Data.IsMined) !=
                 _cellsField.FieldData.TotalBombsCount &&
                 _cellsEnumerable.Count(cell => !cell.IsOpened) != _cellsField.FieldData.TotalBombsCount) ||
                _gameOver.IsActivated || IsActivated) return;
            
            _gameWinView.Display();
            IsActivated = true;
        }
    }
}