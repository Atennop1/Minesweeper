using System;

namespace Minesweeper.Runtime.Tools.Exceptions
{
    public class FieldIsTooBigException : Exception
    {
        public FieldIsTooBigException()
            : base("Field is too big.") { }
    }
}