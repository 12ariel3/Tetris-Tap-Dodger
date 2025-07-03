using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class StatsInfoView : MonoBehaviour
    {

        [SerializeField] private Button _closeButton;

        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButtonPressed);
        }

        private void OnCloseButtonPressed()
        {
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}