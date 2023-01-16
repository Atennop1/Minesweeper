﻿using Cysharp.Threading.Tasks;
using Minesweeper.Runtime.Model.Buttons;
using Minesweeper.Runtime.Model.Buttons.ButtonActions;
using Minesweeper.Runtime.Tools.LoadSystem;
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
        [SerializeField] private IButton _toMenuButton;
        
        [Space]
        [SerializeField] private SceneData _gameSceneData;
        [SerializeField] private SceneData _menuSceneData;

        public async void Display()
        {
            _restartButton.AddListener(new LoadSceneButtonAction(_gameSceneData));
            _toMenuButton.AddListener(new LoadSceneButtonAction(_menuSceneData));
            _invisiblePanel.SetActive(true);
            
            await UniTask.Delay(500);
            _gameOverScreen.SetActive(true);
        }
    }
}