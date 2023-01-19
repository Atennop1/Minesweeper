using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.View.GameState
{
    public class GameOverView : SerializedMonoBehaviour, IGameOverView
    {
        [SerializeField] private GameObject _invisiblePanel;
        [SerializeField] private GameObject _gameOverScreen;
        [SerializeField] private SystemButtonsSetup _systemButtonsSetup;

        public async void Display()
        {
            _systemButtonsSetup.Setup();
            _invisiblePanel.SetActive(true);
            
            await UniTask.Delay(500);
            _gameOverScreen.SetActive(true);
        }
    }
}