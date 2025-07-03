using Assets.Code.Common.Events;
using Assets.Code.Core.DataStorage;
using Assets.Code.Core;
using UnityEngine.SceneManagement;
using Assets.Code.Common.UpgradesData;
using Assets.Code.UI;
using System;

namespace Assets.Code.Common.EnergyData
{
    public class EnergySystemImpl : EventObserver, EnergySystem
    {

        private readonly DataStore _dataStore;
        private float _totalEnergy;
        private float _actualEnergy;
        private const string UserTotalEnergyData = "UserTotalEnergyData";
        private const string UserActualEnergyData = "UserActualEnergyData";
        private const string LastDateEnergyRecoveredData = "LastDateEnergyRecoveredData";



        public EnergySystemImpl(DataStore dataStore)
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            _dataStore = dataStore;
            _actualEnergy = GetActualEnergy();
            _totalEnergy = GetTotalEnergy() + ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeEnergy();
            eventQueue.Subscribe(EventIds.EnergyNodeActived, this);
            eventQueue.Subscribe(EventIds.LevelUp, this);
            eventQueue.Subscribe(EventIds.EnergyRecovered, this);
        }



        public void SetEnergyValues()
        {
            ServiceLocator.Instance.GetService<EnergyView>().UpdateEnergy(_actualEnergy, _totalEnergy);
        }



        public void RecoverEnergy(int energyToAdd)
        {
            _actualEnergy = Math.Min((_actualEnergy + energyToAdd), _totalEnergy);
            ServiceLocator.Instance.GetService<EnergyView>().UpdateEnergy(_actualEnergy, _totalEnergy);
        }


        public void RestEnergy(int energyToRest)
        {
            _actualEnergy -= energyToRest;
            ServiceLocator.Instance.GetService<EnergyView>().UpdateEnergy(_actualEnergy, _totalEnergy);
        }


        public void SaveTotalEnergy(float totalEnergy)
        {
            _totalEnergy = totalEnergy;
            var userData = new UserData { TotalEnergy = totalEnergy };
            _dataStore.SetData(userData, UserTotalEnergyData);
        }


        public float GetTotalEnergy()
        {
            var userData = _dataStore.GetData<UserData>(UserTotalEnergyData)
                        ?? new UserData();
            return userData.TotalEnergy;
        }


        public void SaveActualEnergy(float actualEnergy)
        {
            _actualEnergy = actualEnergy;
            var userData = new UserData { ActualEnergy = actualEnergy };
            _dataStore.SetData(userData, UserActualEnergyData);
        }


        public float GetActualEnergy()
        {
            var userData = _dataStore.GetData<UserData>(UserActualEnergyData)
                        ?? new UserData();
            return userData.ActualEnergy;
        }

        public void SaveLastDateEnergyRecovered(string dateEnergyRecoveredToSave)
        {
            var userData = new UserData { LastDateEnergyRecovered = dateEnergyRecoveredToSave };
            _dataStore.SetData(userData, LastDateEnergyRecoveredData);
        }


        public string GetLastDateEnergyRecovered()
        {
            var userData = _dataStore.GetData<UserData>(LastDateEnergyRecoveredData)
                        ?? new UserData();
            return userData.LastDateEnergyRecovered;
        }


        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.EnergyNodeActived)
            {
                var energyNodeActivedEventData = (EnergyNodeActivedEventData)eventData;
                _actualEnergy += energyNodeActivedEventData.EnergyAdded;
                _totalEnergy = GetTotalEnergy() + ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeEnergy();
                SaveActualEnergy(_actualEnergy);
                SaveTotalEnergy(_totalEnergy);
                SetEnergyValues();
            }

            if (eventData.EventId == EventIds.LevelUp)
            {
                _totalEnergy = GetTotalEnergy() + UnityEngine.Random.Range(1, 3);
                _actualEnergy = _totalEnergy;
                SaveActualEnergy(_actualEnergy);
                SaveTotalEnergy(_totalEnergy);
            }

            if (eventData.EventId == EventIds.EnergyRecovered)
            {
                Scene scene = SceneManager.GetActiveScene();
                if (scene.name != "Game")
                {
                    SetEnergyValues();
                }

            }
        }
    }
}