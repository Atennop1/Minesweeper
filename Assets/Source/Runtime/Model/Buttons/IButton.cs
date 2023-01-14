using Minesweeper.Runtime.Model.Buttons.ButtonActions;

namespace Minesweeper.Runtime.Model.Buttons
{
    public interface IButton
    {
        void AddListener(IButtonAction action);
        void AddHoldListener(IButtonAction action);
    }
}