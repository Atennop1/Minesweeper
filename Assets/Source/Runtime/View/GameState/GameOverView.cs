using Cysharp.Threading.Tasks;
using Minesweeper.Runtime.Model.Buttons;
using Minesweeper.Runtime.Model.Buttons.ButtonActions;
using Minesweeper.Runtime.Model.LoadSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.View.GameState
{
    public class GameOverView : SerializedMonoBehaviour, IGameOverView
    {
        [SerializeField] private GameObject _invisiblePanel;
        [SerializeField] private GameObject _gameOverScreen;
        
        [Space]
        [SerializeField] private IButton _restartButton;
        [SerializeField] private SceneData _sceneData;

        public async void Display()
        {
            _restartButton.AddListener(new LoadSceneButtonAction(_sceneData));
            _invisiblePanel.SetActive(true);
            
            await UniTask.Delay(500);
            _gameOverScreen.SetActive(true);
        }
    }
}