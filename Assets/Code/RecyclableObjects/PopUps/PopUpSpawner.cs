using Assets.Code.Common.Events;
using Assets.Code.Core;
using Assets.Code.RecyclableObjects.PopUps.HpPopUp;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.PopUps
{
    public class PopUpSpawner : MonoBehaviour, EventObserver
    {

        private DamagePopUpFactory _damagePopUpFactory;
        private HpPopUpFactory _hpPopUpFactory;


        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.DamagePopUpValue, this);
            eventQueue.Subscribe(EventIds.HpPopUpValue, this);
            eventQueue.Subscribe(EventIds.ProjectileDestroyed, this);
            _damagePopUpFactory = ServiceLocator.Instance.GetService<DamagePopUpFactory>();
            _hpPopUpFactory = ServiceLocator.Instance.GetService<HpPopUpFactory>();
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.DamagePopUpValue, this);
            eventQueue.Unsubscribe(EventIds.HpPopUpValue, this);
            eventQueue.Unsubscribe(EventIds.ProjectileDestroyed, this);
        }


        private void SpawnHit(string damagePopUpId, int attackValue, Vector3 position)
        {
            var popUpBuilder = _damagePopUpFactory.Create(damagePopUpId);
            popUpBuilder.WithPosition(position)
                        .WithRotation(Quaternion.identity)
                        .WithAttackValue(attackValue)
                        .Build();
        }

        private void SpawnHealingHpPopUp(int hpValue)
        {
            if (hpValue > 0)
            {
                var popUpBuilder = _hpPopUpFactory.Create("Health");
                popUpBuilder.WithPosition()
                            .WithId("Health")
                            .WithAttackValue(hpValue)
                            .Build();
            }
        }

        private void SpawnDamageHpPopUp(int hpToRestValue)
        {
            if (hpToRestValue > 0)
            {
                var popUpBuilder = _hpPopUpFactory.Create("Damage");
                popUpBuilder.WithPosition()
                            .WithId("Damage")
                            .WithAttackValue(hpToRestValue)
                            .Build();
            }
        }


        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.DamagePopUpValue)
            {
                var damagePopUpEventData = (DamagePopUpEventData)eventData;
                SpawnHit(damagePopUpEventData.Id, damagePopUpEventData.AttackValue, damagePopUpEventData.Position);
            }


            if (eventData.EventId == EventIds.HpPopUpValue)
            {
                var hpPopUpEventData = (HpPopUpEventData)eventData;
                SpawnHealingHpPopUp(hpPopUpEventData.HpValue);
            }

            if (eventData.EventId == EventIds.ProjectileDestroyed)
            {
                var projectileDestroyedEventData = (ProjectileDestroyedEventData)eventData;
                SpawnDamageHpPopUp(projectileDestroyedEventData.AttackToRest);
            }
        }
    }
}