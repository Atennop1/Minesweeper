using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Field;

namespace Minesweeper.Runtime.Extensions.CellDataExtensions
{
    public static class MainDirectionsExtensions
    {
        public static bool IsExistCellAboveThis(this CellData cellData, CellsFieldData fieldData)
        {
            return cellData.PositionY + 1 < fieldData.SizeY;
        }
       
        public static bool IsExistCellUnderThis(this CellData cellData, CellsFieldData fieldData)
        {
            return cellData.PositionY - 1 < fieldData.SizeY;
        }
        
        public static bool IsExistCellToRightOfThis(this CellData cellData, CellsFieldData fieldData)
        {
            return cellData.PositionX + 1 < fieldData.SizeX;
        }
        
        public static bool IsExistCellToLeftThis(this CellData cellData, CellsFieldData fieldData)
        {
            return cellData.PositionX - 1 < fieldData.SizeX;
        }

        public static ICell GetCellAboveThis(this CellData cellData, ICell[,] cells)
        {
            return cells[cellData.PositionY + 1, cellData.PositionX];
        }
        
        public static ICell GetCellUnderThis(this CellData cellData, ICell[,] cells)
        {
            return cells[cellData.PositionY - 1, cellData.PositionX];
        }
        
        public static ICell GetCellToRightOfThis(this CellData cellData, ICell[,] cells)
        {
            return cells[cellData.PositionY, cellData.PositionX + 1];
        }
        
        public static ICell GetCellToLeftOfThis(this CellData cellData, ICell[,] cells)
        {
            return cells[cellData.PositionY, cellData.PositionX - 1];
        }
    }
}