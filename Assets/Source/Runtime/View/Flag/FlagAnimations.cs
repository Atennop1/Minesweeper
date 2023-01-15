using UnityEngine;

namespace Minesweeper.Runtime.View.Flag
{
    public class FlagAnimations : MonoBehaviour, IFlagAnimations
    {
        [SerializeField] private Animator _animator;
        
        private readonly int SET_ANIMATOR_NAME = Animator.StringToHash("SetFlag");
        private readonly int REMOVE_ANIMATOR_NAME = Animator.StringToHash("RemoveFlag");

        public void PlaySetFlagAnimation() => _animator.Play(SET_ANIMATOR_NAME);

        public void PlayRemoveFlagAnimation() => _animator.Play(REMOVE_ANIMATOR_NAME);
    }
}