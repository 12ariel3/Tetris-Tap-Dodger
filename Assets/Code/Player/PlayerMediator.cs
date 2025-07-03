using Assets.Code.Common.Events;
using Assets.Code.Common.Settings;
using Assets.Code.Common.SwordsData;
using Assets.Code.Core;
using CandyCoded.HapticFeedback;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code.Player
{
    public class PlayerMediator : MonoBehaviour, EventObserver
    {

        [SerializeField] private PlayerStatsController _playerStatsController;
        [SerializeField] private PlayerHealthController _healthController;
        [SerializeField] private PlayerMovementController _playerMovementController;
        [SerializeField] private PlayerSpriteAndColliderController _playerSpriteAndColliderController;

        [SerializeField] private PlayerId _playerId;
        public string Id => _playerId.Value;


        private bool _isVibrationEnabled;
        private bool _gameOver;
        private bool _pause;
        private bool _victory;
        private string _currentSceneName;
        private float _debuffProbability;
        private string _debuffName;
        private string _debuffName2;
        private string _debuffName3;

        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.GameOver, this);
            eventQueue.Subscribe(EventIds.Victory, this);
            eventQueue.Subscribe(EventIds.LevelUp, this);
            eventQueue.Subscribe(EventIds.ProjectileSpawned, this);
            eventQueue.Subscribe(EventIds.ProjectileDestroyed, this);
            eventQueue.Subscribe(EventIds.HpPopUpValue, this);
            eventQueue.Subscribe(EventIds.SwordEquippedLevelUp, this);
            eventQueue.Subscribe(EventIds.ContinueBattleAfterAds, this);
            eventQueue.Subscribe(EventIds.IsVibrationSettingsChanged, this);
            eventQueue.Subscribe(EventIds.UpgradeNodeActived, this);
            eventQueue.Subscribe(EventIds.GoodSpecialProjectileDestroyed, this);
            eventQueue.Subscribe(EventIds.PausePressed, this);
            eventQueue.Subscribe(EventIds.LevelDebuffProbability, this);
            eventQueue.Subscribe(EventIds.LimitPositionEventData, this);
            eventQueue.Subscribe(EventIds.ProjectileAndBackgroundSpeed, this);
            _isVibrationEnabled = ServiceLocator.Instance.GetService<SettingsSystem>().IsVibrationActived();
            _gameOver = false;
            _pause = false;
            _victory = false;
            _currentSceneName = SceneManager.GetActiveScene().name;
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.GameOver, this);
            eventQueue.Unsubscribe(EventIds.Victory, this);
            eventQueue.Unsubscribe(EventIds.LevelUp, this);
            eventQueue.Unsubscribe(EventIds.ProjectileSpawned, this);
            eventQueue.Unsubscribe(EventIds.ProjectileDestroyed, this);
            eventQueue.Unsubscribe(EventIds.HpPopUpValue, this);
            eventQueue.Unsubscribe(EventIds.SwordEquippedLevelUp, this);
            eventQueue.Unsubscribe(EventIds.ContinueBattleAfterAds, this);
            eventQueue.Unsubscribe(EventIds.IsVibrationSettingsChanged, this);
            eventQueue.Unsubscribe(EventIds.UpgradeNodeActived, this);
            eventQueue.Unsubscribe(EventIds.GoodSpecialProjectileDestroyed, this);
            eventQueue.Unsubscribe(EventIds.PausePressed, this);
            eventQueue.Unsubscribe(EventIds.LevelDebuffProbability, this);
            eventQueue.Unsubscribe(EventIds.LimitPositionEventData, this);
            eventQueue.Unsubscribe(EventIds.ProjectileAndBackgroundSpeed, this);
        }


        public void Configure(PlayerConfiguration configuration)
        {
            _playerStatsController.ConfigurePlayer(configuration.BaseHp, configuration.Level,
                                             configuration.BaseFire, configuration.BasePoison,
                                             configuration.BaseIce, configuration.BaseWater,
                                             configuration.BaseElectric, configuration.BaseGhost,
                                             configuration.BaseRainbow);
            _playerStatsController.ConfigureTrail(configuration.TrailHp, configuration.TrailFire,
                                             configuration.TrailPoison, configuration.TrailIce,
                                             configuration.TrailWater, configuration.TrailElectric,
                                             configuration.TrailGhost, configuration.TrailRainbow);
            _playerStatsController.ConfigureUpgrades(configuration.UpgradesHp, configuration.UpgradesFire,
                                             configuration.UpgradesPoison, configuration.UpgradesIce,
                                             configuration.UpgradesWater, configuration.UpgradesElectric,
                                             configuration.UpgradesGhost, configuration.UpgradesRainbow);
            _playerSpriteAndColliderController.Configuration(configuration.UnevolvedSprite, configuration.EvolvedSprite,
                                                             configuration.TrailLevel);
               _playerStatsController.SetFinalValues();
            _healthController.Configure(this, _playerStatsController.FinalHp);
            var playerSpamedAndSendHisTransformEventData = new PlayerSpamedAndSendHisTransformEventData(this.transform, GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(playerSpamedAndSendHisTransformEventData);
        }
        


        private void Update()
        {
            if (!_gameOver && !_victory && !_pause && _currentSceneName == "Game")
            {
                _playerMovementController.GetIfTheScreenIsTouched();
            }
        }

        private void FixedUpdate()
        {
            if (!_gameOver && !_victory && !_pause && _currentSceneName == "Game")
            {
                _playerMovementController.PlayerMovement2();
            }
            else
            {
                _playerMovementController.PlayerStopMovement();
            }
        }


        public void OnDamageReceived(bool isDeath)
        {
            if (_isVibrationEnabled)
            {
                HapticFeedback.HeavyFeedback();
            }

            ProcessIfDebuffIsActivated();

            if (isDeath)
            {
                var playerDestroyedEventData = new PlayerDestroyedEventData(GetInstanceID());
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(playerDestroyedEventData);
                _gameOver = true;
            }

        }

        private void ProcessIfDebuffIsActivated()
        {
            string projectileName = GetStoredProjectileName();

            float debuffResitence = FilterProjectileDestroyedDebuffResistences(projectileName);

            float randomNumber = Random.Range(0, 100);
            if (randomNumber < (_debuffProbability - debuffResitence))
            {
                FilterAndStartDebuffActivation(projectileName);
                var debuffActivatedEventData = new DebuffActivatedEventData(projectileName, GetInstanceID());
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(debuffActivatedEventData);
            }
        }

        private void FilterAndStartDebuffActivation(string name)
        {
            switch (name)
            {
                case "Fire":
                    _healthController.FilterAndStartCoroutine("Fire");
                    return;

                case "Poison":
                    _healthController.FilterAndStartCoroutine("Poison");
                    return;

                case "Ice":
                    _playerMovementController.FilterAndStartCoroutine("Ice");
                    return;

                case "Electric":
                    _healthController.FilterAndStartCoroutine("Electric");
                    return;

                case "Rainbow":
                    _playerMovementController.FilterAndStartCoroutine("Rainbow");
                    return;
            }
        }



        private float FilterProjectileDestroyedDebuffResistences(string name)
        {
            switch (name)
            {
                case "Normal":
                    return 1000f;

                case "Fire":
                    return _playerStatsController.FinalFire;

                case "Poison":
                    return _playerStatsController.FinalPoison;

                case "Ice":
                    return _playerStatsController.FinalIce;

                case "Water":
                    return _playerStatsController.FinalWater;

                case "Electric":
                    return _playerStatsController.FinalElectric;

                case "Ghost":
                    return _playerStatsController.FinalGhost;

                case "Rainbow":
                    return _playerStatsController.FinalRainbow;
            }
            return 1000f;
        }

        private void StoreProjectileName(string projectileName)
        {
            if (_debuffName == null)
            {
                _debuffName = projectileName;
                return;
            }
            else if (_debuffName2 == null)
            {
                _debuffName2 = projectileName;
                return;
            }
            else if (_debuffName3 == null)
            {
                _debuffName3 = projectileName;
                return;
            }
        }
        
        private string GetStoredProjectileName()
        {
            if (_debuffName != null)
            {
                string momentaryName1 = _debuffName;
                _debuffName = null;
                return momentaryName1;
            }
            else if (_debuffName2 != null)
            {
                string momentaryName2 = _debuffName2;
                _debuffName2 = null;
                return momentaryName2;
            }
            else if (_debuffName3 != null)
            {
                string momentaryName3 = _debuffName3;
                _debuffName3 = null;
                return momentaryName3;
            }
            return null;
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.LevelUp)
            {
                var levelUpEventData = (LevelUpEventData)eventData;
                _playerStatsController.LevelUp(levelUpEventData.Level);
                _healthController.SetLevelUpNewHealthValues(_playerStatsController.FinalHp);
            }

            if (eventData.EventId == EventIds.ProjectileSpawned)
            {
                var playerSendFinalStatsEventData = new PlayerSendFinalStatsEventData(_playerStatsController.FinalHp,
                                                _playerStatsController.FinalFire, _playerStatsController.FinalPoison,
                                                _playerStatsController.FinalIce, _playerStatsController.FinalWater,
                                                _playerStatsController.FinalElectric, _playerStatsController.FinalGhost,
                                                _playerStatsController.FinalRainbow, GetInstanceID());
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(playerSendFinalStatsEventData);
            }

            if (eventData.EventId == EventIds.ProjectileDestroyed)
            {
                var projectileDestroyedEventData = (ProjectileDestroyedEventData)eventData;
                if (projectileDestroyedEventData.AttackToRest > 0)
                {
                    StoreProjectileName(projectileDestroyedEventData.ProjectileColorAndTypeString);
                    _healthController.AddDamage(projectileDestroyedEventData.AttackToRest);
                }
            }


            if (eventData.EventId == EventIds.GoodSpecialProjectileDestroyed)
            {
                _healthController.AddGoodSpecialProjectileHealing();
            }

            if (eventData.EventId == EventIds.HpPopUpValue)
            {
                var hpPopUpEventData = (HpPopUpEventData)eventData;
                _healthController.AddHealing(hpPopUpEventData.HpValue);
            }
            if (eventData.EventId == EventIds.SwordEquippedLevelUp)
            {
                var swordEquippedLevelUpEventData = (SwordEquippedLevelUpEventData)eventData;
                if (ServiceLocator.Instance.GetService<SwordEquippedSystem>().GetSwordEquipped() == swordEquippedLevelUpEventData.Id)
                {
                    _playerStatsController.ConfigureTrail(swordEquippedLevelUpEventData.Hp, swordEquippedLevelUpEventData.Fire,
                                             swordEquippedLevelUpEventData.Poison, swordEquippedLevelUpEventData.Ice,
                                             swordEquippedLevelUpEventData.Water, swordEquippedLevelUpEventData.Electric,
                                             swordEquippedLevelUpEventData.Ghost, swordEquippedLevelUpEventData.Rainbow);

                    _playerStatsController.SetFinalValues();
                }
            }

            if (eventData.EventId == EventIds.ContinueBattleAfterAds)
            {
                _healthController.Configure(this, _playerStatsController.FinalHp);
                _gameOver = false;
            }

            if (eventData.EventId == EventIds.IsVibrationSettingsChanged)
            {
                _isVibrationEnabled = ServiceLocator.Instance.GetService<SettingsSystem>().IsVibrationActived();
            }

            if (eventData.EventId == EventIds.UpgradeNodeActived)
            {
                _playerStatsController.SetFinalValues();
            }


            if (eventData.EventId == EventIds.GameOver)
            {
                _gameOver = true;
                _healthController.StopAllDebuffCoroutines();
                _playerMovementController.StopAllDebuffCoroutines();
            }
            
            if (eventData.EventId == EventIds.Victory)
            {
                _victory = true;
                _healthController.StopAllDebuffCoroutines();
                _playerMovementController.StopAllDebuffCoroutines();
            }

            if (eventData.EventId == EventIds.PausePressed)
            {
                if (_pause == true)
                {
                    _pause = false;
                }
                else
                {
                    _pause = true;
                }
            }

            if (eventData.EventId == EventIds.LevelDebuffProbability)
            {
                var levelDebuffProbabilityEventData = (LevelDebuffProbabilityEventData)eventData;
                _debuffProbability = levelDebuffProbabilityEventData.DebuffProbability;
            }
            
            if (eventData.EventId == EventIds.LimitPositionEventData)
            {
                var levelDebuffProbabilityEventData = (LimitTransformsEventData)eventData;
                _playerMovementController.SetLimitPositions(levelDebuffProbabilityEventData.LeftLimitTransform,
                    levelDebuffProbabilityEventData.RightLimitTransform);
            }

            if (eventData.EventId == EventIds.ProjectileAndBackgroundSpeed)
            {
                var projectileAndBackgroundSpeed = (ProjectileAndMapBackgroundSpeedEventData)eventData;
                _playerMovementController.ConfigureMovement(projectileAndBackgroundSpeed.ProjectileAndBackgroundSpeed);
            }
        }
    }
}