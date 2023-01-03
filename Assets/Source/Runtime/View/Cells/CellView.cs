using Minesweeper.Runtime.Model.Cells;
using Minesweeper.Runtime.View.Flag;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Minesweeper.Runtime.View.Cells
{
    public class CellView : MonoBehaviour, ICellView
    {
        [SerializeField] private IFlagView _flagView;
        [SerializeField] private Button _usingButton;
        [SerializeField] private TextMeshProUGUI _bombsText;
        [SerializeField] private Animator _animator;
        
        private readonly int OPEN_ANIMATOR_NAME = Animator.StringToHash("Open");
        private readonly int EXPLOSION_ANIMATOR_NAME = Animator.StringToHash("Explosion");
        
        public void AddButtonOnClickListener(UnityAction unityEvent) => _usingButton.onClick.AddListener(unityEvent);

        public void Display(ICell cell)
        {
            _flagView.Display(cell);
            _bombsText.text = cell.Data.CountOfBombsNearby.ToString();

            if (cell.IsOpened)
                _usingButton.enabled = false;
            
            switch (cell.IsOpened)
            {
                case true when cell.Data.IsMined:
                    _animator.Play(EXPLOSION_ANIMATOR_NAME);
                    return;
                
                case true:
                    _animator.Play(OPEN_ANIMATOR_NAME);
                    break;
            }
        }
    }
}