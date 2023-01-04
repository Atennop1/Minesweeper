using Minesweeper.Runtime.Model.Field;
using Minesweeper.Runtime.Model.Interactions;
using Minesweeper.Runtime.View.Interactions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.Root
{
    public class InteractionsSelectorRoot : SerializedMonoBehaviour
    {
        [SerializeField] private MainCellsFieldRoot _mainCellsFieldRoot;
        [SerializeField] private InteractionSelectorView _selectorView;
        
        public InteractionSelector Compose(ICellsField cellsField)
        {
            var selector = new InteractionSelector();
            _selectorView.Init(selector, new FlagInteraction(), new DigInteraction(cellsField));

            var startGameInteraction = new StartGameInteraction(_mainCellsFieldRoot);
            selector.Select(startGameInteraction);
            return selector;
        }
    }
}