using System;
using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Flag;

namespace Minesweeper.Runtime.Model.Interactions
{
    public class FlagInteraction : IInteraction
    {
        private readonly IFlags _flags;

        public FlagInteraction(IFlags flags)
        {
            _flags = flags ?? throw new ArgumentException("Flags can't be null");
        }

        public void Interact(ICell cell)
        {
            if (cell.IsFlagged && _flags.CanPut)
            {
                cell.RemoveFlag();
                _flags.PutFlag();
            }
            
            if (!cell.IsFlagged && _flags.CanTake)
            {
                cell.SetFlag();
                _flags.TakeFlag();
            }
        }
    }
}