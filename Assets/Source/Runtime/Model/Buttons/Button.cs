using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Minesweeper.Runtime.Model.Buttons.ButtonActions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityButton = UnityEngine.UI.Button;

namespace Minesweeper.Runtime.Model.Buttons
{
    public class Button : MonoBehaviour, IButton, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private int _timeNeededToHoldInMilliseconds;
        
        private readonly List<IButtonAction> _holdingActions = new();
        private readonly List<IButtonAction> _clickActions = new();
        
        private bool _isHolding;
        private bool _isHoldingComplete;
        
        private void OnDestroy()
        {
            _clickActions.Clear();
            _holdingActions.Clear();
        }

        public void AddListener(IButtonAction action)
        {
            if (action == null)
                throw new ArgumentException("ButtonClickAction can't be null");
            
            _clickActions.Add(action);
        }

        public void AddHoldListener(IButtonAction action)
        {
            if (action == null)
                throw new ArgumentException("ButtonClickAction can't be null");
            
            _holdingActions.Add(action);
        }
        
        public async void OnPointerDown(PointerEventData eventData)
        {
            _isHolding = true;
            await UniTask.Delay(_timeNeededToHoldInMilliseconds);

            if (!_isHolding) 
                return;
            
            _holdingActions.ToList().ForEach(action => action.Invoke());
            _isHoldingComplete = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!_isHoldingComplete)
                _clickActions.ToList().ForEach(action => action.Invoke());

            _isHoldingComplete = false;
            _isHolding = false;
        }
    }
}