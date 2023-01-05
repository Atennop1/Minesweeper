using System;

namespace Minesweeper.Runtime.Extensions
{
    public static class IntExtensions
    {
        public static int TryThrowIfLessThanZero(this int number)
        {
            if (number < 0)
                throw new ArgumentException("Number can't be less than zero");

            return number;
        }
        
        public static int TryThrowIfLessOrEqualsZero(this int number)
        {
            if (number < 0)
                throw new ArgumentException("Number can't be less than zero");
            
            if (number == 0)
                throw new ArgumentException("Number can't be zero");

            return number;
        }
    }
}