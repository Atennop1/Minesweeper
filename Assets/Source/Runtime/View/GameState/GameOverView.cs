using Cysharp.Threading.Tasks;
using Minesweeper.Runtime.Model.LoadSystem;
using UnityButton = UnityEngine.UI.Button;
using UnityEngine;

namespace Minesweeper.Runtime.View.GameState
{
    public class GameOverView : MonoBehaviour, IGameOverView
    {
        [SerializeField] private GameObject _invisiblePanel;
        [SerializeField] private GameObject _gameOverScreen;
        
        [Space]
        [SerializeField] private UnityButton _restartButton;
        [SerializeField] private SceneData _sceneData;

        public async void Display()
        {
            _restartButton.onClick.AddListener(() => new SceneLoader().Load(_sceneData));
            _invisiblePanel.SetActive(true);
            
            await UniTask.Delay(500);
            _gameOverScreen.SetActive(true);
        }
    }
}