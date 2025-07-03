using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using Assets.Code.ZOthers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class PauseMenuView : MonoBehaviour
    {

        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _backToMenuButton;
        [SerializeField] private Button _backgroundResumeButton;
        [SerializeField] private SettingsView _settingsView;

        private InGameMenuMediator _mediator;

        private void Awake()
        {
            _resumeButton.onClick.AddListener(OnResumeButton);
            _settingsButton.onClick.AddListener(OnSettingsButtonPressed);
            _backgroundResumeButton.onClick.AddListener(OnResumeButton);
            _backToMenuButton.onClick.AddListener(OnBackToMenuPressed);
        }


        private void Start()
        {
            _settingsView.Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }


        private void OnBackToMenuPressed()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Button");
            _mediator.OnBackToMenuPressed();
        }


        private void OnResumeButton()
        {
            _mediator.OnResumeButton();
        }

        private void OnSettingsButtonPressed()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Bloop");
            _settingsView.Show();
        }

        internal void Configure(InGameMenuMediator mediator)
        {
            _mediator = mediator;
        }
    }
}