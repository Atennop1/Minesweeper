using Minesweeper.Runtime.Model.Buttons.ClickActions;

namespace Minesweeper.Runtime.Model.Buttons
{
    public interface IButton
    {
        void AddListener(IButtonClickAction action);
    }
}