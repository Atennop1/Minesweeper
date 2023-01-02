namespace Minesweeper.Runtime.Model.Cells.NearbyBombsCounter
{
    public interface INearbyBombsCounter
    {
        int Calculate(CellData data);
    }
}