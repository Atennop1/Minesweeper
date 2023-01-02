﻿using System;
using System.Collections.Generic;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Field;
using Minesweeper.Runtime.Model.GameState;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Minesweeper.Runtime.Factories
{
    public class MinedCellsDataFactory : MonoBehaviour, IMinedCellsDataFactory
    {
        private List<CellData> _forbiddenCellsData;

        public void Init(List<CellData> forbiddenCells)
        {
            _forbiddenCellsData = forbiddenCells ?? throw new ArgumentException("ForbiddenCells can't be null");
        }
        
        public List<CellData> Create(CellsFieldData cellsFieldData)
        {
            var minedCellsData = new List<CellData>();

            while (minedCellsData.Count < cellsFieldData.TotalBombsCount)
            {
                var generatedCellData = new CellData(Random.Range(0, cellsFieldData.SizeX),
                    Random.Range(0, cellsFieldData.SizeY), 1, true);

                if (!minedCellsData.Exists(data =>
                        data.PositionX == generatedCellData.PositionX &&
                        data.PositionY == generatedCellData.PositionY) &&
                    !_forbiddenCellsData.Exists(data =>
                        data.PositionX == generatedCellData.PositionX &&
                        data.PositionY == generatedCellData.PositionY)) continue;
                
                minedCellsData.Add(generatedCellData);
            }
            
            return minedCellsData;
        }
    }
}