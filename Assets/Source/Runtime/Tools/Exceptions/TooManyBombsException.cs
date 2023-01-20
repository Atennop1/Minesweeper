using System;

namespace Minesweeper.Runtime.Tools.Exceptions
{
    public class TooManyBombsException : Exception
    {
        public TooManyBombsException()
            : base("Field is too small for this count of bombs") { }
    }
}