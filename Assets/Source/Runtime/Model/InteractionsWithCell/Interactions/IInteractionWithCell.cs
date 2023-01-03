using Minesweeper.Runtime.Model.Cells;

namespace Minesweeper.Runtime.Model.InteractionsWithCell
{
    public interface IInteractionWithCell
    {
        void Interact(ICell cell);
    }
}