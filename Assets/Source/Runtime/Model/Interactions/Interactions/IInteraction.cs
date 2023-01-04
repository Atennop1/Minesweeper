using Minesweeper.Runtime.Model.Cells;

namespace Minesweeper.Runtime.Model.Interactions
{
    public interface IInteraction
    {
        void Interact(ICell cell);
    }
}