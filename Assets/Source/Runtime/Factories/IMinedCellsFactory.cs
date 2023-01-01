using System.Collections.Generic;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Field;

namespace Minesweeper.Runtime.Factories
{
    public interface IMinedCellsFactory
    {
        List<ICell> Create(CellsFieldData cellsFieldData);
    }
}