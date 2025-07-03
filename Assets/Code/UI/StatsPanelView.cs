using Assets.Code.Common.Events;
using Assets.Code.Core;
using TMPro;
using UnityEngine;

namespace Assets.Code.UI
{
    public class StatsPanelView : MonoBehaviour, EventObserver
    {

        [SerializeField] private TextMeshProUGUI _hp;
        [SerializeField] private TextMeshProUGUI _fire;
        [SerializeField] private TextMeshProUGUI _poison;
        [SerializeField] private TextMeshProUGUI _ice;
        [SerializeField] private TextMeshProUGUI _water;
        [SerializeField] private TextMeshProUGUI _electric;
        [SerializeField] private TextMeshProUGUI _ghost;
        [SerializeField] private TextMeshProUGUI _rainbow;
        [SerializeField] private Color _maxColor;
        [SerializeField] private Color _normalColor;

        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.PlayerSendFinalStatsValue, this);
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.PlayerSendFinalStatsValue, this);
        }


        private void SetFinalStatsOnPanel(int hpValue, float fire, float poison,
                                         float ice, float water, float electric,
                                         float ghost, float rainbow)
        {
            _hp.SetText(hpValue.ToString());
            _fire.SetText(fire.ToString("f1") + "%");
            _poison.SetText(poison.ToString("f1") + "%");
            _ice.SetText(ice.ToString("f1") + "%");
            _water.SetText(water.ToString("f1") + "%");
            _electric.SetText(electric.ToString("f1") + "%");
            _ghost.SetText(ghost.ToString("f1") + "%");
            _rainbow.SetText(rainbow.ToString("f1") + "%");

            if (fire >= 100)
            {
                _fire.color = _maxColor;
            }else
            {
                _fire.color = _normalColor;
            }
            if (poison >= 100)
            {
                _poison.color = _maxColor;
            }
            else
            {
                _poison.color = _normalColor;
            }
            if (ice >= 100)
            {
                _ice.color = _maxColor;
            }
            else
            {
                _ice.color = _normalColor;
            }
            if (water >= 100)
            {
                _water.color = _maxColor;
            }
            else
            {
                _water.color = _normalColor;
            }
            if (electric >= 100)
            {
                _electric.color = _maxColor;
            }
            else
            {
                _electric.color = _normalColor;
            }
            if (ghost >= 100)
            {
                _ghost.color = _maxColor;
            }
            else
            {
                _ghost.color = _normalColor;
            }
            if (rainbow >= 100)
            {
                _rainbow.color = _maxColor;
            }
            else
            {
                _rainbow.color = _normalColor;
            }
        }


        public void Process(EventData eventData)
        {

            if (eventData.EventId == EventIds.PlayerSendFinalStatsValue)
            {
                var playerSendFinalStatsEventData = (PlayerSendFinalStatsEventData)eventData;

                SetFinalStatsOnPanel(playerSendFinalStatsEventData.HpValue,
                            playerSendFinalStatsEventData.Fire, playerSendFinalStatsEventData.Poison,
                            playerSendFinalStatsEventData.Ice, playerSendFinalStatsEventData.Water,
                            playerSendFinalStatsEventData.Electric, playerSendFinalStatsEventData.Ghost,
                            playerSendFinalStatsEventData.Rainbow);


            }
        }
    }
}