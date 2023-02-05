using Minesweeper.Runtime.Model.Settings;
using Minesweeper.Runtime.Tools.SaveSystem;
using UnityEngine;

namespace Minesweeper.Runtime.View.GameState
{
    public class GameStartView : MonoBehaviour, IGameStartView
    {
        [SerializeField] private GameObject _needToTurnOn;
        [SerializeField] private GameObject _needToHideWhenClassicInput;

        public void Display()
        {
            _needToTurnOn.SetActive(true);
            var inputTypeContainer = new InputTypeContainer();

            if ((InputType)inputTypeContainer.GetInputTypeIndex() == InputType.Classic)
                _needToHideWhenClassicInput.SetActive(false);
        }
    }
}