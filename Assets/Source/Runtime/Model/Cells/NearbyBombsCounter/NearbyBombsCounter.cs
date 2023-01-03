using System;
using Minesweeper.Runtime.Model.Field;

namespace Minesweeper.Runtime.Model.Cells.NearbyBombsCounter
{
    public class NearbyBombsCounter : INearbyBombsCounter
    {
        private readonly ICell[,] _cells;
        private readonly CellsFieldData _fieldData;

        public NearbyBombsCounter(ICell[,] cells, CellsFieldData fieldData)
        {
            _cells = cells ?? throw new ArgumentException("Cells can't be null");
            _fieldData = fieldData;
        }
        
        public int Calculate(CellData cellData)
        {
            var countOfBombs = 0;
            
            for (var y = -1; y < 2; y++)
            {
                for (var x = -1; x < 2; x++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    if (_fieldData.IsCellExist(_cells[y, x].Data))
                        countOfBombs += _cells[y, x].Data.IsMined ? 1 : 0;
                }
            }

            return countOfBombs;
        }
    }
}