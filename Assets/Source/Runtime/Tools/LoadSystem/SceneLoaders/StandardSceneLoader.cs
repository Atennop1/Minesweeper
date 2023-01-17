using UnityEngine.SceneManagement;

namespace Minesweeper.Runtime.Tools.LoadSystem
{
    public sealed class StandardSceneLoader : ISceneLoader
    {
        public void Load(SceneData sceneData)
            => SceneManager.LoadSceneAsync(sceneData.name);
    }
}
