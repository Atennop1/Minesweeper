using System;
using Minesweeper.Runtime.Model.Buttons.ButtonActions;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Interactions;
using Minesweeper.Runtime.Model.Settings;
using Minesweeper.Runtime.Tools.SaveSystem;
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
        [SerializeField] private Button _unityUsingButton;
        [SerializeField] private Model.Buttons.Button _usingButton;
        
        private IInteractionSelector _interactionSelector;
        private readonly BinaryStorage _inputTypeStorage = new();
        private ICell _cell;

        public void InitCell(ICell cell)
            => _cell = cell ?? throw new ArgumentNullException(nameof(cell));

        public void InitSelector(IInteractionSelector interactionSelector)
            => _interactionSelector = interactionSelector ?? throw new ArgumentException("InteractionSelector can't be null");

        public void Display()
        {
            if (_cell == null)
                throw new InvalidOperationException("Cell can't be null");
            
            _flagView.Display(_cell);
            _bombsCountView.Display(_cell.Data.CountOfBombsNearby);

            if (_cell.IsOpened)
            {
                _unityUsingButton.enabled = false;
                _unityUsingButton.enabled = false;
            }

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
        
        private void Awake()
        {
            _unityUsingButton.onClick.AddListener(() => new InteractButtonAction(_cell, _interactionSelector.CurrentInteraction).Invoke());
            
            if (_inputTypeStorage.Load<InputType>("InputType") == InputType.Classic)
                _usingButton.AddHoldListener(new InteractButtonAction(_cell, _interactionSelector.CurrentHoldInteraction));
        }
    }
}