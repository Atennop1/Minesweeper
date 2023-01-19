using UnityEngine;
using UnityEngine.UI;

namespace Minesweeper.Runtime.View.Pause
{
    public class PauseView : MonoBehaviour
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _pauseButton;
        
        [Space]
        [SerializeField] private SystemButtonsSetup _systemButtonsSetup;
        [SerializeField] private GameObject _pausePanel;

        private void Awake()
        {
            _systemButtonsSetup.Setup();
            _continueButton.onClick.AddListener(() => _pausePanel.SetActive(false));
            _pauseButton.onClick.AddListener(() => _pausePanel.SetActive(true));
        }
    }
}