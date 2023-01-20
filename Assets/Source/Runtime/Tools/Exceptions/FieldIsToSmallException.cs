using System;

namespace Minesweeper.Runtime.Tools.Exceptions
{
    public class FieldIsToSmallException : Exception
    {
        public FieldIsToSmallException()
            : base("Field is too small.") { }
    }
}