using Assets.Code.Common.Events;
using Assets.Code.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.RESETBUTTONELIMINATE
{
    public class LevelUpButton : MonoBehaviour
    {

        [SerializeField] Button _levelUpButton;

        private void Awake()
        {
            _levelUpButton.onClick.AddListener(ResetAllUpgrades);
        }

        private void ResetAllUpgrades()
        {
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.LEVELUPEVENTTODELETE));
        }
    }
}