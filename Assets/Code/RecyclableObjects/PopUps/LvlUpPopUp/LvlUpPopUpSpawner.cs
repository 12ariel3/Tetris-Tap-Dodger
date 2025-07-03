using Assets.Code.Common.Events;
using Assets.Code.Core;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.PopUps.LvlUpPopUp
{
    public class LvlUpPopUpSpawner : MonoBehaviour, EventObserver
    {
        private LvlUpPopUpFactory _lvlUpPopUpFactory;
        private bool _isSpamed;

        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.LevelUp, this);
            eventQueue.Subscribe(EventIds.SwordLevelUp50, this);
            eventQueue.Subscribe(EventIds.LvlUpMediatorHasEnded, this);
            eventQueue.Subscribe(EventIds.NotEnoughEvent, this);
            _lvlUpPopUpFactory = ServiceLocator.Instance.GetService<LvlUpPopUpFactory>();
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.LevelUp, this);
            eventQueue.Unsubscribe(EventIds.SwordLevelUp50, this);
            eventQueue.Unsubscribe(EventIds.LvlUpMediatorHasEnded, this);
            eventQueue.Unsubscribe(EventIds.NotEnoughEvent, this);
            _isSpamed = false;
        }


        private void SpawnLvlUpPopUp()
        {
            var particleBuilder = _lvlUpPopUpFactory.Create("LvlUpPopUp");
            particleBuilder.WithPosition()
                           .Build();
        }

        private void SpawnSwordLvlUp50PopUp(Vector3 position)
        {
            var particleBuilder = _lvlUpPopUpFactory.Create("SwordLvlUp50PopUp");
            particleBuilder.WithPosition2(position)
                           .Build();
        }


        private void SpawnNotEnoughPopUp(string id)
        {
            LvlUpPopUpBuilder particleBuilder;

            switch (id)
            {
                case "Score":
                    particleBuilder = _lvlUpPopUpFactory.Create("NotScore");
                    particleBuilder.WithPosition()
                                   .Build();
                    return;

                case "Gems":
                    particleBuilder = _lvlUpPopUpFactory.Create("NotGems");
                    particleBuilder.WithPosition()
                                   .Build();
                    return;

                case "Energy":
                    particleBuilder = _lvlUpPopUpFactory.Create("NotEnergy");
                    particleBuilder.WithPosition()
                                   .Build();
                    return;

                case "SpinWheelScore":
                    particleBuilder = _lvlUpPopUpFactory.Create("SpinWheelScore");
                    particleBuilder.WithPosition()
                                   .Build();
                    return;

                case "SpinWheelGems":
                    particleBuilder = _lvlUpPopUpFactory.Create("SpinWheelGems");
                    particleBuilder.WithPosition()
                                   .Build();
                    return;

                case "SpinWheelEnergy":
                    particleBuilder = _lvlUpPopUpFactory.Create("SpinWheelEnergy");
                    particleBuilder.WithPosition()
                                   .Build();
                    return;

                case "SpinWheelExp":
                    particleBuilder = _lvlUpPopUpFactory.Create("SpinWheelExp");
                    particleBuilder.WithPosition()
                                   .Build();
                    return;

                case "NotConnection":
                    particleBuilder = _lvlUpPopUpFactory.Create("NotConnection");
                    particleBuilder.WithPosition()
                                   .Build();
                    return;
            }
        }



        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.LevelUp)
            {

                if (_isSpamed == false)
                {
                    SpawnLvlUpPopUp();
                    _isSpamed = true;
                }

                return;
            }
            
            if (eventData.EventId == EventIds.SwordLevelUp50)
            {
                var swordLvlUpPopUp50EventData = (SwordLvlUpPopUp50EventData)eventData;

                SpawnSwordLvlUp50PopUp(swordLvlUpPopUp50EventData.Position);

                return;
            }

            if (eventData.EventId == EventIds.LvlUpMediatorHasEnded)
            {
                _isSpamed = false;
            }

            if (eventData.EventId == EventIds.NotEnoughEvent)
            {
                var notEnoughEventData = (NotEnoughEventData)eventData;

                SpawnNotEnoughPopUp(notEnoughEventData.Id);
            }
        }
    }
}