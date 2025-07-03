using Assets.Code.Common.Events;
using Assets.Code.Core;
using System.Collections;
using UnityEngine;

namespace Assets.Code.UI
{
    public class UpgradesPanelView : MonoBehaviour, EventObserver
    {

        [SerializeField] private UpgradesInfoView _upgradesInfoView;


        private void Start()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.UpgradesPanelView, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.UpgradesPanelViewClose, this);
            HideAllMenus();
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.UpgradesPanelView, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.UpgradesPanelViewClose, this);
        }

        private void HideAllMenus()
        {
            _upgradesInfoView.Hide();
        }


        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.UpgradesPanelView)
            {
                var upgradesPanelViewEventData = (UpgradesPanelEventData)eventData;

                _upgradesInfoView.SetComponents(upgradesPanelViewEventData.NodeIcon.sprite, upgradesPanelViewEventData.NodeBackground.color,
                                                upgradesPanelViewEventData.NodeDeepBackground.color, upgradesPanelViewEventData.StatsToAdd,
                                                upgradesPanelViewEventData.GemCost, upgradesPanelViewEventData.NodeId);
                _upgradesInfoView.Show();
                return;
            }

            if (eventData.EventId == EventIds.UpgradesPanelViewClose)
            {
                _upgradesInfoView.Hide();
            }
        }
    }
}