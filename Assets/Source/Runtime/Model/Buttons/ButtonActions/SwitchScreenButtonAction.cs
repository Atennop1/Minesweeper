using System;
using UnityEngine;

namespace Minesweeper.Runtime.Model.Buttons.ButtonActions
{
    public class SwitchScreenButtonAction : IButtonAction
    {
        private readonly GameObject _objectToTurnOff;
        private readonly GameObject _objectToTurnOn;

        public SwitchScreenButtonAction(GameObject objectToTurnOff, GameObject objectToTurnOn)
        {
            _objectToTurnOff = objectToTurnOff ? objectToTurnOff : throw new ArgumentNullException(nameof(objectToTurnOff));
            _objectToTurnOn = objectToTurnOn ? objectToTurnOn : throw new ArgumentNullException(nameof(objectToTurnOn));
        }

        public void Invoke()
        {
            _objectToTurnOff.SetActive(false);
            _objectToTurnOn.SetActive(true);
        }
    }
}