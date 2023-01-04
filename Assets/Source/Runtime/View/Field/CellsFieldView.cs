using System;
using Minesweeper.Runtime.Model.Field;
using Minesweeper.Runtime.Model.Interactions;
using Minesweeper.Runtime.View.Cells;
using UnityEngine;

namespace Minesweeper.Runtime.View.Field
{
    public class CellsFieldView : MonoBehaviour, ICellsFieldView
    {
        [SerializeField] private Transform _content;
        [SerializeField] private GameObject _cellsLinePrefab;
        [SerializeField] private GameObject _cellPrefab;

        private CellViewInitializer _cellViewInitializer;

        private void Awake()
        {
            if (!_cellPrefab.TryGetComponent(out ICellView _))
                throw new ArgumentException("CellPrefab must have an ICellView component");
        }

        public void Init(CellViewInitializer cellViewInitializer)
        {
            _cellViewInitializer = cellViewInitializer ?? throw new ArgumentException("CellViewInitializer can't be null");
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
                    _cellViewInitializer.InitializeCellView(cell, createdCellView);
                    createdCellView.Display(cell);
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
