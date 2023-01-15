using Minesweeper.Runtime.Model.Field;
using Minesweeper.Runtime.Tools.SaveSystem;

namespace Minesweeper.Runtime.Model.Settings
{
    public class CellsFieldDataContainer
    {
        private readonly BinaryStorage _binaryStorage = new();
        private readonly CellsFieldDataValidator _dataValidator = new();
        private readonly CellsFieldData _defaultCellsFieldData;

        public CellsFieldDataContainer(CellsFieldData defaultCellsFieldData)
        {
            _defaultCellsFieldData = defaultCellsFieldData;
        }

        public void SetFieldData(CellsFieldData fieldData)
        {
            _dataValidator.Validate(fieldData);
            _binaryStorage.Save(fieldData, "CellsFieldData");
        }

        public CellsFieldData GetFieldData()
        {
            if (!_binaryStorage.Exists("CellsFieldData"))
                return _defaultCellsFieldData;

            return _binaryStorage.Load<CellsFieldData>("CellsFieldData");
        }
    }
}