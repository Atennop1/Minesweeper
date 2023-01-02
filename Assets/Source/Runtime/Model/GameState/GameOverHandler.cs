using System;
using Minesweeper.Runtime.View.GameState;

namespace Minesweeper.Runtime.Model.GameState
{
    public class GameOverHandler : IGameOverHandler
    {
        private readonly IGameOverView _gameOverView;

        public GameOverHandler(IGameOverView gameOverView)
        {
            _gameOverView = gameOverView ?? throw new ArgumentException("GameOverView can't be null");
        }

        public void Handle() => _gameOverView.Display();
    }
}