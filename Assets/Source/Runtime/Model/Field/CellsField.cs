using System;
using Minesweeper.Runtime.Model.Cells;

namespace Minesweeper.Runtime.Model.Field
{
    public class CellsField : ICellsField
    {
        public CellsFieldData FieldData { get; }
        public ICell[,] Cells { get; }

        public CellsField(ICell[,] cells, CellsFieldData fieldData)
        {
            FieldData = fieldData;
            Cells = cells ?? throw new ArgumentException("Cells can't be null");
        }

        public void OpenCell(ICell cell)
        {
            if (cell.IsOpened)
                return;
            
            cell.Open();
            
            if (cell.Data.CountOfBombsNearby != 0 || cell.Data.IsMined)
                return;

            for (var y = -1; y < 2; y++)
            {
                for (var x = -1; x < 2; x++)
                {
                    if (x == 0 && y == 0)
                        continue;
                    
                    if (FieldData.IsCellExist(cell.Data.PositionX + x, cell.Data.PositionY + y))
                        OpenCell(Cells[cell.Data.PositionY + y, cell.Data.PositionX + x]);
                }
            }
        }
    }
}