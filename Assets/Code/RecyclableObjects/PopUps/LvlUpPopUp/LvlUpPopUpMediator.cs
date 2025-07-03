using Assets.Code.Common;
using Assets.Code.Common.Events;
using Assets.Code.Core;
using Assets.Code.Enemies;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.PopUps.LvlUpPopUp
{
    public class LvlUpPopUpMediator : RecyclableObject
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private ProjectileId _projectileId;

        private float _counter;
        public string Id => _projectileId.Value;

        internal override void Init()
        {
            _counter = 0;
        }

        internal override void Release()
        {
        }


        private void Update()
        {
            _counter += Time.deltaTime;
            if (_counter > _particleSystem.main.duration)
            {
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.LvlUpMediatorHasEnded));
                Recycle();
            }
        }
    }
}