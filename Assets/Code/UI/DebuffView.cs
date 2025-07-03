using Assets.Code.Common.Events;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class DebuffView : MonoBehaviour, EventObserver
    {
        [SerializeField] private Image _fireIcon;
        [SerializeField] private Image _poisonIcon;
        [SerializeField] private Image _iceIcon;
        [SerializeField] private Image _waterIcon;
        [SerializeField] private Image _electricIcon;
        [SerializeField] private Image _ghostIcon;
        [SerializeField] private Image _rainbowIcon;


        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.ContinueBattleAfterAds, this);
            eventQueue.Subscribe(EventIds.DebuffActivated, this);
            eventQueue.Subscribe(EventIds.DebuffDeactivated, this);
            DeactivateAllDebuffs();
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.ContinueBattleAfterAds, this);
            eventQueue.Unsubscribe(EventIds.DebuffActivated, this);
            eventQueue.Unsubscribe(EventIds.DebuffDeactivated, this);
        }
        
        private void DeactivateAllDebuffs()
        {
            _fireIcon.gameObject.SetActive(false);
            _poisonIcon.gameObject.SetActive(false);
            _iceIcon.gameObject.SetActive(false);
            _waterIcon.gameObject.SetActive(false);
            _electricIcon.gameObject.SetActive(false);
            _ghostIcon.gameObject.SetActive(false);
            _rainbowIcon.gameObject.SetActive(false);
        }

        private void ActivateDebuff(string debuffName)
        {
            switch (debuffName)
            {
                case "Fire":
                    _fireIcon.gameObject.SetActive(true);
                    return;

                case "Poison":
                    _poisonIcon.gameObject.SetActive(true);
                    return;

                case "Ice":
                    _iceIcon.gameObject.SetActive(true);
                    return;

                case "Water":
                    _waterIcon.gameObject.SetActive(true);
                    return;

                case "Electric":
                    _electricIcon.gameObject.SetActive(true);
                    return;

                case "Ghost":
                    _ghostIcon.gameObject.SetActive(true);
                    return;

                case "Rainbow":
                    _rainbowIcon.gameObject.SetActive(true);
                    return;
            }
        }

        private void DeactivateDebuff(string debuffName)
        {
            switch (debuffName)
            {
                case "Fire":
                    _fireIcon.gameObject.SetActive(false);
                    return;

                case "Poison":
                    _poisonIcon.gameObject.SetActive(false);
                    return;

                case "Ice":
                    _iceIcon.gameObject.SetActive(false);
                    return;

                case "Water":
                    _waterIcon.gameObject.SetActive(false);
                    return;

                case "Electric":
                    _electricIcon.gameObject.SetActive(false);
                    return;

                case "Ghost":
                    _ghostIcon.gameObject.SetActive(false);
                    return;

                case "Rainbow":
                    _rainbowIcon.gameObject.SetActive(false);
                    return;
            }
        }



        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.DebuffActivated)
            {
                var debuffActivatedEventData = (DebuffActivatedEventData)eventData;
                ActivateDebuff(debuffActivatedEventData.DebuffName);
            }

            if (eventData.EventId == EventIds.DebuffDeactivated)
            {
                var debuffDeactivatedEventData = (DebuffDeactivatedEventData)eventData;
                DeactivateDebuff(debuffDeactivatedEventData.DebuffName);
            }

            if (eventData.EventId == EventIds.ContinueBattleAfterAds)
            {
                DeactivateAllDebuffs();
            }
        }
    }
}