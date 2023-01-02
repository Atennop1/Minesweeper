using UnityEngine;

namespace Minesweeper.Runtime.View.GameState
{
    public class GameOverView : MonoBehaviour, IGameOverView
    {
        [SerializeField] private GameObject _gameOverScreen;

        public void Display() => _gameOverScreen.SetActive(true);
    }
}