using System;

namespace Minesweeper.Runtime.Model.Interactions
{
    public class InteractionSelector : IInteractionSelector
    {
        public IInteraction CurrentInteraction { get; private set; }
        public IInteraction CurrentHoldInteraction { get; private set; }
        
        public void SelectInteraction(IInteraction interaction)
        {
            CurrentInteraction = interaction 
                                 ?? throw new ArgumentException("Interaction can't be null");
            
        }

        public void SelectHoldInteraction(IInteraction interaction)
        {
            CurrentHoldInteraction = interaction 
                                     ?? throw new ArgumentException("Interaction can't be null");
        }
    }
}