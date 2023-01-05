using Minesweeper.Runtime.Model.Cells;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.View.Flag
{
    public class FlagView : SerializedMonoBehaviour, IFlagView
    {
        [SerializeField] private IFlagAnimations _flagAnimations;
        private bool _isFlagWasActiveLastTime;
        
        public void Display(ICell cell)
        {
            if (_isFlagWasActiveLastTime && cell.IsFlagged || !_isFlagWasActiveLastTime && !cell.IsFlagged)
                return;
            
            _isFlagWasActiveLastTime = cell.IsFlagged;
            if (cell.IsFlagged) _flagAnimations.PlaySetFlagAnimation();
            else _flagAnimations.PlayRemoveFlagAnimation();
        }
    }
}