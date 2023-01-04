using System.Collections.Generic;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Interactions;
using Minesweeper.Runtime.View.Cells;
using Minesweeper.Runtime.View.Field;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.Root
{
    public class MainCellsFieldRoot : SerializedMonoBehaviour
    {
        [SerializeField] private CellsFieldRoot _fieldRoot;
        [SerializeField] private GameStateRoot _gameStateRoot;
        [SerializeField] private CellsFieldView _cellsFieldView;
        [SerializeField] private InteractionsSelectorRoot interactionsSelectorRoot;

        public void Compose(CellData tapedCellData)
        {
            var forbiddenCellsData = BuildForbiddenCellsDataList(tapedCellData);
            var cellsField = _fieldRoot.Compose(forbiddenCellsData);
            
            _gameStateRoot.Compose(cellsField.Cells);
            var interactionsSelector = interactionsSelectorRoot.Compose(cellsField);
            interactionsSelector.Select(new StartGameInteraction(this));
            
            _cellsFieldView.Init(new CellViewInitializer(interactionsSelector));
            _cellsFieldView.Display(cellsField);
        }

        private List<Vector2Int> BuildForbiddenCellsDataList(CellData tapedCellData)
        {
            var forbiddenCellsData = new List<Vector2Int>();

            for (var y = -2; y < 3; y++)
            {
                for (var x = -2; x < 3; x++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    forbiddenCellsData.Add(new Vector2Int(tapedCellData.PositionX + x, tapedCellData.PositionY + y));
                }
            }

            return forbiddenCellsData;
        }
    }
}