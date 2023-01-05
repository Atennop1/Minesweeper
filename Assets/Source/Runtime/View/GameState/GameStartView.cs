using UnityEngine;

namespace Minesweeper.Runtime.View.GameState
{
    public class GameStartView : MonoBehaviour, IGameStartView
    {
        [SerializeField] private GameObject _needToTurnOn;
        
        public void Display() => _needToTurnOn.SetActive(true);
    }
}