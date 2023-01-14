using System;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Interactions;

namespace Minesweeper.Runtime.Model.Buttons.ButtonActions
{
    public class InteractButtonAction : IButtonAction
    {
        private readonly IInteraction _interaction;
        private readonly ICell _cell;

        public InteractButtonAction(ICell cell, IInteraction interaction)
        {
            _interaction = interaction ?? throw new ArgumentNullException(nameof(interaction));
            _cell = cell ?? throw new ArgumentNullException(nameof(cell));
        }

        public void Invoke()
            => _interaction.Interact(_cell);
    }
}