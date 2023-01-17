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
        [SerializeField] private Action _onClick;
        
        private readonly List<IButtonAction> _holdingActions = new();

        private bool _isHolding;
        private bool _isHoldingComplete;
        
        private void OnDestroy()
        {
            RemoveAllListeners();
            RemoveAllHoldListeners();
        }

        public void RemoveAllListeners()
            => _onClick = null;

        public void RemoveAllHoldListeners()
            => _holdingActions.Clear();

        public void AddListener(IButtonAction action)
        {
            if (action == null)
                throw new ArgumentException("ButtonClickAction can't be null");
            
            _onClick += action.Invoke;
        }
        
        public void AddListener(Action action)
        {
            _onClick += action 
                        ?? throw new ArgumentException("ButtonClickAction can't be null");
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
            var timer = 0f;

            while (timer < _timeNeededToHoldInMilliseconds)
            {
                if (!_isHolding) 
                    return;
                
                timer += Time.deltaTime * 1000;
                await UniTask.Yield();
            }

            _holdingActions.ToList().ForEach(action => action.Invoke());
            _isHoldingComplete = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!_isHoldingComplete)
                _onClick?.Invoke();

            _isHoldingComplete = false;
            _isHolding = false;
        }
    }
}