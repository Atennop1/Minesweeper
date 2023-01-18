using System;
using Cysharp.Threading.Tasks;
using Minesweeper.Runtime.Tools.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Minesweeper.Runtime.Tools.LoadSystem
{
    public sealed class ScreenFade : MonoBehaviour, IScreenFade
    {
        [SerializeField] private float _fadeInSeconds = 1.5f;
        [SerializeField] private float _fadeOutSeconds = 2f;
        
        [Space]
        [SerializeField] private Image _screen;
        [SerializeField] private GameObject _canvas;
        
        public event Action OnDarkened;

        private void Start() 
            => DontDestroyOnLoad(_canvas);

        public void FadeIn()
            => Fade(true);

        public void FadeOut()
            => Fade(false);

        private async void Fade(bool isFadeIn)
        {
            var timer = 0f;
            var neededTime = isFadeIn ? _fadeInSeconds : _fadeOutSeconds;
            _screen.raycastTarget = true;
            
            while (timer < neededTime)
            {
                timer += Time.deltaTime;

                var neededA = isFadeIn ? 1 : 0;
                var originalA = isFadeIn ? 0 : 1;
                
                _screen.color = new Color(_screen.color.r, _screen.color.g, _screen.color.b, Mathf.Lerp(originalA, neededA, timer));
                await UniTask.Yield();
            }
            
            _screen.raycastTarget = false;

            if (isFadeIn)
            {
                OnDarkened?.Invoke();
                _canvas.DestroyAllChildrenExcept(_screen.gameObject);
            }
            else
            {
                Destroy(_canvas);
            }
        }
    }
}
