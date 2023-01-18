using System;
using UnityEngine.SceneManagement;

namespace Minesweeper.Runtime.Tools.LoadSystem
{
    public sealed class SceneLoaderWithScreenFade : ISceneLoader
    {
        private readonly IScreenFade _screen;
        private SceneData _nextScene;

        public SceneLoaderWithScreenFade(IScreenFade screen)
        {
            _screen = screen ?? throw new ArgumentNullException(nameof(screen));
            _screen.OnDarkened += FadeOut;
        }

        public void Load(SceneData sceneData)
        {
            _nextScene = sceneData;
            _screen.FadeIn();
        }
        
        private void FadeOut()
        {
            SceneManager.LoadSceneAsync(_nextScene.Name);
            _screen.FadeOut();
            _screen.OnDarkened -= FadeOut;
        }
    }
}
