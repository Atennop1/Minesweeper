using System;
using Minesweeper.Runtime.Model.Interactions;
using UnityEngine;
using UnityEngine.UI;

namespace Minesweeper.Runtime.View.Interactions
{
    public class InteractionSelectorView : MonoBehaviour, IInteractionSelectorView
    {
        [SerializeField] private Image _digInteractionSelectedImage;
        [SerializeField] private Image _flagInteractionSelectedImage;
        
        [SerializeField] private Button _digInteractionButton;
        [SerializeField] private Button _flagInteractionButton;
        
        private IInteractionSelector _selector;
        private FlagInteraction _flagInteraction;
        private DigInteraction _digInteraction;

        private void Start()
        {
            _flagInteractionButton.onClick.AddListener(() =>
            {
                _selector.Select(_flagInteraction);
                Display(_selector);
            });
            
            _digInteractionButton.onClick.AddListener(() =>
            {
                _selector.Select(_digInteraction);
                Display(_selector);
            });
        }
        
        public void Init(IInteractionSelector selector, 
            FlagInteraction flagInteraction,
            DigInteraction digInteraction)
        {
            _selector = selector ?? throw new ArgumentException("Selector can't be null");
            _flagInteraction = flagInteraction ?? throw new ArgumentException("FlagInteractionWithCell can't be null");
            _digInteraction = digInteraction ?? throw new ArgumentException("DigInteractionWithCell can't be null");
        }

        public void Display(IInteractionSelector selector)
        {
            if (_selector.CurrentInteraction == _flagInteraction)
            {
                _flagInteractionSelectedImage.enabled = true;
                _digInteractionSelectedImage.enabled = false;
            }
            
            if (_selector.CurrentInteraction == _digInteraction)
            {
                _flagInteractionSelectedImage.enabled = false;
                _digInteractionSelectedImage.enabled = true;
            }
        }
    }
}