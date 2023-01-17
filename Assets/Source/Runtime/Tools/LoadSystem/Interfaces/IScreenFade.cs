using System;

namespace Minesweeper.Runtime.Tools.LoadSystem
{
    public interface IScreenFade
    {
        event Action OnDarkened;
        void FadeIn();
        void FadeOut();
    }
}