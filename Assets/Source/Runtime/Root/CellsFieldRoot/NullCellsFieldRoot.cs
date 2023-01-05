using System.Collections.Generic;
using Minesweeper.Runtime.Factories;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.Root
{
    public class NullCellsFieldRoot : SerializedMonoBehaviour, ICompositeRoot
    {
        [SerializeField] private CellsFieldRoot _fieldRoot;
        [SerializeField] private ICellViewFactory _cellViewFactory;

        public void Compose() => _fieldRoot.Compose(new List<Vector2Int>());
    }
}