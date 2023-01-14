using Minesweeper.Runtime.Model.Buttons;
using Minesweeper.Runtime.Model.Buttons.ButtonActions;
using Minesweeper.Runtime.Model.Field;
using Minesweeper.Runtime.Model.Flag;
using Minesweeper.Runtime.Model.Interactions;
using Minesweeper.Runtime.View.Flag;
using Minesweeper.Runtime.View.Interactions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.Root
{
    public class InteractionsSelectorRoot : SerializedMonoBehaviour
    {
        [SerializeField] private MainCellsFieldRoot _mainCellsFieldRoot;
        [SerializeField] private InteractionSelectorView _selectorView;
        [SerializeField] private IFlagsView _flagsView;
        
        [Space]
        [SerializeField] private IButton _digInteractionButton;
        [SerializeField] private IButton _flagInteractionButton;
        
        public InteractionSelector Compose(ICellsField cellsField)
        {
            var selector = new InteractionSelector();
            var startGameInteraction = new StartGameInteraction(_mainCellsFieldRoot);

            var digInteraction = new DigInteraction(cellsField);
            var flagInteraction = new FlagInteraction(new Flags(_flagsView, cellsField.FieldData.TotalBombsCount));
            
            _digInteractionButton.AddListener(new SelectInteractionButtonAction(_selectorView, selector, digInteraction));
            _flagInteractionButton.AddListener(new SelectInteractionButtonAction(_selectorView, selector, flagInteraction));
            
            selector.SelectInteraction(startGameInteraction);
            selector.SelectHoldInteraction(flagInteraction);
            
            return selector;
        }
    }
}