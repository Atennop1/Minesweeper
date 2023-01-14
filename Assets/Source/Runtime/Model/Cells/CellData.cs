using Minesweeper.Runtime.Tools.Extensions;

namespace Minesweeper.Runtime.Model.Cells
{
    public readonly struct CellData
    {
        public readonly int PositionX;
        public readonly int PositionY;
        
        public readonly int CountOfBombsNearby;
        public readonly bool IsMined;

        public CellData(int positionX, int positionY, int countOfBombsNearby, bool isMined)
        {
            PositionX = positionX.TryThrowIfLessThanZero();
            PositionY = positionY.TryThrowIfLessThanZero();
            
            CountOfBombsNearby = countOfBombsNearby.TryThrowIfLessThanZero();
            IsMined = isMined;
        }
    }
}