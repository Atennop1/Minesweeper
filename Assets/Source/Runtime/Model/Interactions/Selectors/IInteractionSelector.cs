namespace Minesweeper.Runtime.Model.Interactions
{
    public interface IInteractionSelector
    {
        IInteraction CurrentInteraction { get; }
        void Select(IInteraction interaction);
    }
}