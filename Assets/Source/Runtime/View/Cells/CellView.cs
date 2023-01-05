using System;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Interactions;
using Minesweeper.Runtime.View.BombsCountView;
using Minesweeper.Runtime.View.Flag;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

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

        public void Init(IInteractionSelector interactionSelector)
        {
            _interactionSelector = interactionSelector ?? throw new ArgumentException("Cell can't be null");
        }
        
        public void Display(ICell cell)
        {
            if (cell == null)
                throw new InvalidOperationException("You need to init cell first");

            SetupUsingButton(cell);
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
        
        private void SetupUsingButton(ICell cell)
        {
            if (cell == null)
                throw new InvalidOperationException("You need to init cell first");
            
            _usingButton.onClick.RemoveAllListeners();
            _usingButton.onClick.AddListener(() => _interactionSelector.CurrentInteraction.Interact(cell));
        }
    }
}