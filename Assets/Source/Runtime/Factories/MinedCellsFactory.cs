using System;
using System.Collections.Generic;
using System.Linq;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Field;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Minesweeper.Runtime.Factories
{
    public class MinedCellsFactory : MonoBehaviour
    {
        private List<ICell> _forbiddenCells;

        public void Init(List<ICell> forbiddenCells)
        {
            _forbiddenCells = forbiddenCells ?? throw new ArgumentException("ForbiddenCells can't be null");
        }
        
        public List<ICell> Create(CellsFieldData cellsFieldData)
        {
            var minedCells = new List<ICell>();

            while (minedCells.Count < cellsFieldData.TotalBombsCount)
            {
                var generatedCellData = new CellData(Random.Range(0, cellsFieldData.SizeX),
                    Random.Range(0, cellsFieldData.SizeY), 1, true);

                if (!minedCells.Exists(cell =>
                        cell.Data.PositionX == generatedCellData.PositionX &&
                        cell.Data.PositionY == generatedCellData.PositionY) &&
                    !_forbiddenCells.Exists(cell =>
                        cell.Data.PositionX == generatedCellData.PositionX &&
                        cell.Data.PositionY == generatedCellData.PositionY)) continue;
                
                minedCells.Add(new Cell(generatedCellData));
            }
            
            return minedCells;
        }
    }
}