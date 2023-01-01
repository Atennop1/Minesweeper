using System;
using Minesweeper.Runtime.Extensions.CellDataExtensions;
using Minesweeper.Runtime.Factories;
using Minesweeper.Runtime.Model.Cells;

namespace Minesweeper.Runtime.Model.Field
{
    public class CellsField : ICellsField
    {
        private readonly CellsFieldData _cellsFieldData;
        private readonly ICell[,] _cells;

        public CellsField(ICellsFactory cellsFactory, IMinedCellsFactory minedCellsFactory , CellsFieldData cellsFieldData)
        {
            if (cellsFactory == null)
                throw new ArgumentException("CellsFactory can't be null");

            if (minedCellsFactory == null)
                throw new ArgumentException("MinedCellsFactory can't be null");
            
            _cellsFieldData = cellsFieldData;
            _cells = cellsFactory.Create(minedCellsFactory, cellsFieldData);
        }

        public void OpenCell(ICell cell)
        {
            cell.Open();
            
            if (cell.Data.CountOfBombsNearby != 0 && cell.Data.IsMined)
                return;

            OpenCellsInTheMainDirections(cell);
            OpenCellsInTheSecondaryDirections(cell);
        }
        
        private void OpenCellsInTheMainDirections(ICell cell)
        {
            if (cell.Data.IsExistCellAboveThis(_cellsFieldData))
                OpenCell(cell.Data.GetCellAboveThis(_cells));
            
            if (cell.Data.IsExistCellUnderThis(_cellsFieldData))
                OpenCell(cell.Data.GetCellUnderThis(_cells));
            
            if (cell.Data.IsExistCellToLeftThis(_cellsFieldData))
                OpenCell(cell.Data.GetCellToLeftOfThis(_cells));
            
            if (cell.Data.IsExistCellToRightOfThis(_cellsFieldData))
                OpenCell(cell.Data.GetCellToRightOfThis(_cells));
        }

        private void OpenCellsInTheSecondaryDirections(ICell cell)
        {
            if (cell.Data.IsExistCellAboveThisOnTheLeft(_cellsFieldData))
                OpenCell(cell.Data.GetCellAboveThisOnTheLeft(_cells));
            
            if (cell.Data.IsExistCellAboveThisOnTheRight(_cellsFieldData))
                OpenCell(cell.Data.GetCellAboveThisOnTheRight(_cells));
            
            if (cell.Data.IsExistCellUnderThisOnTheRight(_cellsFieldData))
                OpenCell(cell.Data.GetCellUnderThisOnTheRight(_cells));
            
            if (cell.Data.IsExistCelUnderThisOnTheLeft(_cellsFieldData))
                OpenCell(cell.Data.GetCellUnderThisOnTheLeft(_cells));
        }
    }
}