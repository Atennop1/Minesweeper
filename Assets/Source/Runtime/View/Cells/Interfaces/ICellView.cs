﻿using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.Model.Interactions;

namespace Minesweeper.Runtime.View.Cells
{
    public interface ICellView
    {
        void InitSelector(IInteractionSelector interactionSelector);
        void Display(ICell cell);
    }
}