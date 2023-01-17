using Minesweeper.Runtime.Factories;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.Tools.LoadSystem
{
    public sealed class SceneLoader : MonoBehaviour, ISceneLoader
    {
        [SerializeField] private SceneLoadMode _mode;

        [SerializeField, ShowIf("_mode", SceneLoadMode.WithFadeScreen)]
        private ScreenFade _screen;

        [SerializeField, ShowIf("_mode", SceneLoadMode.WithLoadScreen)]
        private SceneData _loaderScene;
        
        public void Load(SceneData sceneData)
        {
            var factory = new SceneLoaderFactory(_mode, _screen, _loaderScene);
            var sceneLoader = factory.Create();
            sceneLoader.Load(sceneData);
        }
    }
}