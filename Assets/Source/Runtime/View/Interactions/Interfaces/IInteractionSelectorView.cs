using Minesweeper.Runtime.Model.Interactions;

namespace Minesweeper.Runtime.View.Interactions
{
    public interface IInteractionSelectorView
    {
        void Display(IInteractionSelector selector);
    }
}