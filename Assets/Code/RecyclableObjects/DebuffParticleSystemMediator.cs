using Assets.Code.Common;
using Assets.Code.Common.Events;
using Assets.Code.Core;
using Assets.Code.Enemies;
using UnityEngine;

namespace Assets.Code.RecyclableObjects
{
    public class DebuffParticleSystemMediator : RecyclableObject, EventObserver
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private ProjectileId _projectileId;
        [SerializeField] private int _particleDuration;

        private float _counter;
        private Transform _playerTransform;
        public string Id => _projectileId.Value;

        public void Configure(Transform playerTransform)
        {
            _playerTransform = playerTransform;
            transform.position = new Vector3(0, 0, 0);
        }

        internal override void Init()
        {
            _counter = 0;
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.ContinueBattleAfterAds, this);
        }

        internal override void Release()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.ContinueBattleAfterAds, this);
        }


        private void Update()
        {
            _counter += Time.deltaTime;
            if (_counter > _particleDuration)
            {
                var debuffDeactivatedEventData = new DebuffDeactivatedEventData(Id, GetInstanceID());
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(debuffDeactivatedEventData);
                Recycle();
            }
        }

        private void FixedUpdate()
        {
            if(Id != "Ghost" && Id != "Water")
            {
                transform.position = _playerTransform.position;
            }
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ContinueBattleAfterAds)
            {
                Recycle();
            }
        }
    }
}