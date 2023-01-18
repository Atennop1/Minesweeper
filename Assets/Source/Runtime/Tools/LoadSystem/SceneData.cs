using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Minesweeper.Runtime.Tools.LoadSystem
{
    [CreateAssetMenu(fileName = "Scene", menuName = "Create/Scene Data")]
    public sealed class SceneData : ScriptableObject, ISerializationCallbackReceiver
    {
#if UNITY_EDITOR

        [SerializeField, Required] private SceneAsset _scene;
#endif
        [field: SerializeField] public string Name { get; private set; }

        public void OnAfterDeserialize() { }

        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR

            if (_scene != null)
                Name = _scene.name;
#endif
        }

        [Button("Validate", ButtonSizes.Large, ButtonStyle.CompactBox), GUIColor(1, 1, 1)]
        public void Validate()
        {
            var existsInBuildingSettings = false;

            for (var i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                if (SceneUtility.GetScenePathByBuildIndex(i).Contains(Name))
                    existsInBuildingSettings = true;
            }

            if (existsInBuildingSettings) Debug.Log("Successfully validated!");
            else Debug.LogError("Scene doesn't exist in building settings!");
        }
    }
}