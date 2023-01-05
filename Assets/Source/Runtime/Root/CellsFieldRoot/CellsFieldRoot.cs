using System.Collections.Generic;
using Minesweeper.Runtime.Factories;
using Minesweeper.Runtime.Model.Field;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.Root
{
    public class CellsFieldRoot : SerializedMonoBehaviour
    {
        [SerializeField] private CellsFactory _cellsFactory;
        [SerializeField] private MinedCellsDataFactory _minedCellsDataFactory;
        
        [Space]
        [SerializeField] private ICellViewFactory _cellViewFactory;
        [SerializeField] private InteractionsSelectorRoot interactionsSelectorRoot;

        public ICellsField Compose(List<Vector2Int> forbiddenCellsPosition)
        {
            var fieldData = new CellsFieldData(16, 7, 20);
            
            _minedCellsDataFactory.Init(forbiddenCellsPosition);
            _cellsFactory.Init(_minedCellsDataFactory, _cellViewFactory);
            
            var cellsField = new CellsField(_cellsFactory.Create(fieldData), fieldData);
            _cellViewFactory.BindInteractionSelector(interactionsSelectorRoot.Compose(cellsField));
            return cellsField;
        }
    }
}