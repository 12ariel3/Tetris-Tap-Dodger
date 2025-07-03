using Assets.Code.Common.Events;
using Assets.Code.Common.GemsData;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class UpgradesInfoView : MonoBehaviour
    {

        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _upgradeButton;

        [SerializeField] private Image _nodeIcon;
        [SerializeField] private Image _nodeIconBackground;
        [SerializeField] private Image _nodeIconDeepBackground;

        [SerializeField] private TextMeshProUGUI _statsToAdd;
        [SerializeField] private TextMeshProUGUI _gemCost;
        private int _upgradeValue;
        private string _nodeName;

        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButtonPressed);
            _upgradeButton.onClick.AddListener(OnUpgradeButtonPressed);
        }


        private void OnUpgradeButtonPressed()
        {
            int totalGems = ServiceLocator.Instance.GetService<GemsSystem>().GetTotalGems();
            if (totalGems >= _upgradeValue)
            {
                ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Upgrade");

                int newGems = totalGems - _upgradeValue;
                ServiceLocator.Instance.GetService<GemsSystem>().SaveTotalGems(newGems);
                ServiceLocator.Instance.GetService<GemsView>().UpdateGems(newGems);

                var upgradeNodeActivedEventData = new UpgradeNodeActivedEventData(_nodeName, GetInstanceID());
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(upgradeNodeActivedEventData);

                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.UpgradeCheckForAvailability));

                _upgradeButton.interactable = false;

                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.UpgradesLevelUpPopUpSpawn));

                Hide();

            }
            else
            {
                ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("NotEnough");
                var NotEnoughEventData = new NotEnoughEventData("Gems", GetInstanceID());
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(NotEnoughEventData);
            }
        }

        private void OnCloseButtonPressed()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("ReverseBloop");
            Hide();
        }

        public void Show()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Bloop");
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetComponents(Sprite nodeIcon, Color nodeIconBackground, Color nodeIconDeepBackground, float statsToAdd, int gemCost,
                                  string nodeName)
        {
            _upgradeButton.interactable = true;
            _nodeIcon.sprite = nodeIcon;
            _nodeIconBackground.color = nodeIconBackground;
            _nodeIconDeepBackground.color = nodeIconDeepBackground;
            _statsToAdd.SetText(statsToAdd.ToString("f1"));
            _gemCost.SetText(gemCost.ToString());
            _upgradeValue = gemCost;
            _nodeName = nodeName;
        }
    }
}