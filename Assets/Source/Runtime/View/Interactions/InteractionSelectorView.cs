using Minesweeper.Runtime.Model.Interactions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Minesweeper.Runtime.View.Interactions
{
    public class InteractionSelectorView : SerializedMonoBehaviour, IInteractionSelectorView
    {
        [SerializeField] private IInteractionView _digInteractionView;
        [SerializeField] private IInteractionView _flagInteractionView;

        public void Awake() 
            => _digInteractionView.DisplaySelected();

        public void Display(IInteractionSelector selector)
        {
            if (selector.CurrentInteraction.GetType() == typeof(FlagInteraction))
            {
                _digInteractionView.DisplayUnselected();
                _flagInteractionView.DisplaySelected();
            }
            
            if (selector.CurrentInteraction.GetType() == typeof(DigInteraction))
            {
                _digInteractionView.DisplaySelected();
                _flagInteractionView.DisplayUnselected();
            }
        }
    }
}