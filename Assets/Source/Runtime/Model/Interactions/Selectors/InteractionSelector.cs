using System;

namespace Minesweeper.Runtime.Model.Interactions
{
    public class InteractionSelector : IInteractionSelector
    {
        public IInteraction CurrentInteraction { get; private set; }
        
        public void Select(IInteraction interaction)
        {
            CurrentInteraction = interaction ?? throw new ArgumentException("Interaction can't be null");
        }
    }
}