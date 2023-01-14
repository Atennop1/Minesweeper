using UnityEngine.SceneManagement;

namespace Minesweeper.Runtime.Tools.LoadSystem
{
    public class SceneLoader : ISceneLoader
    {
        public void Load(SceneData sceneData) => SceneManager.LoadSceneAsync(sceneData.Name);
    }
}