using UnityEngine.Device;

namespace Minesweeper.Runtime.Model.Buttons.ButtonActions
{
    public class QuitGameButtonAction : IButtonAction
    {
        public void Invoke()
            => Application.Quit();
    }
}