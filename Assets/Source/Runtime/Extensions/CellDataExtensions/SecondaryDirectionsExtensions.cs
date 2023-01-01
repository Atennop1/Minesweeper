using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Field;

namespace Minesweeper.Runtime.Extensions.CellDataExtensions
{
    public static class SecondaryDirectionsExtensions
    {
        public static bool IsExistCellAboveThisOnTheRight(this CellData cellData, CellsFieldData fieldData)
        {
            return cellData.PositionY + 1 < fieldData.SizeY && cellData.PositionX + 1 < fieldData.SizeX;
        }
        
        public static bool IsExistCellAboveThisOnTheLeft(this CellData cellData, CellsFieldData fieldData)
        {
            return cellData.PositionY + 1 < fieldData.SizeY && cellData.PositionX - 1 < fieldData.SizeX;
        }
        
        public static bool IsExistCellUnderThisOnTheRight(this CellData cellData, CellsFieldData fieldData)
        {
            return cellData.PositionY - 1 < fieldData.SizeY && cellData.PositionX + 1 < fieldData.SizeX;
        }
        
        public static bool IsExistCelUnderThisOnTheLeft(this CellData cellData, CellsFieldData fieldData)
        {
            return cellData.PositionY - 1 < fieldData.SizeY && cellData.PositionX - 1 < fieldData.SizeX;
        }
        
        public static ICell GetCellAboveThisOnTheRight(this CellData cellData, ICell[,] cells)
        {
            return cells[cellData.PositionY + 1, cellData.PositionX + 1];
        }
        
        public static ICell GetCellAboveThisOnTheLeft(this CellData cellData, ICell[,] cells)
        {
            return cells[cellData.PositionY + 1, cellData.PositionX - 1];
        }
        
        public static ICell GetCellUnderThisOnTheRight(this CellData cellData, ICell[,] cells)
        {
            return cells[cellData.PositionY - 1, cellData.PositionX + 1];
        }
        
        public static ICell GetCellUnderThisOnTheLeft(this CellData cellData, ICell[,] cells)
        {
            return cells[cellData.PositionY - 1, cellData.PositionX - 1];
        }
    }
}