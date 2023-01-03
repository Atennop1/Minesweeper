using System;
using Minesweeper.Runtime.Model.Field;
using Minesweeper.Runtime.Model.InteractionsWithCell;
using UnityEngine;
using UnityEngine.UI;

namespace Minesweeper.Runtime.View.InteractionsWIthCell
{
    public class InteractionWithCellSelectorView : MonoBehaviour, IInteractionWithCellSelectorView
    {
        [SerializeField] private Image _digInteractionSelectedImage;
        [SerializeField] private Image _flagInteractionSelectedImage;
        
        [SerializeField] private Button _digInteractionButton;
        [SerializeField] private Button _flagInteractionButton;
        
        private IInteractionWithCellSelector _selector;
        private ICellsField _cellsField;
        
        private void Start()
        {
            _flagInteractionButton.onClick.AddListener(() =>
            {
                _selector.Select(new FlagInteractionWithCell());
                Display(_selector);
            });
            
            _digInteractionButton.onClick.AddListener(() =>
            {
                _selector.Select(new DigInteractionWithCell(_cellsField));
                Display(_selector);
            });
            
            _digInteractionButton.onClick.Invoke();
        }
        
        public void Init(IInteractionWithCellSelector selector, ICellsField cellsField)
        {
            _selector = selector ?? throw new ArgumentException("Selector can't be null");
            _cellsField = cellsField ?? throw new ArgumentException("CellsField can't be null");
        }

        public void Display(IInteractionWithCellSelector selector)
        {
            if (_selector.CurrentInteraction.GetType() == typeof(FlagInteractionWithCell))
            {
                _flagInteractionSelectedImage.enabled = true;
                _digInteractionSelectedImage.enabled = false;
            }
            
            if (_selector.CurrentInteraction.GetType() == typeof(DigInteractionWithCell))
            {
                _flagInteractionSelectedImage.enabled = false;
                _digInteractionSelectedImage.enabled = true;
            }
        }
    }
}