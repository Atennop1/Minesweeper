using TMPro;
using UnityEngine;

namespace Minesweeper.Runtime.View.Flag
{
    public class FlagsView : MonoBehaviour, IFlagsView
    {
        [SerializeField] private TextMeshProUGUI _countText;

        public void Display(int count) => _countText.text = count.ToString();
    }
}