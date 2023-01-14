using Minesweeper.Runtime.Model.Buttons;
using Minesweeper.Runtime.Model.Buttons.ButtonActions;
using Minesweeper.Runtime.Tools.LoadSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.Root
{
    public class MenuRoot : SerializedMonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _quitButton;

        [Space]
        [SerializeField] private SceneData _gameSceneData;
        [SerializeField] private GameObject _mainScreen;
        [SerializeField] private GameObject _settingsScreen;
        
        private void Awake()
        {
            _playButton.AddListener(new LoadSceneButtonAction(_gameSceneData));
            _settingsButton.AddListener(new SwitchScreenButtonAction(_mainScreen, _settingsScreen));
            _quitButton.AddListener(new QuitGameButtonAction());
        }
    }
}