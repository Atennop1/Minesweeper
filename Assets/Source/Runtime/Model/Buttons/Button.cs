using System;
using Minesweeper.Runtime.Model.Buttons.ClickActions;
using UnityEngine;
using UnityButton = UnityEngine.UI.Button;

namespace Minesweeper.Runtime.Model.Buttons
{
    [RequireComponent(typeof(UnityButton))]
    public class Button : MonoBehaviour, IButton
    {
        [SerializeField] private UnityButton _button;

        public void AddListener(IButtonClickAction action)
        {
            if (action == null)
                throw new ArgumentException("ButtonClickAction can't be null");
            
            _button.onClick.AddListener(action.Invoke);
        }

        private void OnDisable() => _button.onClick.RemoveAllListeners();
        private void OnEnable() => _button = GetComponent<UnityButton>();
    }
}