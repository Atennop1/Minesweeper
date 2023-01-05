using System;
using Minesweeper.Runtime.Model.Buttons;
using Minesweeper.Runtime.Model.Buttons.ClickActions;
using Minesweeper.Runtime.Model.Interactions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.View.Interactions
{
    public class InteractionSelectorView : SerializedMonoBehaviour, IInteractionSelectorView
    {
        [SerializeField] private IInteractionView _digInteractionView;
        [SerializeField] private IInteractionView _flagInteractionView;
        
        [Space]
        [SerializeField] private IButton _digInteractionButton;
        [SerializeField] private IButton _flagInteractionButton;
        
        private IInteractionSelector _selector;
        private FlagInteraction _flagInteraction;
        private DigInteraction _digInteraction;

        public void Init(IInteractionSelector selector, FlagInteraction flagInteraction, DigInteraction digInteraction)
        {
            _selector = selector ?? throw new ArgumentException("Selector can't be null");
            _flagInteraction = flagInteraction ?? throw new ArgumentException("FlagInteractionWithCell can't be null");
            _digInteraction = digInteraction ?? throw new ArgumentException("DigInteractionWithCell can't be null");
            
            _flagInteractionButton.AddListener(new InteractionSelectButtonAction(this, _selector, _flagInteraction));
            _digInteractionButton.AddListener(new InteractionSelectButtonAction(this, _selector, _digInteraction));
            _digInteractionView.DisplaySelected();
        }

        public void Display(IInteractionSelector selector)
        {
            if (selector.CurrentInteraction == _flagInteraction)
            {
                _digInteractionView.DisplayUnselected();
                _flagInteractionView.DisplaySelected();
            }
            
            if (selector.CurrentInteraction == _digInteraction)
            {
                _digInteractionView.DisplaySelected();
                _flagInteractionView.DisplayUnselected();
            }
        }
    }
}