using Assets.Code.Core.DataStorage;

namespace Assets.Code.Common.UpgradesData
{
    public class UpgradesSystemImpl : UpgradesSystem
    {
        private readonly DataStore _dataStore;
        private const string _hpData = "HpData";
        private const string _fireData = "FireData";
        private const string _poisonData = "PoisonData";
        private const string _iceData = "IceData";
        private const string _waterData = "WaterData";
        private const string _electricData = "ElectricData";
        private const string _ghostData = "GhostData";
        private const string _rainbowData = "RainbowData";
        private const string _energyData = "EnergyData";



        public UpgradesSystemImpl(DataStore dataStore)
        {
            _dataStore = dataStore;
        }


        public float GetUpgradeHp()
        {
            var userData = _dataStore.GetData<UserData>(_hpData)
                        ?? new UserData();
            return userData.UpgradesHp;
        }
        public void SaveUpgradeHp(float upgradeHp)
        {
            var userData = new UserData { UpgradesHp = upgradeHp };
            _dataStore.SetData(userData, _hpData);
        }



        public float GetUpgradeFire()
        {
            var userData = _dataStore.GetData<UserData>(_fireData)
                        ?? new UserData();
            return userData.UpgradesFire;
        }
        public void SaveUpgradeFire(float upgradeFire)
        {
            var userData = new UserData { UpgradesFire = upgradeFire };
            _dataStore.SetData(userData, _fireData);
        }



        public float GetUpgradePoison()
        {
            var userData = _dataStore.GetData<UserData>(_poisonData)
                        ?? new UserData();
            return userData.UpgradesPoison;
        }
        public void SaveUpgradePoison(float upgradePoison)
        {
            var userData = new UserData { UpgradesPoison = upgradePoison };
            _dataStore.SetData(userData, _poisonData);
        }



        public float GetUpgradeIce()
        {
            var userData = _dataStore.GetData<UserData>(_iceData)
                        ?? new UserData();
            return userData.UpgradesIce;
        }
        public void SaveUpgradeIce(float upgradeIce)
        {
            var userData = new UserData { UpgradesIce = upgradeIce };
            _dataStore.SetData(userData, _iceData);
        }



        public float GetUpgradeWater()
        {
            var userData = _dataStore.GetData<UserData>(_waterData)
                        ?? new UserData();
            return userData.UpgradesWater;
        }
        public void SaveUpgradeWater(float upgradeWater)
        {
            var userData = new UserData { UpgradesWater = upgradeWater };
            _dataStore.SetData(userData, _waterData);
        }



        public float GetUpgradeElectric()
        {
            var userData = _dataStore.GetData<UserData>(_electricData)
                        ?? new UserData();
            return userData.UpgradesElectric;
        }
        public void SaveUpgradeElectric(float upgradeElectric)
        {
            var userData = new UserData { UpgradesElectric = upgradeElectric };
            _dataStore.SetData(userData, _electricData);
        }



        public float GetUpgradeGhost()
        {
            var userData = _dataStore.GetData<UserData>(_ghostData)
                        ?? new UserData();
            return userData.UpgradesGhost;
        }
        public void SaveUpgradeGhost(float upgradeGhost)
        {
            var userData = new UserData { UpgradesGhost = upgradeGhost };
            _dataStore.SetData(userData, _ghostData);
        }

        public float GetUpgradeRainbow()
        {
            var userData = _dataStore.GetData<UserData>(_rainbowData)
                        ?? new UserData();
            return userData.UpgradesRainbow;
        }
        public void SaveUpgradeRainbow(float upgradeRainbow)
        {
            var userData = new UserData { UpgradesRainbow = upgradeRainbow };
            _dataStore.SetData(userData, _rainbowData);
        }

        public float GetUpgradeEnergy()
        {
            var userData = _dataStore.GetData<UserData>(_energyData)
                        ?? new UserData();
            return userData.UpgradesEnergy;
        }
        public void SaveUpgradeEnergy(float upgradeEnergy)
        {
            var userData = new UserData { UpgradesEnergy = upgradeEnergy };
            _dataStore.SetData(userData, _energyData);
        }
    }
}