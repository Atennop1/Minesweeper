using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Minesweeper.Runtime.Tools.LoadSystem
{
    public sealed class ScreenFade : MonoBehaviour, IScreenFade
    {
        [SerializeField] private Image _screen;
        [SerializeField] private float _fadeInSeconds = 1.5f;
        [SerializeField] private float _fadeOutSeconds = 2f;
        
        public event Action OnDarkened;

        private void Start() 
            => DontDestroyOnLoad(gameObject);

        public void FadeIn()
        {
            Fade(true);
            OnDarkened?.Invoke();
        }

        public void FadeOut()
            => Fade(false);

        private async void Fade(bool isIn)
        {
            var timer = 0f;
            var neededTime = isIn ? _fadeInSeconds : _fadeOutSeconds;
            
            while (timer < neededTime)
            {
                timer += Time.deltaTime;
                
                var neededColor = isIn ? Color.white : Color.clear;
                var originalColor = isIn ? Color.clear : Color.white;
                
                _screen.color = Color.Lerp(originalColor, neededColor, timer);
                await UniTask.Yield();
            }
        }
    }
}
