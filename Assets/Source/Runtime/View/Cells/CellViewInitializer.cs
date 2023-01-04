using System;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Interactions;

namespace Minesweeper.Runtime.View.Cells
{
    public class CellViewInitializer
    {
        private readonly IInteractionSelector _interactionSelector;

        public CellViewInitializer(IInteractionSelector interactionSelector)
        {
            _interactionSelector = interactionSelector ?? throw new ArgumentException("InteractionSelector can't be null");
        }

        public void InitializeCellView(ICell cell, ICellView cellView)
        {
            cellView.AddButtonOnClickListener(() =>
            {
                _interactionSelector.CurrentInteraction.Interact(cell);
                cellView.Display(cell);
            });
        }
    }
}