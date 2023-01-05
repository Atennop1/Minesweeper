using Cysharp.Threading.Tasks;
using Minesweeper.Runtime.Model.LoadSystem;
using UnityButton = UnityEngine.UI.Button;
using UnityEngine;

namespace Minesweeper.Runtime.View.GameState
{
    public class GameWinView : MonoBehaviour, IGameWinView
    {
        [SerializeField] private GameObject _invisiblePanel;
        [SerializeField] private GameObject _gameWinScreen;
        
        [Space]
        [SerializeField] private UnityButton _restartButton;
        [SerializeField] private SceneData _sceneData;

        public async void Display()
        {
            _restartButton.onClick.AddListener(() => new SceneLoader().Load(_sceneData));
            _invisiblePanel.SetActive(true);
            
            await UniTask.Delay(500);
            _gameWinScreen.SetActive(true);
        }
    }
}