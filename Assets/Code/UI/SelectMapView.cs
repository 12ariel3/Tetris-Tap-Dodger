using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class SelectMapView : MonoBehaviour
    {

        [SerializeField] private Button _backgroundCloseButton;


        private void Awake()
        {
            _backgroundCloseButton.onClick.AddListener(Hide);
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

        public void HideFirst()
        {
            gameObject.SetActive(false);
        }
    }
}