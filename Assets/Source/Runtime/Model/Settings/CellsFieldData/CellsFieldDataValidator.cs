using Minesweeper.Runtime.Model.Field;
using Minesweeper.Runtime.Tools.Exceptions;

namespace Minesweeper.Runtime.Model.Settings
{
    public class CellsFieldDataValidator
    {
        private const int MINIMUM_FIELD_SIDE_SIZE = 6;
        private const int MAXIMUM_FIELD_SIDE_SIZE = 100;
        
        public void Validate(CellsFieldData fieldData)
        {
            if (fieldData.SizeX > MAXIMUM_FIELD_SIDE_SIZE || fieldData.SizeY > MAXIMUM_FIELD_SIDE_SIZE)
                throw new FieldIsTooBigException();

            if (fieldData.SizeX < MINIMUM_FIELD_SIDE_SIZE && fieldData.SizeY < MINIMUM_FIELD_SIDE_SIZE)
                throw new FieldIsToSmallException();
            
            var smallerSide = fieldData.SizeX < fieldData.SizeY ? fieldData.SizeX : fieldData.SizeY;
            smallerSide = smallerSide < MINIMUM_FIELD_SIDE_SIZE ? smallerSide : MINIMUM_FIELD_SIDE_SIZE - 1;

            var maxAreaOfNonBombedCells = smallerSide * (MINIMUM_FIELD_SIDE_SIZE - 1);
            var areaOfField = fieldData.SizeX * fieldData.SizeY;
            
            if (areaOfField - maxAreaOfNonBombedCells < fieldData.TotalBombsCount)
                throw new TooManyBombsException();
        }
    }
}