using System;
using Minesweeper.Runtime.Model.LoadSystem;

namespace Minesweeper.Runtime.Model.Buttons.ButtonActions
{
    public class LoadSceneButtonAction : IButtonAction
    {
        private readonly SceneData _sceneData;
        private readonly SceneLoader _sceneLoader = new();

        public LoadSceneButtonAction(SceneData sceneData)
        {
            _sceneData = sceneData ? sceneData : throw new ArgumentNullException(nameof(sceneData));
        }

        public void Invoke() => _sceneLoader.Load(_sceneData);
    }
}