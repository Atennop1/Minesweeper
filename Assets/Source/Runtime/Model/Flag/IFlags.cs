namespace Minesweeper.Runtime.Model.Flag
{
    public interface IFlags
    {
        bool CanTake { get; }
        bool CanPut { get; }
        
        void PutFlag();
        void TakeFlag();
    }
}