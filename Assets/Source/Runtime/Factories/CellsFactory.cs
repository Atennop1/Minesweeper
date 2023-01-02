using System;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Cells.NearbyBombsCounter;
using Minesweeper.Runtime.Model.Field;
using Minesweeper.Runtime.Model.GameState;
using UnityEngine;

namespace Minesweeper.Runtime.Factories
{
    public class CellsFactory : MonoBehaviour, ICellsFactory
    {
        [SerializeField] private IGameOverHandler _gameOverHandler;
        
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
                        cells[positionY, positionX] = new Cell(_gameOverHandler, minedCellsData.Find(data => data.PositionX == positionX && data.PositionY == positionY));

                    var tempCellData = new CellData(positionX, positionY, 0, false);
                    var bombsCount = nearbyBombsCounter.Calculate(tempCellData);

                    var cell = new Cell(_gameOverHandler, new CellData(positionX, positionY, bombsCount, false));
                    cells[positionY, positionX] = cell;
                }
            }

            return cells;
        }
    }
}