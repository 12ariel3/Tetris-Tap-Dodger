using Assets.Code.Core.DataStorage;

namespace Assets.Code.Common.Settings
{
    public class SettingsSystemImpl : SettingsSystem
    {
        private readonly DataStore _dataStore;
        private const string _mainMenuMusicIntensityData = "MainMenuMusicIntensityData";
        private const string _gameMusicIntensityData = "GameMusicIntensityData";
        private const string _swordIntensityData = "SwordIntensityData";
        private const string _projectileIntensityData = "ProjectileIntensityData";
        private const string _uISoundIntensityData = "UISoundIntensityData";
        private const string _vibrationData = "VibrationData";

        public SettingsSystemImpl(DataStore dataStore)
        {
            _dataStore = dataStore;
        }



        public float GetMainMenuMusicIntensity()
        {
            var userData = _dataStore.GetData<UserData>(_mainMenuMusicIntensityData)
                        ?? new UserData();
            return userData.MainMenuMusicIntensity;
        }

        public void SaveMainMenuMusicIntensity(float mainMenuMusicIntensity)
        {
            var userData = new UserData { MainMenuMusicIntensity = mainMenuMusicIntensity };
            _dataStore.SetData(userData, _mainMenuMusicIntensityData);
        }

        public float GetGameMusicIntensity()
        {
            var userData = _dataStore.GetData<UserData>(_gameMusicIntensityData)
                        ?? new UserData();
            return userData.GameMusicIntensity;
        }

        public void SaveGameMusicIntensity(float gameMusicIntensity)
        {
            var userData = new UserData { GameMusicIntensity = gameMusicIntensity };
            _dataStore.SetData(userData, _gameMusicIntensityData);
        }

        public float GetSwordIntensity()
        {
            var userData = _dataStore.GetData<UserData>(_swordIntensityData)
                        ?? new UserData();
            return userData.SwordIntensity;
        }

        public void SaveSwordIntensity(float swordIntensity)
        {
            var userData = new UserData { SwordIntensity = swordIntensity };
            _dataStore.SetData(userData, _swordIntensityData);
        }


        public float GetProjectileIntensity()
        {
            var userData = _dataStore.GetData<UserData>(_projectileIntensityData)
                        ?? new UserData();
            return userData.ProjectileIntensity;
        }

        public void SaveProjectileIntensity(float projectileIntensity)
        {
            var userData = new UserData { ProjectileIntensity = projectileIntensity };
            _dataStore.SetData(userData, _projectileIntensityData);
        }


        public float GetUISoundIntensity()
        {
            var userData = _dataStore.GetData<UserData>(_uISoundIntensityData)
                        ?? new UserData();
            return userData.UISoundIntensity;
        }

        public void SaveUISoundIntensity(float uISoundIntensity)
        {
            var userData = new UserData { UISoundIntensity = uISoundIntensity };
            _dataStore.SetData(userData, _uISoundIntensityData);
        }


        public bool IsVibrationActived()
        {
            var userData = _dataStore.GetData<UserData>(_vibrationData)
                        ?? new UserData();
            return userData.IsVibrationActived;
        }

        public void SaveIfVibrationIsActived(bool isVibrationActived)
        {
            var userData = new UserData { IsVibrationActived = isVibrationActived };
            _dataStore.SetData(userData, _vibrationData);
        }
    }
}