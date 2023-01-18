using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Minesweeper.Runtime.Tools.Extensions
{
    public static class GameObjectExtension
    {
        public static async void DestroyAllChildrenExcept(this GameObject parentGameObject, GameObject gameObject)
        {
            for (var i = 0; i < parentGameObject.transform.childCount; i++)
                if (parentGameObject.transform.GetChild(i).gameObject != gameObject)
                    parentGameObject.transform.GetChild(i).gameObject.DestroyAllChildrenExcept(gameObject);

            await UniTask.Yield();
            if (parentGameObject.transform.childCount == 0 && parentGameObject != gameObject)
                Object.DestroyImmediate(parentGameObject);
        }
    }
}