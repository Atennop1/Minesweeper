using TMPro;
using UnityEngine;

namespace Minesweeper.Runtime.Tools.LoadSystem
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public sealed class LoadText : MonoBehaviour
    {
        private static TextMeshProUGUI _text;

        private void Start() => _text = GetComponent<TextMeshProUGUI>();

        public static void SetInterest(float interest)
        {
            _text.text = $"{Mathf.Round(interest) * 100f} %";
        }
    }
}
