using System;
using System.ComponentModel;
using Minesweeper.Runtime.Tools.LoadSystem;

namespace Minesweeper.Runtime.Factories
{
    public sealed class SceneLoaderFactory
    {
        private readonly SceneLoadMode _sceneLoadMode;
        private readonly IScreenFade _screenFade;
        private readonly SceneData _loaderScene;

        public SceneLoaderFactory(SceneLoadMode sceneLoadMode, IScreenFade screenFade, SceneData loaderScene)
        {
            if (!Enum.IsDefined(typeof(SceneLoadMode), sceneLoadMode))
                throw new InvalidEnumArgumentException(nameof(sceneLoadMode), (int)sceneLoadMode,
                    typeof(SceneLoadMode));

            _sceneLoadMode = sceneLoadMode;
            _screenFade = screenFade;
            _loaderScene = loaderScene;
        }

        public ISceneLoader Create()
        {
            return _sceneLoadMode switch
            {
                SceneLoadMode.Simple => new StandardSceneLoader(),
                SceneLoadMode.WithFadeScreen => new SceneLoaderWithScreenFade(_screenFade),
                SceneLoadMode.WithLoadScreen => new SceneLoaderWithScreen(_loaderScene),
                _ => throw new ArgumentOutOfRangeException(nameof(_sceneLoadMode))
            };
        }

    }
}