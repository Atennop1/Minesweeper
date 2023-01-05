using Minesweeper.Runtime.Model.Field;
using Minesweeper.Runtime.Model.GameState;
using Minesweeper.Runtime.Root.SystemUpdates;
using Minesweeper.Runtime.View.GameState;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.Root
{
    public class GameStateRoot : SerializedMonoBehaviour
    {
        [SerializeField] private IGameStartView _gameStartView;
        [SerializeField] private IGameOverView _gameOverView;
        [SerializeField] private IGameWinView _gameWinView;
        private SystemUpdate _systemUpdate;

        public void Compose(ICellsField _cellsField)
        {
            _systemUpdate = new SystemUpdate();
            var gameStart = new GameStart(_gameStartView);
            gameStart.Activate();

            var gameOver = new GameOver(_gameOverView, _cellsField.Cells);
            _systemUpdate.AddUpdatable(gameOver);

            var gameWin = new GameWin(_cellsField, gameOver, _gameWinView);
            _systemUpdate.AddUpdatable(gameWin);
        }

        private void Update() => _systemUpdate?.UpdateAll();
    }
}