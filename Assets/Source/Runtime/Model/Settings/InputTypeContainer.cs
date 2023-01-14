using Minesweeper.Runtime.Tools.SaveSystem;

namespace Minesweeper.Runtime.Model.Settings
{
    public class InputTypeContainer
    {
        private readonly BinaryStorage _binaryStorage = new();
        
        public void SetInputType(int index)
        {
            var type = (InputType)index;
            _binaryStorage.Save(type, "InputType");
        }

        public int GetInputTypeIndex()
        {
            if (!_binaryStorage.Exists("InputType"))
                return 0;

            return (int)_binaryStorage.Load<InputType>("InputType");
        }
    }
}