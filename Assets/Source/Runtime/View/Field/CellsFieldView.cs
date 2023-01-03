using System;
using Minesweeper.Runtime.Model.Field;
using Minesweeper.Runtime.Model.InteractionsWithCell;
using Minesweeper.Runtime.View.Cells;
using UnityEngine;

namespace Minesweeper.Runtime.View.Field
{
    public class CellsFieldView : MonoBehaviour, ICellsFieldView
    {
        [SerializeField] private Transform _content;
        [SerializeField] private GameObject _cellsLinePrefab;
        [SerializeField] private GameObject _cellPrefab;

        private IInteractionWithCellSelector _interactionWithCellSelector;

        private void Awake()
        {
            if (!_cellPrefab.TryGetComponent(out ICellView _))
                throw new ArgumentException("CellPrefab must have an ICellView component");
        }

        public void Init(IInteractionWithCellSelector selector)
        {
            _interactionWithCellSelector = selector ?? throw new ArgumentException("Selector can't be null");
        }
        
        public void Display(ICellsField field)
        {
            ClearContent();

            for (var positionY = 0; positionY < field.Cells.GetLength(0); positionY++)
            {
                var createdCellsLine = Instantiate(_cellsLinePrefab, _content);
                
                for (var positionX = 0; positionX < field.Cells.GetLength(1); positionX++)
                {
                    var createdCellViewObject = Instantiate(_cellPrefab, createdCellsLine.transform);
                    var createdCellView = createdCellViewObject.GetComponent<ICellView>();

                    var cell = field.Cells[positionY, positionX];
                    createdCellView.Display(cell);
                    
                    createdCellView.AddButtonOnClickListener(() =>
                    {
                        _interactionWithCellSelector.CurrentInteraction.Interact(cell);
                        createdCellView.Display(cell);
                    });
                }
            }
        }

        private void ClearContent()
        {
            for (var i = 0; i < _content.childCount; i++)
                Destroy(_content.GetChild(i).gameObject);
        }
    }
}
