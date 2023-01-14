namespace Minesweeper.Runtime.Model.Interactions
{
    public interface IInteractionSelector
    {
        IInteraction CurrentHoldInteraction { get; }
        IInteraction CurrentInteraction { get; }
        void SelectInteraction(IInteraction interaction);
    }
}