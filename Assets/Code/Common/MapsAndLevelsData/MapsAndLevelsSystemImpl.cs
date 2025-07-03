using Assets.Code.Core.DataStorage;

namespace Assets.Code.Common.MapsAndLevelsData
{
    public class MapsAndLevelsSystemImpl : MapsAndLevelsSystem
    {
        private readonly DataStore _dataStore;
        private const string _lastMapPlayedData = "LastMapPlayedData";
        private const string _lastLevelPlayedData = "LastLevelPlayedData";
        private const string _maxMapReachedData = "MaxMapReachedData";
        private const string _maxLevelReachedData = "MaxLevelReachedData";
        private const string _isNewLevelPlayedData = "IsNewLevelPlayedData";
        private const string _isLastMapLevelPlayedData = "IsLastMapLevelPlayedData";
        private const string _isFirstUpdate = "IsFirstUpdate";
        private const string _isMoonWalkerPassed = "IsMoonWalkerPassed";
        private const string _isAtlansAbyssPassed = "IsAtlansAbyssPassed";
        private const string _isVillaSoldatiPassed = "IsVillaSoldatiPassed";
        private const string _isRaklionPassed = "IsRaklionPassed";
        private const string _isAcheronPassed = "IsAcheronPassed";
        private const string _isGameReviewed = "IsGameReviewed";
        private const string _isCongratulationsViewed = "IsCongratulationsViewed";



        public MapsAndLevelsSystemImpl(DataStore dataStore)
        {
            _dataStore = dataStore;
        }



        public void SaveLastMapPlayed(string lastMapPlayed)
        {
            var userData = new UserData { LastMapPlayed = lastMapPlayed };
            _dataStore.SetData(userData, _lastMapPlayedData);
        }


        public string GetLastMapPlayed()
        {
            var userData = _dataStore.GetData<UserData>(_lastMapPlayedData)
                        ?? new UserData();
            return userData.LastMapPlayed;
        }


        public void SaveLastLevelPlayed(int lastLevelPlayed)
        {
            var userData = new UserData { LastLevelPlayed = lastLevelPlayed };
            _dataStore.SetData(userData, _lastLevelPlayedData);
        }


        public int GetLastLevelPlayed()
        {
            var userData = _dataStore.GetData<UserData>(_lastLevelPlayedData)
                        ?? new UserData();
            return userData.LastLevelPlayed;
        }




        public void SaveMaxMapReached(string maxMapReached)
        {
            var userData = new UserData { MaxMapReached = maxMapReached };
            _dataStore.SetData(userData, _maxMapReachedData);
        }


        public string GetMaxMapReached()
        {
            var userData = _dataStore.GetData<UserData>(_maxMapReachedData)
                        ?? new UserData();
            return userData.MaxMapReached;
        }


        public void SaveMaxLevelReached(int maxLevelReached)
        {
            var userData = new UserData { MaxLevelReached = maxLevelReached };
            _dataStore.SetData(userData, _maxLevelReachedData);
        }


        public int GetMaxLevelReached()
        {
            var userData = _dataStore.GetData<UserData>(_maxLevelReachedData)
                        ?? new UserData();
            return userData.MaxLevelReached;
        }


        public void SaveIfIsNewLevelPlayed(bool isNewLevel)
        {
            var userData = new UserData { IsNewLevelPlayed = isNewLevel };
            _dataStore.SetData(userData, _isNewLevelPlayedData);
        }


        public bool IsNewLevelPlayed()
        {
            var userData = _dataStore.GetData<UserData>(_isNewLevelPlayedData)
                        ?? new UserData();
            return userData.IsNewLevelPlayed;
        }


        public void SaveIfIsLastMapLevelPlayed(bool isLastLevel)
        {
            var userData = new UserData { IsLastMapLevelPlayed = isLastLevel };
            _dataStore.SetData(userData, _isLastMapLevelPlayedData);
        }


