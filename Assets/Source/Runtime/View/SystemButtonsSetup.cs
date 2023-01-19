using Minesweeper.Runtime.Model.Buttons;
using Minesweeper.Runtime.Model.Buttons.ButtonActions;
using Minesweeper.Runtime.Tools.LoadSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.View
{
    public class SystemButtonsSetup : SerializedMonoBehaviour
    {
        [SerializeField] private IButton _restartButton;
        [SerializeField] private IButton _toMenuButton;
        
        [Space]
        [SerializeField] private SceneData _gameSceneData;
        [SerializeField] private SceneData _menuSceneData;
        [SerializeField] private ISceneLoader _sceneLoader;

        public void Setup()
        {
            _restartButton.AddListener(new LoadSceneButtonAction(_sceneLoader, _gameSceneData));
            _toMenuButton.AddListener(new LoadSceneButtonAction(_sceneLoader, _menuSceneData));
        }
    }
}