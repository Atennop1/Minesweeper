using Minesweeper.Runtime.Model.InteractionsWithCell;

namespace Minesweeper.Runtime.View.InteractionsWIthCell
{
    public interface IInteractionWithCellSelectorView
    {
        void Display(IInteractionWithCellSelector selector);
    }
}