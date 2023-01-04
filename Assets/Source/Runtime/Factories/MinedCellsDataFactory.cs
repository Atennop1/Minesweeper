using System;
using System.Collections.Generic;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Field;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Minesweeper.Runtime.Factories
{
    public class MinedCellsDataFactory : MonoBehaviour, IMinedCellsDataFactory
    {
        private List<Vector2Int> _forbiddenCellsPosition;

        public void Init(List<Vector2Int> forbiddenCellsPosition)
        {
            _forbiddenCellsPosition =
                forbiddenCellsPosition ?? throw new ArgumentException("ForbiddenCellsPosition can't be null");
        }
        
        public List<CellData> Create(CellsFieldData cellsFieldData)
        {
            var minedCellsData = new List<CellData>();

            while (minedCellsData.Count < cellsFieldData.TotalBombsCount)
            {
                var generatedCellData = new CellData(Random.Range(0, cellsFieldData.SizeX),
                    Random.Range(0, cellsFieldData.SizeY), 0, true);

                if (minedCellsData.Exists(data =>
                        data.PositionX == generatedCellData.PositionX &&
                        data.PositionY == generatedCellData.PositionY) ||
                    _forbiddenCellsPosition.Exists(position =>
                        position.x == generatedCellData.PositionX &&
                        position.y == generatedCellData.PositionY)) continue;
                
                minedCellsData.Add(generatedCellData);
            }
            
            return minedCellsData;
        }
    }
}