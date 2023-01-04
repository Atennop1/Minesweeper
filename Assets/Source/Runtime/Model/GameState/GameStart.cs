using System;
using Minesweeper.Runtime.View.GameState;

namespace Minesweeper.Runtime.Model.GameState
{
    public class GameStart
    {
        private readonly IGameStartView _gameStartView;

        public GameStart(IGameStartView gameStartView)
        {
            _gameStartView = gameStartView ?? throw new ArgumentException("GameStartViw can't be null");
        }

        public void Activate() => _gameStartView.Display();
    }
}