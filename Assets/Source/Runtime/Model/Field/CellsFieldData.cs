using System;
using Minesweeper.Runtime.Tools.Extensions;

namespace Minesweeper.Runtime.Model.Field
{
    [Serializable]
    public readonly struct CellsFieldData
    {
        public readonly int SizeX;
        public readonly int SizeY;
        public readonly int TotalBombsCount;

        public CellsFieldData(int sizeX, int sizeY, int totalBombsCount)
        {
            SizeX = sizeX.TryThrowIfLessOrEqualsZero();
            SizeY = sizeY.TryThrowIfLessOrEqualsZero();
            TotalBombsCount = totalBombsCount.TryThrowIfLessOrEqualsZero();
        }

        public bool IsCellExist(int positionX, int positionY)
        {
            return positionX >= 0 && positionX < SizeX &&
                   positionY >= 0 && positionY < SizeY;
        }
    }
}