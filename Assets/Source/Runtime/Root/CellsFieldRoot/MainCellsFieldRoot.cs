using System.Collections.Generic;
using Minesweeper.Runtime.Factories;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Interactions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.Root
{
    public class MainCellsFieldRoot : SerializedMonoBehaviour
    {
        [SerializeField] private CellsFieldRoot _fieldRoot;
        [SerializeField] private InteractionsSelectorRoot interactionsSelectorRoot;
        
        [Space]
        [SerializeField] private GameStateRoot _gameStateRoot;
        [SerializeField] private ICellViewFactory _cellViewFactory;

        public void Compose(CellData tapedCellData)
        {
            var forbiddenCellsData = BuildForbiddenCellsCoordinate(tapedCellData);
            var cellsField = _fieldRoot.Compose(forbiddenCellsData);
            
            _gameStateRoot.Compose(cellsField);
            var interactionsSelector = interactionsSelectorRoot.Compose(cellsField);
            interactionsSelector.Select(new DigInteraction(cellsField));
            
            _cellViewFactory.BindInteractionSelector(interactionsSelector);
            cellsField.OpenCell(cellsField.Cells[tapedCellData.PositionY, tapedCellData.PositionX]);
        }

        private List<Vector2Int> BuildForbiddenCellsCoordinate(CellData tapedCellData)
        {
            var forbiddenCellsData = new List<Vector2Int>();

            for (var y = -2; y < 3; y++)
                for (var x = -2; x < 3; x++)
                    forbiddenCellsData.Add(new Vector2Int(tapedCellData.PositionX + x, tapedCellData.PositionY + y));

            return forbiddenCellsData;
        }
    }
}