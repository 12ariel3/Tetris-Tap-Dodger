using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class LanguagesView : MonoBehaviour
    {
        [SerializeField] private Button _backgroundBackToSettingsButton;
        [SerializeField] private Button _usaButton;
        [SerializeField] private Image _usaSprite;
        [SerializeField] private Button _spainButton;
        [SerializeField] private Image _spainSprite;
        [SerializeField] private Button _argentinaButton;
        [SerializeField] private Image _argentinaSprite;
        [SerializeField] private SettingsView _settingsView;


        void Start()
        {
            _backgroundBackToSettingsButton.onClick.AddListener(OnBackToSettingsPressed);
            _usaButton.onClick.AddListener(OnUsaButtonPressed);
            _spainButton.onClick.AddListener(OnSpainButtonPressed);
            _argentinaButton.onClick.AddListener(OnArgentinaButtonPressed);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("ReverseBloop");
            gameObject.SetActive(false);
        }

        private void OnBackToSettingsPressed()
        {
            Hide();
        }

        private void OnUsaButtonPressed()
        {
            _settingsView.SetNewLanguage(0, _usaSprite.sprite);
            Hide();
        }
        private void OnArgentinaButtonPressed()
        {
            _settingsView.SetNewLanguage(1, _argentinaSprite.sprite);
            Hide();
        }

        private void OnSpainButtonPressed()
        {
            _settingsView.SetNewLanguage(2, _spainSprite.sprite);
            Hide();
        }
    }
}