using Assets.Code.Common.Events;
using Assets.Code.Core;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.BloodyOverlay
{
    public class BloodyOverlaySpawner : MonoBehaviour, EventObserver
    {

        private BloodyOverlayFactory _bloodyOverlayFactory;
        private bool _alreadyActive;

        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.PlayerHealthChanged, this);
            _bloodyOverlayFactory = ServiceLocator.Instance.GetService<BloodyOverlayFactory>();
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.PlayerHealthChanged, this);
        }


        private void SpawnBloodyOverlay(bool isActive)
        {
            if (isActive && !_alreadyActive)
            {
                var bloodyOverlayBuilder = _bloodyOverlayFactory.Create("Bloody");
                bloodyOverlayBuilder.WithIsActive(isActive)
                                    .Build();
                _alreadyActive = true;
            }
            if (!isActive)
            {
                _alreadyActive = false;
            }
        }


        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.PlayerHealthChanged)
            {
                var playerHealthChangedEventData = (PlayerHealthChangedEventData)eventData;
                SpawnBloodyOverlay(playerHealthChangedEventData.IsBlooding);
            }
        }
    }
}