using System;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.View.Flag;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Minesweeper.Runtime.View.Cells
{
    public class CellView : SerializedMonoBehaviour, ICellView
    {
        [SerializeField] private IFlagView _flagView;
        [SerializeField] private Button _usingButton;
        [SerializeField] private TextMeshProUGUI _bombsText;
        [SerializeField] private Animator _animator;
        
        private readonly int OPEN_ANIMATOR_NAME = Animator.StringToHash("Open");
        private readonly int EXPLOSION_ANIMATOR_NAME = Animator.StringToHash("Explosion");
        
        private ICell _visualizingCell;
        private ICell _lastVersionOfCell;
        
        public void AddButtonOnClickListener(UnityAction unityEvent) => _usingButton.onClick.AddListener(unityEvent);

        public void Init(ICell cell)
        {
            _visualizingCell = cell ?? throw new ArgumentException("Cell can't be null");
            _lastVersionOfCell = new Cell(_visualizingCell.Data);
            Display();
        }
        
        private void Update()
        {
            if (_lastVersionOfCell.IsOpened != _visualizingCell.IsOpened)
            {
                _lastVersionOfCell.Open();
                Display();
            }

            if (!_lastVersionOfCell.IsFlagged && _visualizingCell.IsFlagged)
            {
                _lastVersionOfCell.SetFlag();
                Display();
            }
            
            if (_lastVersionOfCell.IsFlagged && !_visualizingCell.IsFlagged)
            {
                _lastVersionOfCell.SetFlag();
                Display();
            }
        }
        
        private void Display()
        {
            Debug.Log("display");
            _flagView.Display(_visualizingCell);
            _bombsText.text = _visualizingCell.Data.CountOfBombsNearby.ToString();

            if (_visualizingCell.IsOpened)
                _usingButton.enabled = false;
            
            switch (_visualizingCell.IsOpened)
            {
                case true when _visualizingCell.Data.IsMined:
                    _animator.Play(EXPLOSION_ANIMATOR_NAME);
                    return;
                
                case true:
                    _animator.Play(OPEN_ANIMATOR_NAME);
                    break;
            }
        }
    }
}