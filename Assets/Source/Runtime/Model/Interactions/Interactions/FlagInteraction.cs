using Minesweeper.Runtime.Model.Cells;

namespace Minesweeper.Runtime.Model.Interactions
{
    public class FlagInteraction : IInteraction
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