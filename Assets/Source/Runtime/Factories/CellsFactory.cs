using System;
using Minesweeper.Runtime.Extensions.CellDataExtensions;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Field;
using UnityEngine;

namespace Minesweeper.Runtime.Factories
{
    public class CellsFactory : MonoBehaviour, ICellsFactory
    {
        public ICell[,] Create(IMinedCellsFactory minedCellsFactory, CellsFieldData cellsFieldData)
        {
            if (minedCellsFactory == null)
                throw new ArgumentException("MinedCellsFactory can't be null");
            
            var minedCells = minedCellsFactory.Create(cellsFieldData);
            var cells = new ICell[cellsFieldData.SizeY, cellsFieldData.SizeX];

            for (var i = 0; i < cellsFieldData.SizeY; i++)
            {
                for (var j = 0; j < cellsFieldData.SizeX; j++)
                {
                    if (minedCells.Exists(cell => cell.Data.PositionX == j && cell.Data.PositionY == i))
                        cells[i, j] = minedCells.Find(cell => cell.Data.PositionX == j && cell.Data.PositionY == i);

                    var tempCellData = new CellData(j, i, 0, false);
                    var bombsCount = GetBombsCountNearbyOfCellInMainDirections(tempCellData, cells, cellsFieldData) +
                                        GetBombsCountNearbyOfCellInSecondaryDirections(tempCellData, cells, cellsFieldData);

                    var cell = new Cell(new CellData(j, i, bombsCount, false));
                    cells[i, j] = cell;
                }
            }

            return cells;
        }

        private int GetBombsCountNearbyOfCellInMainDirections(CellData cellData, ICell[,] cells, CellsFieldData cellsFieldData)
        {
            var bombsCount = 0;

            if (cellData.IsExistCellAboveThis(cellsFieldData))
            {
                var cell = cellData.GetCellAboveThis(cells);
                if (cell != null) bombsCount += cell.Data.IsMined ? 1 : 0;
            }

            if (cellData.IsExistCellUnderThis(cellsFieldData))
            {
                var cell = cellData.GetCellUnderThis(cells);
                if (cell != null) bombsCount += cell.Data.IsMined ? 1 : 0;
            }

            if (cellData.IsExistCellToLeftThis(cellsFieldData))
            {
                var cell = cellData.GetCellToLeftOfThis(cells);
                if (cell != null) bombsCount += cell.Data.IsMined ? 1 : 0;
            }

            if (cellData.IsExistCellToRightOfThis(cellsFieldData))
            {
                var cell = cellData.GetCellToRightOfThis(cells);
                if (cell != null) bombsCount += cell.Data.IsMined ? 1 : 0;
            }

            return bombsCount;
        }
        
        private int GetBombsCountNearbyOfCellInSecondaryDirections(CellData cellData, ICell[,] cells, CellsFieldData cellsFieldData)
        {
            var bombsCount = 0;

            if (cellData.IsExistCellAboveThisOnTheLeft(cellsFieldData))
            {
                var cell = cellData.GetCellAboveThisOnTheLeft(cells);
                if (cell != null) bombsCount += cell.Data.IsMined ? 1 : 0;
            }

            if (cellData.IsExistCellAboveThisOnTheRight(cellsFieldData))
            {
                var cell = cellData.GetCellAboveThisOnTheRight(cells);
                if (cell != null) bombsCount += cell.Data.IsMined ? 1 : 0;
            }

            if (cellData.IsExistCellUnderThisOnTheRight(cellsFieldData))
            {
                var cell = cellData.GetCellUnderThisOnTheRight(cells);
                if (cell != null) bombsCount += cell.Data.IsMined ? 1 : 0;
            }

            if (cellData.IsExistCelUnderThisOnTheLeft(cellsFieldData))
            {
                var cell = cellData.GetCellUnderThisOnTheLeft(cells);
                if (cell != null) bombsCount += cell.Data.IsMined ? 1 : 0;
            }

            return bombsCount;
        }
    }
}