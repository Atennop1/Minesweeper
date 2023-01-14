using System;
using System.Collections.Generic;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Interactions;
using Minesweeper.Runtime.View.Cells;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.Factories
{
    public class CellViewFactory : SerializedMonoBehaviour, ICellViewFactory
    {
        [SerializeField] private Transform _content;
        [SerializeField] private GameObject _cellsLinePrefab;
        [SerializeField] private GameObject _cellPrefab;
        
        private readonly List<List<ICellView>> _spawnedView = new();

        public void BindInteractionSelector(IInteractionSelector interactionSelector)
        {
            if (interactionSelector == null) 
                throw new ArgumentException("InteractionSelector can't be null");
            
            _spawnedView.ForEach(cellsLine => cellsLine.ForEach(cellView =>
            {
                cellView.InitSelector(interactionSelector);
                cellView.Display();
            }));
        }
        
        public ICellView Create(CellData cellData)
        {
            if (_spawnedView.Count > cellData.PositionY && _spawnedView[cellData.PositionY].Count > cellData.PositionX)
                return _spawnedView[cellData.PositionY][cellData.PositionX];
            
            while (_spawnedView.Count < cellData.PositionY + 1)
            {
                _spawnedView.Add(new List<ICellView>());
                Instantiate(_cellsLinePrefab, _content);
            }

            var createdCell = Instantiate(_cellPrefab, _content.GetChild(cellData.PositionY));
            var cellView = createdCell.GetComponent<ICellView>();
            
            _spawnedView[cellData.PositionY].Add(cellView);
            return cellView;
        }
    }
}