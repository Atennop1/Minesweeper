using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Interactions;

namespace Minesweeper.Runtime.View.Cells
{
    public interface ICellView
    {
        void InitCell(ICell cell);
        void InitSelector(IInteractionSelector interactionSelector);
        
        void Display();
    }
}