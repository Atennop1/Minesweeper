using System;
using Minesweeper.Runtime.Model.Buttons.ButtonActions;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Interactions;
using Minesweeper.Runtime.View.BombsCountView;
using Minesweeper.Runtime.View.Flag;
using Sirenix.OdinInspector;
using UnityEngine;
using Button = Minesweeper.Runtime.Model.Buttons.Button;

namespace Minesweeper.Runtime.View.Cells
{
    public class CellView : SerializedMonoBehaviour, ICellView
    {
        [SerializeField] private IFlagView _flagView;
        [SerializeField] private IBombsCountView _bombsCountView;

        [Space]
        [SerializeField] private ICellAnimations _cellAnimations;
        [SerializeField] private Button _usingButton;
        
        private IInteractionSelector _interactionSelector;
        private ICell _cell;

        public void InitCell(ICell cell)
            => _cell = cell ?? throw new ArgumentNullException(nameof(cell));

        public void InitSelector(IInteractionSelector interactionSelector)
            => _interactionSelector = interactionSelector ?? throw new ArgumentException("InteractionSelector can't be null");

        public void Display()
        {
            if (_cell == null)
                throw new InvalidOperationException("Cell can't be null");

            SetupUsingButton();
            _flagView.Display(_cell);
            _bombsCountView.Display(_cell.Data.CountOfBombsNearby);

            if (_cell.IsOpened)
                _usingButton.enabled = false;
            
            switch (_cell.IsOpened)
            {
                case true when _cell.Data.IsMined:
                    _cellAnimations.PlayExplosionAnimation();
                    return;
                
                case true:
                    _cellAnimations.PlayOpenAnimation();
                    break;
            }
        }
        
        private void SetupUsingButton()
        {
            _usingButton.RemoveAllListeners();
            _usingButton.RemoveAllHoldListeners();
            
            _usingButton.AddListener(new InteractButtonAction(_cell, _interactionSelector.CurrentInteraction));
            _usingButton.AddHoldListener(new InteractButtonAction(_cell, _interactionSelector.CurrentHoldInteraction));
        }
    }
}