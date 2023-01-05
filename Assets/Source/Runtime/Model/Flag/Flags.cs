using System;
using Minesweeper.Runtime.Extensions;
using Minesweeper.Runtime.View.Flag;

namespace Minesweeper.Runtime.Model.Flag
{
    public class Flags : IFlags
    {
        public bool CanTake => _count > 0;
        public bool CanPut => _count < _maxCount;
        
        private readonly int _maxCount;
        private readonly IFlagsView _flagsView;
        private int _count;

        public Flags(IFlagsView flagsView, int maxCount)
        {
            _flagsView = flagsView ?? throw new ArgumentException("FlagsView can't be null");
            _maxCount = maxCount.TryThrowIfLessOrEqualsZero();
            
            _count = maxCount;
            _flagsView.Display(_count);
        }

        public void PutFlag()
        {
            if (!CanPut)
                throw new InvalidOperationException("Flags have a maximum value");
            
            _count++;
            _flagsView.Display(_count);
        }

        public void TakeFlag()
        {
            if (!CanTake)
                throw new InvalidOperationException("Can't take flag from nothing");
            
            _count--;
            _flagsView.Display(_count);
        }
    }
}