using Assets.Code.Common.Events;
using Assets.Code.Common.UpgradesData;
using Assets.Code.Core;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerStatsController : MonoBehaviour
    {
        private int _level;

        private int _baseHp;
        private float _baseFire;
        private float _basePoison;
        private float _baseIce;
        private float _baseWater;
        private float _baseElectric;
        private float _baseGhost;
        private float _baseRainbow;


        // player stats

        private int _playerHp;
        private float _playerFire;
        private float _playerPoison;
        private float _playerIce;
        private float _playerWater;
        private float _playerElectric;
        private float _playerGhost;
        private float _playerRainbow;


        // trail stats

        private int _trailHp;
        private float _trailFire;
        private float _trailPoison;
        private float _trailIce;
        private float _trailWater;
        private float _trailElectric;
        private float _trailGhost;
        private float _trailRainbow;


        // upgrades stats

        private float _upgradesHp;
        private float _upgradesFire;
        private float _upgradesPoison;
        private float _upgradesIce;
        private float _upgradesWater;
        private float _upgradesElectric;
        private float _upgradesGhost;
        private float _upgradesRainbow;

        // final stats

        private int _finalHp;
        private float _finalFire;
        private float _finalPoison;
        private float _finalIce;
        private float _finalWater;
        private float _finalElectric;
        private float _finalGhost;
        private float _finalRainbow;




        public int Level => _level;
        public int FinalHp => _finalHp;
        public float FinalFire => _finalFire;
        public float FinalPoison => _finalPoison;
        public float FinalIce => _finalIce;
        public float FinalWater => _finalWater;
        public float FinalElectric => _finalElectric;
        public float FinalGhost => _finalGhost;
        public float FinalRainbow => _finalRainbow;


        public void ConfigurePlayer(int baseHp, int level, float baseFire, float basePoison,
                              float baseIce, float baseWater, float baseElectric,
                              float baseGhost, float baseRainbow)
        {
            _level = level;
            _baseHp = baseHp;
            _baseFire = baseFire;
            _basePoison = basePoison;
            _baseIce = baseIce;
            _baseWater = baseWater;
            _baseElectric = baseElectric;
            _baseGhost = baseGhost;
            _baseRainbow = baseRainbow;

            SetPlayerValues();
        }



        public void ConfigureTrail(int trailHp, float trailFire, float trailPoison,
                              float trailIce, float trailWater, float trailElectric,
                              float trailGhost, float trailRainbow)
        {
            _trailHp = trailHp;
            _trailFire = trailFire;
            _trailPoison = trailPoison;
            _trailIce = trailIce;
            _trailWater = trailWater;
            _trailElectric = trailElectric;
            _trailGhost = trailGhost;
            _trailRainbow = trailRainbow;
        }


        public void ConfigureUpgrades(float upgradesHp, float upgradesFire, float upgradesPoison,
                              float upgradesIce, float upgradesWater, float upgradesElectric,
                              float upgradesGhost, float upgradesRainbow)
        {
            _upgradesHp = upgradesHp;
            _upgradesFire = upgradesFire;
            _upgradesPoison = upgradesPoison;
            _upgradesIce = upgradesIce;
            _upgradesWater = upgradesWater;
            _upgradesElectric = upgradesElectric;
            _upgradesGhost = upgradesGhost;
            _upgradesRainbow = upgradesRainbow;
        }

        public void SetUpgradeValues()
        {
            var upgradeSystem = ServiceLocator.Instance.GetService<UpgradesSystem>();
            _upgradesHp = upgradeSystem.GetUpgradeHp();
            _upgradesFire = upgradeSystem.GetUpgradeFire();
            _upgradesPoison = upgradeSystem.GetUpgradePoison();
            _upgradesIce = upgradeSystem.GetUpgradeIce();
            _upgradesWater = upgradeSystem.GetUpgradeWater();
            _upgradesElectric = upgradeSystem.GetUpgradeElectric();
            _upgradesGhost = upgradeSystem.GetUpgradeGhost();
            _upgradesRainbow = upgradeSystem.GetUpgradeRainbow();
        }


        public void LevelUp(int level)
        {
            _level = level;
            SetFinalValues();
        }



        private void SetPlayerValues()
        {
            _playerHp = Mathf.FloorToInt(((_baseHp * (_level / 2f) * (_level / 2f)) / 10f) + 100f);
            _playerFire = _baseFire + (_level / 5f);
            _playerPoison = _basePoison + (_level / 5f);
            _playerIce = _baseIce + (_level / 5f);
            _playerWater = _baseWater + (_level / 5f);
            _playerElectric = _baseElectric + (_level / 5f);
            _playerGhost = _baseGhost + (_level / 5f);
            _playerRainbow = _baseRainbow + (_level / 5f);
        }


        public void SetFinalValues()
        {
            SetPlayerValues();
            SetUpgradeValues();

            _finalHp = (int)(_playerHp + _trailHp + _upgradesHp);
            _finalFire = _playerFire + _trailFire + _upgradesFire;
            _finalPoison = _playerPoison + _trailPoison + _upgradesPoison;
            _finalIce = _playerIce + _trailIce + _upgradesIce;
            _finalWater = _playerWater + _trailWater + _upgradesWater;
            _finalElectric = _playerElectric + _trailElectric + _upgradesElectric;
            _finalGhost = _playerGhost + _trailGhost + _upgradesGhost;
            _finalRainbow = _playerRainbow + _trailRainbow + _upgradesRainbow;

            var playerSendEveryStatsEventData = new playerSendEveryStatsEventData(_playerHp, _playerFire,
                                    _playerPoison, _playerIce, _playerWater,
                                    _playerElectric, _playerGhost, _playerRainbow,

                                    _trailHp, _trailFire, _trailPoison, _trailIce,
                                    _trailWater, _trailElectric, _trailGhost,
                                    _trailRainbow,

                                    _upgradesHp, _upgradesFire, _upgradesPoison,
                                    _upgradesIce, _upgradesWater, _upgradesElectric,
                                    _upgradesGhost, _upgradesRainbow,
                                    GetInstanceID());

            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(playerSendEveryStatsEventData);


            var playerSendFinalStatsEventData = new PlayerSendFinalStatsEventData(_finalHp, _finalFire,
                                                _finalPoison, _finalIce, _finalWater,
                                                _finalElectric, _finalGhost, _finalRainbow,
                                                GetInstanceID());

            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(playerSendFinalStatsEventData);

            var playerMaxHealthChangedEventData = new PlayerMaxHealthChangedEventData(_finalHp, GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(playerMaxHealthChangedEventData);
        }
    }
}