using System.Collections.Generic;
using Minesweeper.Runtime.Factories;
using Minesweeper.Runtime.Model.Interactions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.Root
{
    public class NullCellsFieldRoot : SerializedMonoBehaviour, ICompositeRoot
    {
        [SerializeField] private CellsFieldRoot _fieldRoot;
        [SerializeField] private InteractionsSelectorRoot interactionsSelectorRoot;
        
        [Space]
        [SerializeField] private MainCellsFieldRoot _mainCellsFieldRoot;
        [SerializeField] private ICellViewFactory _cellViewFactory;

        public void Compose()
        {
            var cellsField = _fieldRoot.Compose(new List<Vector2Int>());
            var interactionsSelector = interactionsSelectorRoot.Compose(cellsField);
            interactionsSelector.Select(new StartGameInteraction(_mainCellsFieldRoot));
            _cellViewFactory.BindInteractionSelector(interactionsSelector);
        }
    }
}