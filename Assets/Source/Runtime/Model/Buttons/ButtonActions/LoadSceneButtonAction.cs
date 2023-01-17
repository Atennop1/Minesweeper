using System;
using Minesweeper.Runtime.Tools.LoadSystem;

namespace Minesweeper.Runtime.Model.Buttons.ButtonActions
{
    public class LoadSceneButtonAction : IButtonAction
    {
        private readonly SceneData _sceneData;
        private readonly ISceneLoader _sceneLoader;

        public LoadSceneButtonAction(ISceneLoader sceneLoader, SceneData sceneData)
        {
            _sceneLoader = sceneLoader ?? throw new ArgumentNullException(nameof(sceneLoader));
            _sceneData = sceneData ? sceneData : throw new ArgumentNullException(nameof(sceneData));
        }

        public void Invoke() 
            => _sceneLoader.Load(_sceneData);
    }
}