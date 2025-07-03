using Assets.Code.Common.Events;
using Assets.Code.Core.DataStorage;
using Assets.Code.Core;
using Assets.Code.UI;
using UnityEngine;

namespace Assets.Code.Common.GemsData
{
    public class GemsSystemImpl : EventObserver, GemsSystem
    {
        private readonly DataStore _dataStore;
        private int _battleCurrentGems;
        private int _totalGems;
        private const string UserData = "UserGemsData";

        public int BattleCurrentGems => _battleCurrentGems;


        public GemsSystemImpl(DataStore dataStore)
        {
            _dataStore = dataStore;
            _totalGems = GetTotalGems();
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.ReturnToMainMenu, this);
            eventQueue.Subscribe(EventIds.ProjectileDestroyed, this);
            eventQueue.Subscribe(EventIds.VictorySpinWheelSendFinalValues, this);
        }

        public void Reset()
        {
            _battleCurrentGems = 0;
        }

        public void ShowTotalGems()
        {
            ServiceLocator.Instance.GetService<GemsView>().UpdateGems(_totalGems);
        }




        private void AddGems(int gemsToAdd)
        {
            _battleCurrentGems += gemsToAdd;
            ServiceLocator.Instance.GetService<GemsView>().UpdateGems(_battleCurrentGems);
        }


        public void SaveTotalGems(int totalGems)
        {
            _totalGems = totalGems;
            var userData = new UserData { TotalGems = totalGems };
            _dataStore.SetData(userData, UserData);
        }


        public int GetTotalGems()
        {
            var userData = _dataStore.GetData<UserData>(UserData)
                        ?? new UserData();
            return userData.TotalGems;
        }



        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ReturnToMainMenu)
            {
                _totalGems += _battleCurrentGems;
                SaveTotalGems(_totalGems);
                return;
            }


            if (eventData.EventId == EventIds.ProjectileDestroyed)
            {
                var projectileDestroyedEventData = (ProjectileDestroyedEventData)eventData;
                if (Random.Range(0, 100) <= projectileDestroyedEventData.GemsProbability)
                {
                    AddGems(projectileDestroyedEventData.GemsToAdd);
                }
                return;
            }


            if (eventData.EventId == EventIds.VictorySpinWheelSendFinalValues)
            {
                var victorySpinWheelSendEventData = (VictorySpinWheelSendEventData)eventData;
                _battleCurrentGems = victorySpinWheelSendEventData.BattleFinalGems;
                return;
            }
        }
    }
}