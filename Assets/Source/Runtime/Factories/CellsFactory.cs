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
        private ICellViewFactory _cellViewFactory;
        
        public void Init(IMinedCellsDataFactory minedCellsDataFactory, ICellViewFactory cellViewFactory)
        {
            _minedCellsDataFactory = minedCellsDataFactory ?? throw new ArgumentException("MinedCellsFactory can't be null");
            _cellViewFactory = cellViewFactory ?? throw new ArgumentException("CellViewFactory can't be null");
        }
        
        public ICell[,] Create(CellsFieldData cellsFieldData)
        {
            var minedCellsData = _minedCellsDataFactory.Create(cellsFieldData);
            var cells = new ICell[cellsFieldData.SizeY, cellsFieldData.SizeX];
            var nearbyBombsCounter = new NearbyBombsCounter(cells, cellsFieldData);

            foreach (var minedCellData in minedCellsData)
                cells[minedCellData.PositionY, minedCellData.PositionX] = new MinedCell(minedCellData);

            for (var positionY = 0; positionY < cellsFieldData.SizeY; positionY++)
            {
                for (var positionX = 0; positionX < cellsFieldData.SizeX; positionX++)
                {
                    if (cells[positionY, positionX] != null)
                    {
                        cells[positionY, positionX] = new Cell(_cellViewFactory.Create(cells[positionY, positionX].Data), 
                            cells[positionY, positionX].Data);
                        
                        continue;
                    }

                    var bombsCount = nearbyBombsCounter.Calculate(new Vector2Int(positionX, positionY));
                    var cellData = new CellData(positionX, positionY, bombsCount, false);
                    
                    var cell = new Cell(_cellViewFactory.Create(cellData), cellData);
                    cells[positionY, positionX] = cell;
                }
            }

            return cells;
        }
    }
}