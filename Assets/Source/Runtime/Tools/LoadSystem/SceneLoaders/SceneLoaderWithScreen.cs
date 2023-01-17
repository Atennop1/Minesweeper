using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Minesweeper.Runtime.Tools.LoadSystem
{
    public sealed class SceneLoaderWithScreen : ISceneLoader
    {
        private readonly SceneData _loaderScene;
        private AsyncOperation _loadScreen;
        private AsyncOperation _nextSceneLoad;
        private SceneData _nextScene;

        public SceneLoaderWithScreen(SceneData loaderScene) 
            => _loaderScene = loaderScene ? loaderScene : throw new ArgumentNullException(nameof(loaderScene));

        public void Load(SceneData sceneData)
        {
            _loadScreen = SceneManager.LoadSceneAsync(_loaderScene.Name, LoadSceneMode.Additive);
            _nextScene = sceneData;
            _loadScreen.completed += LoadNext;
        }
        
        private void LoadNext(AsyncOperation operation)
        {
            _nextSceneLoad = SceneManager.LoadSceneAsync(_nextScene.name);
            ChangeLoadText();
            _loadScreen.completed -= LoadNext;
        }
        
        private async void ChangeLoadText()
        {
            while (!_nextSceneLoad.isDone)
            {
                await Task.Yield();
                LoadText.SetInterest(_nextSceneLoad.progress);
            }
        }
    }
}
