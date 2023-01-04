using UnityEngine;

namespace Minesweeper.Runtime.Model.Cells.NearbyBombsCounter
{
    public interface INearbyBombsCounter
    {
        int Calculate(Vector2Int position);
    }
}