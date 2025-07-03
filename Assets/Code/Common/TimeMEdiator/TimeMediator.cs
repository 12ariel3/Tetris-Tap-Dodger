using Assets.Code.Common.EnergyData;
using Assets.Code.Common.Events;
using Assets.Code.Core;
using System;
using UnityEngine;

namespace Assets.Code.Common.TimeMediator
{
    public class TimeMediator : MonoBehaviour
    {

        private float _counter = 20;
        

        private float _timeSinceLastEnergyRecovered;
        private DateTime _timeWhenLastEnergyWasRecovered;


        void Start()
        {
            GetDateTimeFromLocal();
           // StartCoroutine(GetDateTimeFromServer());

            //Take madafucking off vsync!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Application.targetFrameRate = 60;
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }

        private void Update()
        {
            _counter -= Time.deltaTime;
            if (_counter <= 0)
            {
                GetDateTimeFromLocal();
                _counter = 20;
            }
        }


        private DateTime StringToDate(string dateTime)
        {
            if (dateTime == "None")
            {
                ServiceLocator.Instance.GetService<EnergySystem>().SaveLastDateEnergyRecovered(DateTime.Now.ToString());
                return DateTime.Now;
            }
            else
            {
                return DateTime.Parse(dateTime);
            }
        }

        private void GetDateTimeFromLocal()
        {
            var energySystem = ServiceLocator.Instance.GetService<EnergySystem>();
            _timeWhenLastEnergyWasRecovered = StringToDate(energySystem.GetLastDateEnergyRecovered());

            _timeSinceLastEnergyRecovered = (float)(DateTime.Now - _timeWhenLastEnergyWasRecovered).TotalMinutes;


            if (_timeSinceLastEnergyRecovered >= 5)
            {
                int energyToAdd = Mathf.FloorToInt(_timeSinceLastEnergyRecovered / 5);
                float currentEnergy = energySystem.GetActualEnergy();
                float totalEnergy = energySystem.GetTotalEnergy();
                currentEnergy = Mathf.Min(totalEnergy, currentEnergy + energyToAdd);

                energySystem.SaveActualEnergy(currentEnergy);
                energySystem.SaveLastDateEnergyRecovered(DateTime.Now.ToString());

                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.EnergyRecovered));
            }

        }
    }
}