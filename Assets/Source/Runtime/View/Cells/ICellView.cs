using Minesweeper.Runtime.Model.Cells;
using UnityEngine.Events;

namespace Minesweeper.Runtime.View.Cells
{
    public interface ICellView
    {
        void AddButtonOnClickListener(UnityAction unityEvent);
        void Init(ICell cell);
    }
}