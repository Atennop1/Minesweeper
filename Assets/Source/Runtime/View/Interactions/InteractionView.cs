using UnityEngine;
using UnityEngine.UI;

namespace Minesweeper.Runtime.View.Interactions
{
    public class InteractionView : MonoBehaviour, IInteractionView
    {
        [SerializeField] private Image _selectedImage;
        
        public void DisplaySelected() => _selectedImage.enabled = true;
        
        public void DisplayUnselected() => _selectedImage.enabled = false;
    }
}