using System;
using Minesweeper.Runtime.Model.Buttons;
using Minesweeper.Runtime.Model.Buttons.ButtonActions;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Interactions;
using Minesweeper.Runtime.Model.Settings;
using Minesweeper.Runtime.Tools.SaveSystem;
using Minesweeper.Runtime.View.BombsCountView;
using Minesweeper.Runtime.View.Flag;
using Sirenix.OdinInspector;
using UnityEngine;

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
        private readonly BinaryStorage _inputTypeStorage = new();

        public void InitSelector(IInteractionSelector interactionSelector)
            => _interactionSelector = interactionSelector ?? throw new ArgumentException("InteractionSelector can't be null");

        public void Display(ICell cell)
        {
            if (cell == null)
                throw new InvalidOperationException("Cell can't be null");

            InitButtons(cell);
            _flagView.Display(cell);
            _bombsCountView.Display(cell.Data.CountOfBombsNearby);

            if (cell.IsOpened)
                _usingButton.enabled = false;

            switch (cell.IsOpened)
            {
                case true when cell.Data.IsMined:
                    _cellAnimations.PlayExplosionAnimation();
                    return;
                
                case true:
                    _cellAnimations.PlayOpenAnimation();
                    break;
            }
        }
        
        private void InitButtons(ICell cell)
        {
            _usingButton.RemoveAllListeners();
            _usingButton.RemoveAllHoldListeners();
            
            _usingButton.AddListener(() => new InteractButtonAction(cell, _interactionSelector.CurrentInteraction).Invoke());
            var inputTypeContainer = new InputTypeContainer();

            if ((InputType)inputTypeContainer.GetInputTypeIndex() == InputType.Classic)
                _usingButton.AddHoldListener(new InteractButtonAction(cell, _interactionSelector.CurrentHoldInteraction));
        }
    }
}