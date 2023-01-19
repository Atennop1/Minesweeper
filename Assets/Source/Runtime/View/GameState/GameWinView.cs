using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.View.GameState
{
    public class GameWinView : SerializedMonoBehaviour, IGameWinView
    {
        [SerializeField] private GameObject _invisiblePanel;
        [SerializeField] private GameObject _gameWinScreen;
        [SerializeField] private SystemButtonsSetup _systemButtonsSetup;

        public async void Display()
        {
            _systemButtonsSetup.Setup();
            _invisiblePanel.SetActive(true);
            
            await UniTask.Delay(500);
            _gameWinScreen.SetActive(true);
        }
    }
}