        public bool IsLastMapLevelPlayed()
        {
            var userData = _dataStore.GetData<UserData>(_isLastMapLevelPlayedData)
                        ?? new UserData();
            return userData.IsLastMapLevelPlayed;
        }

        public void SaveIfIsFirstUpdate(bool isFirstUpdate)
        {
            var userData = new UserData { IsFirstUpdate = isFirstUpdate };
            _dataStore.SetData(userData, _isFirstUpdate);
        }


        public bool IsFirstUpdate()
        {
            var userData = _dataStore.GetData<UserData>(_isFirstUpdate)
                        ?? new UserData();
            return userData.IsFirstUpdate;
        }

        public void SaveIfIsMoonWalkerPassed(bool isMoonWalkerPassed)
        {
            var userData = new UserData { IsMoonWalkerPassed = isMoonWalkerPassed };
            _dataStore.SetData(userData, _isMoonWalkerPassed);
        }


        public bool IsMoonWalkerPassed()
        {
            var userData = _dataStore.GetData<UserData>(_isMoonWalkerPassed)
                        ?? new UserData();
            return userData.IsMoonWalkerPassed;
        }

        public void SaveIfIsAtlansAbyssPassed(bool isAtlansAbyssPassed)
        {
            var userData = new UserData { IsAtlansAbyssPassed = isAtlansAbyssPassed };
            _dataStore.SetData(userData, _isAtlansAbyssPassed);
        }


        public bool IsAtlansAbyssPassed()
        {
            var userData = _dataStore.GetData<UserData>(_isAtlansAbyssPassed)
                        ?? new UserData();
            return userData.IsAtlansAbyssPassed;
        }

        public void SaveIfIsVillaSoldatiPassed(bool isVillaSoldatiPassed)
        {
            var userData = new UserData { IsVillaSoldatiPassed = isVillaSoldatiPassed };
            _dataStore.SetData(userData, _isVillaSoldatiPassed);
        }


        public bool IsVillaSoldatiPassed()
        {
            var userData = _dataStore.GetData<UserData>(_isVillaSoldatiPassed)
                        ?? new UserData();
            return userData.IsVillaSoldatiPassed;
        }

        public void SaveIfIsRaklionPassed(bool isRaklionPassed)
        {
            var userData = new UserData { IsRaklionPassed = isRaklionPassed };
            _dataStore.SetData(userData, _isRaklionPassed);
        }


        public bool IsRaklionPassed()
        {
            var userData = _dataStore.GetData<UserData>(_isRaklionPassed)
                        ?? new UserData();
            return userData.IsRaklionPassed;
        }

        public void SaveIfIsAcheronPassed(bool isAcheronPassed)
        {
            var userData = new UserData { IsAcheronPassed = isAcheronPassed };
            _dataStore.SetData(userData, _isAcheronPassed);
        }


        public bool IsAcheronPassed()
        {
            var userData = _dataStore.GetData<UserData>(_isAcheronPassed)
                        ?? new UserData();
            return userData.IsAcheronPassed;
        }

        public void SaveIfIsGameReviewed(bool isReviewed)
        {
            var userData = new UserData { IsGameReviewed = isReviewed };
            _dataStore.SetData(userData, _isGameReviewed);
        }


        public bool IsGameReviewed()
        {
            var userData = _dataStore.GetData<UserData>(_isGameReviewed)
                        ?? new UserData();
            return userData.IsGameReviewed;
        }

        public void SaveIfIsCongratulationsViewed(bool isViewed)
        {
            var userData = new UserData { IsCongratulationsViewed = isViewed };
            _dataStore.SetData(userData, _isCongratulationsViewed);
        }


        public bool IsCongratulationsViewed()
        {
            var userData = _dataStore.GetData<UserData>(_isCongratulationsViewed)
                        ?? new UserData();
            return userData.IsCongratulationsViewed;
        }
    }
}