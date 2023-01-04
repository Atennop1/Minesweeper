using Minesweeper.Runtime.Model.Cells;
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
        private SystemUpdate _systemUpdate;
        
        public void Compose(ICell[,] cells)
        {
            _systemUpdate = new SystemUpdate();
            var gameStart = new GameStart(_gameStartView);
            gameStart.Activate();

            var gameOver = new GameOver(_gameOverView, cells);
            _systemUpdate.AddUpdatable(gameOver);
        }

        private void Update() => _systemUpdate?.UpdateAll();
    }
}