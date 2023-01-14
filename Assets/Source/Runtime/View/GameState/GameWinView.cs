using Cysharp.Threading.Tasks;
using Minesweeper.Runtime.Model.Buttons;
using Minesweeper.Runtime.Model.Buttons.ButtonActions;
using Minesweeper.Runtime.Tools.LoadSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.View.GameState
{
    public class GameWinView : SerializedMonoBehaviour, IGameWinView
    {
        [SerializeField] private GameObject _invisiblePanel;
        [SerializeField] private GameObject _gameWinScreen;
        
        [Space]
        [SerializeField] private IButton _restartButton;
        [SerializeField] private SceneData _sceneData;

        public async void Display()
        {
            _restartButton.AddListener(new LoadSceneButtonAction(_sceneData));
            _invisiblePanel.SetActive(true);
            
            await UniTask.Delay(500);
            _gameWinScreen.SetActive(true);
        }
    }
}