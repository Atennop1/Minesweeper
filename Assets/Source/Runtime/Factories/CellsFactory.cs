using System;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Cells.NearbyBombsCounter;
using Minesweeper.Runtime.Model.Field;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.Factories
{
    public class CellsFactory : SerializedMonoBehaviour, ICellsFactory
    {
        private IMinedCellsDataFactory _minedCellsDataFactory;
        
        public void Init(IMinedCellsDataFactory minedCellsDataFactory)
        {
            _minedCellsDataFactory = minedCellsDataFactory ?? throw new ArgumentException("MinedCellsFactory can't be null");
        }
        
        public ICell[,] Create(CellsFieldData cellsFieldData)
        {
            var minedCellsData = _minedCellsDataFactory.Create(cellsFieldData);
            var cells = new ICell[cellsFieldData.SizeY, cellsFieldData.SizeX];
            var nearbyBombsCounter = new NearbyBombsCounter(cells, cellsFieldData);

            for (var positionY = 0; positionY < cellsFieldData.SizeY; positionY++)
            {
                for (var positionX = 0; positionX < cellsFieldData.SizeX; positionX++)
                {
                    if (minedCellsData.Exists(data => data.PositionX == positionX && data.PositionY == positionY))
                        cells[positionY, positionX] = new Cell(minedCellsData.Find(data => data.PositionX == positionX && data.PositionY == positionY));
                    
                    var bombsCount = nearbyBombsCounter.Calculate(new Vector2Int(positionX, positionY));
                    var cell = new Cell(new CellData(positionX, positionY, bombsCount, false));
                    cells[positionY, positionX] = cell;
                }
            }

            return cells;
        }
    }
}