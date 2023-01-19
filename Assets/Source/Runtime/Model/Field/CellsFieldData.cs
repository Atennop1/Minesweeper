using System;
using Minesweeper.Runtime.Tools.Exceptions;
using Minesweeper.Runtime.Tools.Extensions;

namespace Minesweeper.Runtime.Model.Field
{
    [Serializable]
    public readonly struct CellsFieldData
    {
        public readonly int SizeX;
        public readonly int SizeY;
        public readonly int TotalBombsCount;
        
        private const int MINIMUM_FIELD_SIDE_SIZE = 6;
        private const int MAXIMUM_FIELD_SIDE_SIZE = 100;

        public CellsFieldData(int sizeX, int sizeY, int totalBombsCount)
        {
            SizeX = sizeX.TryThrowIfLessOrEqualsZero();
            SizeY = sizeY.TryThrowIfLessOrEqualsZero();
            
            TotalBombsCount = totalBombsCount.TryThrowIfLessOrEqualsZero();
            ValidateField();
        }

        public bool IsCellExist(int positionX, int positionY)
        {
            return positionX >= 0 && positionX < SizeX &&
                   positionY >= 0 && positionY < SizeY;
        }

        private void ValidateField()
        {
            if (SizeX > MAXIMUM_FIELD_SIDE_SIZE || SizeY > MAXIMUM_FIELD_SIDE_SIZE)
                throw new FieldIsTooBigException();

            if (SizeX < MINIMUM_FIELD_SIDE_SIZE && SizeY < MINIMUM_FIELD_SIDE_SIZE)
                throw new FieldIsToSmallException();
            
            var smallerSide = SizeX < SizeY ? SizeX : SizeY;
            smallerSide = smallerSide < MINIMUM_FIELD_SIDE_SIZE ? smallerSide : MINIMUM_FIELD_SIDE_SIZE - 1;

            var maxAreaOfNonBombedCells = smallerSide * (MINIMUM_FIELD_SIDE_SIZE - 1);
            var areaOfField = SizeX * SizeY;
            
            if (areaOfField - maxAreaOfNonBombedCells < TotalBombsCount)
                throw new TooManyBombsException();
        }
    }
}