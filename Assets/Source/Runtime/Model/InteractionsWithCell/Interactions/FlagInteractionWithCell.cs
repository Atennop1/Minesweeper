using Minesweeper.Runtime.Model.Cells;

namespace Minesweeper.Runtime.Model.InteractionsWithCell
{
    public class FlagInteractionWithCell : IInteractionWithCell
    {
        public void Interact(ICell cell)
        {
            if (cell.IsFlagged)
            {
                cell.RemoveFlag();
            }
            else
            {
                cell.SetFlag();
            }
        }
    }
}