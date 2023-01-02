using System;
using Minesweeper.Runtime.Extensions.CellDataExtensions;
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
        
        public int Calculate(CellData data)
        {
            return GetBombsCountNearbyOfCellInMainDirections(data) +
                   GetBombsCountNearbyOfCellInSecondaryDirections(data);
        }

        private int GetBombsCountNearbyOfCellInMainDirections(CellData cellData)
        {
            var bombsCount = 0;

            if (cellData.IsExistCellAboveThis(_fieldData))
            {
                var cell = cellData.GetCellAboveThis(_cells);
                if (cell != null) bombsCount += cell.Data.IsMined ? 1 : 0;
            }

            if (cellData.IsExistCellUnderThis(_fieldData))
            {
                var cell = cellData.GetCellUnderThis(_cells);
                if (cell != null) bombsCount += cell.Data.IsMined ? 1 : 0;
            }

            if (cellData.IsExistCellToLeftThis(_fieldData))
            {
                var cell = cellData.GetCellToLeftOfThis(_cells);
                if (cell != null) bombsCount += cell.Data.IsMined ? 1 : 0;
            }

            if (cellData.IsExistCellToRightOfThis(_fieldData))
            {
                var cell = cellData.GetCellToRightOfThis(_cells);
                if (cell != null) bombsCount += cell.Data.IsMined ? 1 : 0;
            }

            return bombsCount;
        }
        
        private int GetBombsCountNearbyOfCellInSecondaryDirections(CellData cellData)
        {
            var bombsCount = 0;

            if (cellData.IsExistCellAboveThisOnTheLeft(_fieldData))
            {
                var cell = cellData.GetCellAboveThisOnTheLeft(_cells);
                if (cell != null) bombsCount += cell.Data.IsMined ? 1 : 0;
            }

            if (cellData.IsExistCellAboveThisOnTheRight(_fieldData))
            {
                var cell = cellData.GetCellAboveThisOnTheRight(_cells);
                if (cell != null) bombsCount += cell.Data.IsMined ? 1 : 0;
            }

            if (cellData.IsExistCellUnderThisOnTheRight(_fieldData))
            {
                var cell = cellData.GetCellUnderThisOnTheRight(_cells);
                if (cell != null) bombsCount += cell.Data.IsMined ? 1 : 0;
            }

            if (cellData.IsExistCelUnderThisOnTheLeft(_fieldData))
            {
                var cell = cellData.GetCellUnderThisOnTheLeft(_cells);
                if (cell != null) bombsCount += cell.Data.IsMined ? 1 : 0;
            }

            return bombsCount;
        }
    }
}