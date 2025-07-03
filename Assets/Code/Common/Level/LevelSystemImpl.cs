using Assets.Code.Common.Events;
using Assets.Code.Core.DataStorage;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using Assets.Code.UI;
using UnityEngine;

namespace Assets.Code.Common.Level
{
    public class LevelSystemImpl : EventObserver, LevelSystem
    {
        private readonly DataStore _dataStore;
        private int _currentLevel;
        private int _maxExp;
        private int _currentExp;
        private const string _userLevelData = "UserLevelData";
        private const string _userExpData = "UserExpData";
        private const string _userCurrentMaxExpData = "UserCurrentMaxData";

        private int _acumulativeExp;



        public LevelSystemImpl(DataStore dataStore)
        {
            _dataStore = dataStore;
            _currentLevel = GetCurrentLevel();
            _currentExp = GetCurrentExp();
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.Victory, this);
            eventQueue.Subscribe(EventIds.GameOver, this);
            eventQueue.Subscribe(EventIds.ProjectileDestroyed, this);
            eventQueue.Subscribe(EventIds.FortuneWheelExperienceGained, this);
            eventQueue.Subscribe(EventIds.LEVELUPEVENTTODELETE, this);
        }


        private void AddExperience(int experienceToAdd)
        {
            if (_currentLevel < 100)
            {
                _currentExp += experienceToAdd;
                if (_currentExp >= _maxExp)
                {
                    LevelUp();
                    var levelUpEventData = new LevelUpEventData(_currentLevel);
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(levelUpEventData);
                }
                ServiceLocator.Instance.GetService<LevelExperienceView>().UpdateExperience(_currentExp);
                ServiceLocator.Instance.GetService<LevelExperienceView>().UpdateLevel(_currentLevel);
            }
        }

        //FUNCTION TO DELETE!!!!

        private void AddLevelFromButtonOnScene()
        {
            int expToAdd = ServiceLocator.Instance.GetService<LevelSystem>().GetCurrentMaxExp();
            _acumulativeExp += expToAdd;
            AddExperience(expToAdd);
            var levelUpEventData = new LevelUpEventData(_currentLevel);
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(levelUpEventData);
            ServiceLocator.Instance.GetService<LevelExperienceView>().UpdateExperience(_currentExp);
            ServiceLocator.Instance.GetService<LevelExperienceView>().UpdateLevel(_currentLevel);
        }

        //!!!!!!!!!!!!!!

        private void LevelUp()
        {
            if (_currentLevel < 100)
            {
                ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("LevelUp");
                int excess = _currentExp - _maxExp;
                _currentExp = excess;
                _currentLevel++;
                SetExperienceValues();
            }
        }

        public void SetExperienceValues()
        {
            _maxExp = (_currentLevel * _currentLevel * _currentLevel * 50) + 700;
            SaveCurrentMaxExp(_maxExp);
            SaveLevelData(_currentLevel);
            ServiceLocator.Instance.GetService<LevelExperienceView>().UpdateLevel(_currentLevel);
            ServiceLocator.Instance.GetService<LevelExperienceView>().UpdateActualLevelMaxExperience(_maxExp);
            ServiceLocator.Instance.GetService<LevelExperienceView>().UpdateExperience(_currentExp);
        }


        public int GetCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_userLevelData)
                        ?? new UserData();
            return userData.PlayerLevel;
        }

        public int GetCurrentExp()
        {
            var userData = _dataStore.GetData<UserData>(_userExpData)
                        ?? new UserData();
            return userData.PlayerExp;
        }


        public int GetCurrentMaxExp()
        {
            var userData = _dataStore.GetData<UserData>(_userCurrentMaxExpData)
                        ?? new UserData();
            return userData.PlayerCurrentMaxExp;
        }

        public void SaveCurrentMaxExp(int currentMaxExp)
        {
            var userData = new UserData { PlayerCurrentMaxExp = currentMaxExp };
            _dataStore.SetData(userData, _userCurrentMaxExpData);
        }


        public void SaveLevelData(int level)
        {
            var userData = new UserData { PlayerLevel = level };
            _dataStore.SetData(userData, _userLevelData);
            _currentLevel = level;
        }

        public void SaveCurrentExpData(int currentExp)
        {
            var userData = new UserData { PlayerExp = currentExp };
            _dataStore.SetData(userData, _userExpData);
            _currentExp = currentExp;
        }


        public void Process(EventData eventData)
        {

            if (eventData.EventId == EventIds.LEVELUPEVENTTODELETE)
            {
                AddLevelFromButtonOnScene();
                return;
            }

            if (eventData.EventId == EventIds.Victory)
            {
                SaveLevelData(_currentLevel);
                SaveCurrentExpData(_currentExp);
                return;
            }

            if (eventData.EventId == EventIds.GameOver)
            {
                SaveLevelData(_currentLevel);
                SaveCurrentExpData(_currentExp);
                return;
            }

            if (eventData.EventId == EventIds.ProjectileDestroyed)
            {
                var projectileDestroyedEventData = (ProjectileDestroyedEventData)eventData;
                AddExperience(projectileDestroyedEventData.ExperienceToAdd);

                return;
            }

            if (eventData.EventId == EventIds.FortuneWheelExperienceGained)
            {
                var fortuneWheelExperienceGainedEventData = (FortuneWheelExperienceGainedEventData)eventData;
                AddExperience(fortuneWheelExperienceGainedEventData.Amount);
                SaveLevelData(_currentLevel);
                SaveCurrentExpData(_currentExp);
                return;
            }
        }
    }
}