using System;
using Minesweeper.Runtime.Model.Interactions;
using Minesweeper.Runtime.View.Interactions;

namespace Minesweeper.Runtime.Model.Buttons.ClickActions
{
    public class InteractionSelectButtonAction : IButtonClickAction
    {
        private readonly IInteractionSelectorView _interactionSelectorView;
        private readonly IInteractionSelector _interactionSelector;
        private readonly IInteraction _interaction;

        public InteractionSelectButtonAction(IInteractionSelectorView interactionSelectorView, 
            IInteractionSelector interactionSelector, IInteraction interaction)
        {
            _interactionSelectorView = interactionSelectorView ?? throw new ArgumentException("InteractionSelectorView can't be null");
            _interactionSelector = interactionSelector ?? throw new ArgumentException("InteractionSelector can't be null");
            _interaction = interaction ?? throw new ArgumentException("Interaction can't be null");
        }

        public void Invoke()
        {
            _interactionSelector.Select(_interaction);
            _interactionSelectorView.Display(_interactionSelector);
        }
    }
}