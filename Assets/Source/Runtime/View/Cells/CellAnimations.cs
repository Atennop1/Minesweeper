using UnityEngine;

namespace Minesweeper.Runtime.View.Cells
{
    public class CellAnimations : MonoBehaviour, ICellAnimations
    {
        [SerializeField] private Animator _animator;
        
        private readonly int OPEN_ANIMATOR_NAME = Animator.StringToHash("Open");
        private readonly int EXPLOSION_ANIMATOR_NAME = Animator.StringToHash("Explosion");

        public void PlayExplosionAnimation() => _animator.Play(EXPLOSION_ANIMATOR_NAME);
        public void PlayOpenAnimation() => _animator.Play(OPEN_ANIMATOR_NAME);
    }
}