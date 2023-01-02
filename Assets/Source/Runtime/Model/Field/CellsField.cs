using System;
using Minesweeper.Runtime.Extensions.CellDataExtensions;
using Minesweeper.Runtime.Model.Cells;

namespace Minesweeper.Runtime.Model.Field
{
    public class CellsField : ICellsField
    {
        public CellsFieldData CellsFieldData { get; }
        public ICell[,] Cells { get; }

        public CellsField(ICell[,] cells, CellsFieldData cellsFieldData)
        {
            CellsFieldData = cellsFieldData;
            Cells = cells ?? throw new ArgumentException("Cells can't be null");
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
            if (cell.Data.IsExistCellAboveThis(CellsFieldData))
                OpenCell(cell.Data.GetCellAboveThis(Cells));
            
            if (cell.Data.IsExistCellUnderThis(CellsFieldData))
                OpenCell(cell.Data.GetCellUnderThis(Cells));
            
            if (cell.Data.IsExistCellToLeftThis(CellsFieldData))
                OpenCell(cell.Data.GetCellToLeftOfThis(Cells));
            
            if (cell.Data.IsExistCellToRightOfThis(CellsFieldData))
                OpenCell(cell.Data.GetCellToRightOfThis(Cells));
        }

        private void OpenCellsInTheSecondaryDirections(ICell cell)
        {
            if (cell.Data.IsExistCellAboveThisOnTheLeft(CellsFieldData))
                OpenCell(cell.Data.GetCellAboveThisOnTheLeft(Cells));
            
            if (cell.Data.IsExistCellAboveThisOnTheRight(CellsFieldData))
                OpenCell(cell.Data.GetCellAboveThisOnTheRight(Cells));
            
            if (cell.Data.IsExistCellUnderThisOnTheRight(CellsFieldData))
                OpenCell(cell.Data.GetCellUnderThisOnTheRight(Cells));
            
            if (cell.Data.IsExistCelUnderThisOnTheLeft(CellsFieldData))
                OpenCell(cell.Data.GetCellUnderThisOnTheLeft(Cells));
        }
    }
}