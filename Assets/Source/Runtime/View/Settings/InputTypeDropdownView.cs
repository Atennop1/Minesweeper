using Minesweeper.Runtime.Model.Settings;
using TMPro;
using UnityEngine;

namespace Minesweeper.Runtime.View.Settings
{
    public class InputTypeDropdownView : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdown;

        private void Awake()
        {
            var inputTypeContainer = new InputTypeContainer();
            _dropdown.onValueChanged.AddListener(index => inputTypeContainer.SetInputType(index));
            _dropdown.value = inputTypeContainer.GetInputTypeIndex();
        }
    }
}