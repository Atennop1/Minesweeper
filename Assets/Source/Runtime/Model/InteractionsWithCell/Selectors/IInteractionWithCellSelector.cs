namespace Minesweeper.Runtime.Model.InteractionsWithCell
{
    public interface IInteractionWithCellSelector
    {
        IInteractionWithCell CurrentInteraction { get; }
        void Select(IInteractionWithCell interaction);
    }
}