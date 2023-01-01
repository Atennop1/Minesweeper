namespace Minesweeper.Runtime.Model.Field
{
    public readonly struct CellsFieldData
    {
        public readonly int SizeX;
        public readonly int SizeY;
        public readonly int TotalBombsCount;

        public CellsFieldData(int sizeX, int sizeY, int totalBombsCount)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            TotalBombsCount = totalBombsCount;
        }
    }
}