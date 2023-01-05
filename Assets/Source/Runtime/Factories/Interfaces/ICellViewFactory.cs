using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Interactions;
using Minesweeper.Runtime.View.Cells;

namespace Minesweeper.Runtime.Factories
{
    public interface ICellViewFactory
    {
        void BindInteractionSelector(IInteractionSelector interactionSelector);
        ICellView Create(CellData cellData);
    }
}