using System;

namespace Minesweeper.Runtime.Model.InteractionsWithCell
{
    public class InteractionWithCellSelector : IInteractionWithCellSelector
    {
        public IInteractionWithCell CurrentInteraction { get; private set; }
        
        public void Select(IInteractionWithCell interaction)
        {
            CurrentInteraction = interaction ?? throw new ArgumentException("Interaction can't be null");
        }
    }
}