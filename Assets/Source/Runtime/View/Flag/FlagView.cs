using Minesweeper.Runtime.Model.Cells;
using UnityEngine;

namespace Minesweeper.Runtime.View.Flag
{
    public class FlagView : MonoBehaviour, IFlagView
    {
        [SerializeField] private Animator _flagAnimator;
        private bool _isFlagWasActiveLastTime;
        
        public void Display(ICell cell)
        {
            if (_isFlagWasActiveLastTime && cell.IsFlagged || !_isFlagWasActiveLastTime && !cell.IsFlagged)
                return;

            _isFlagWasActiveLastTime = cell.IsFlagged;
            _flagAnimator.Play(cell.IsFlagged ? "SetFlag" : "RemoveFlag");
        }
    }
}