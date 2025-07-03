using Assets.Code.Common.Events;
using Assets.Code.Core;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.PopUps.UpgradesLevelUpPopUp
{
    public class UpgradesLevelUpPopUpSpawner : MonoBehaviour, EventObserver
    {

        private UpgradesLevelUpPopUpFactory _upgradesLevelUpPopUpFactory;
        private SwordEquipedPopUpFactory _swordEquipedPopUpFactory;
        [SerializeField] private Transform _canvasTransform;

        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.UpgradesLevelUpPopUpSpawn, this);
            eventQueue.Subscribe(EventIds.ActiveSwordEquippedPopUp, this);
            _upgradesLevelUpPopUpFactory = ServiceLocator.Instance.GetService<UpgradesLevelUpPopUpFactory>();
            _swordEquipedPopUpFactory = ServiceLocator.Instance.GetService<SwordEquipedPopUpFactory>();
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.UpgradesLevelUpPopUpSpawn, this);
            eventQueue.Unsubscribe(EventIds.ActiveSwordEquippedPopUp, this);
        }


        private void SpawnUpgradesLevelUpPopUp()
        {
            var upgradesLevelUpPopUpBuilder = _upgradesLevelUpPopUpFactory.Create("UpgradesLevelUpPopUp");
            upgradesLevelUpPopUpBuilder.WithParentTransform(_canvasTransform);
            upgradesLevelUpPopUpBuilder.Build();
        }

        private void SpawnSwordEquipedPopUp()
        {
            var upgradesLevelUpPopUpBuilder = _swordEquipedPopUpFactory.Create("SwordEquipedPopUp");
            upgradesLevelUpPopUpBuilder.WithParentTransform(_canvasTransform);
            upgradesLevelUpPopUpBuilder.Build();
        }


        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.UpgradesLevelUpPopUpSpawn)
            {
                SpawnUpgradesLevelUpPopUp();
            }

            if (eventData.EventId == EventIds.ActiveSwordEquippedPopUp)
            {

                SpawnSwordEquipedPopUp();

            }
        }
    }
}