using System.Collections.Generic;
using Minesweeper.Runtime.View.Cells;
using Minesweeper.Runtime.View.Field;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.Root
{
    public class NullCellsFieldRoot : SerializedMonoBehaviour, ICompositeRoot
    {
        [SerializeField] private CellsFieldRoot _fieldRoot;
        [SerializeField] private CellsFieldView _cellsFieldView;
        [SerializeField] private InteractionsSelectorRoot interactionsSelectorRoot;

        public void Compose()
        {
            var cellsField = _fieldRoot.Compose(new List<Vector2Int>());
            _cellsFieldView.Init(new CellViewInitializer(interactionsSelectorRoot.Compose(cellsField)));
            _cellsFieldView.Display(cellsField);
        }
    }
}