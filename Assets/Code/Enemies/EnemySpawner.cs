using Assets.Code.Common.Events;
using Assets.Code.Common.MapsAndLevelsData;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using Assets.Code.Projectiles.Common;
using UnityEngine;

namespace Assets.Code.Enemies
{
    public class EnemySpawner : MonoBehaviour, EventObserver
    {
        [SerializeField] private Transform _centerDirectionPosition;
        

        [SerializeField] private MapsConfiguration _mapsConfiguration;
        private ProjectileFactory _projectileFactory;

        private LevelConfiguration _levelConfiguration;
        private int _currentConfigurationIndex;
        private bool _canSpawn;
        private string _lastMapPlayed;

        private Camera _cam;
        private float _camHeight;
        private float _camWidth;
        private bool _alreadySent;
        private bool _allprojectilesSpamed;

        private int _totalDurationLevel;
        private float _currentDurationLevel;
        private float _minCooldownSpawn;
        private float _maxCooldownSpawn;
        private float _lastCooldownSpawn;

        private void Start()
        {
            _projectileFactory = ServiceLocator.Instance.GetService<ProjectileFactory>();
            GetCurrentLevelCofiguration();
            ServiceLocator.Instance.GetService<AudioManager>().PlayGameMusic(_lastMapPlayed);

            _cam = Camera.main;
            _camHeight = _cam.orthographicSize;
            _camWidth = _cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

            _totalDurationLevel = _levelConfiguration.TotalDurationLevel;
            _minCooldownSpawn = _levelConfiguration.MinCooldownTime;
            _maxCooldownSpawn = _levelConfiguration.MaxCooldownTime;

            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            var projectileAndMapBackgroundSpeedEventData = new ProjectileAndMapBackgroundSpeedEventData(
                                                           _levelConfiguration.ProjectileSpeed, GetInstanceID());
            eventQueue.EnqueueEvent(projectileAndMapBackgroundSpeedEventData);
            eventQueue.Subscribe(EventIds.PlayerSpamedAndSendHisTransform, this);
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.PlayerSpamedAndSendHisTransform, this);
        }

        private void GetCurrentLevelCofiguration()
        {
            var serviceLocator = ServiceLocator.Instance;
            int currentLevel = serviceLocator.GetService<MapsAndLevelsSystem>().GetLastLevelPlayed();
            _lastMapPlayed = serviceLocator.GetService<MapsAndLevelsSystem>().GetLastMapPlayed();
            MapConfiguration mapConfiguration = _mapsConfiguration.GetMapById(_lastMapPlayed);
            _levelConfiguration = mapConfiguration.GetCurrentLevelConfiguration(currentLevel);
        }

        public void StartSpawn()
        {
            _canSpawn = true;
        }

        public void RestartSpawn()
        {
            _canSpawn = true;
            if ((_lastCooldownSpawn + _minCooldownSpawn) >= _totalDurationLevel)
            {
                ServiceLocator.Instance.GetService<EventQueue>()
                              .EnqueueEvent(new EventData(EventIds.AllProjectilesSpawned));
            }
        }


        public void Stop()
        {
            _canSpawn = false;
        }


        
        private void Update()
        {
            if (!_canSpawn)
            {
                return;
            }

            if (_currentDurationLevel >= _totalDurationLevel)
            {
                if (!_allprojectilesSpamed)
                {
                    _allprojectilesSpamed = true;
                    ServiceLocator.Instance.GetService<EventQueue>()
                              .EnqueueEvent(new EventData(EventIds.AllProjectilesSpawned));
                }
                return;
            }

            _currentDurationLevel += Time.deltaTime;

            if(_lastCooldownSpawn <= _currentDurationLevel)
            {
                float nextSpawn = Random.Range(_minCooldownSpawn, _maxCooldownSpawn);
                _lastCooldownSpawn += nextSpawn;
                SpawnShips();

                if ((_lastCooldownSpawn + _minCooldownSpawn) >= _totalDurationLevel)
                {
                    _allprojectilesSpamed = true;
                    ServiceLocator.Instance.GetService<EventQueue>()
                              .EnqueueEvent(new EventData(EventIds.AllProjectilesSpawned));
                }
            }
        }


        private Vector3 FilterSpawnPosition()
        {
            float rndPosY;
            float rndPosX;
            float safeCamWidth = _camWidth * 0.85f;
            rndPosY = _camHeight + 2f;
            rndPosX = Random.Range(-safeCamWidth, safeCamWidth);
            Vector3 spawnPosition = new Vector3(_cam.transform.position.x + rndPosX, _cam.transform.position.y + rndPosY);
            return spawnPosition;
        }

        private Quaternion FilterSpawnRotation()
        {
            Quaternion spawnRotation;
            int randomNumber = Random.Range(0, 100);

            if (randomNumber < 25)
            {
                spawnRotation = new Quaternion(0, 0, 0, 0);
                spawnRotation.eulerAngles = new Vector3(0, 0, 0);
                return spawnRotation;
            }
            else if (randomNumber >= 25 && randomNumber < 50)
            {
                spawnRotation = new Quaternion(0, 0, 0, 0);
                spawnRotation.eulerAngles = new Vector3(0, 0, 90);
                return spawnRotation;
            }
            else if (randomNumber >= 50 && randomNumber < 75)
            {
                spawnRotation = new Quaternion(0, 0, 0, 0);
                spawnRotation.eulerAngles = new Vector3(0, 0, 180);
                return spawnRotation;
            }
            else if (randomNumber >= 75)
            {
                spawnRotation = new Quaternion(0, 0, 0, 0);
                spawnRotation.eulerAngles = new Vector3(0, 0, 270);
                return spawnRotation;
            }
            spawnRotation = new Quaternion(0, 0, 0, 0);
            spawnRotation.eulerAngles = new Vector3(0, 0, 0);
            return spawnRotation;
        }

        private int FilterColorAndType(string currentLevelType)
        {
            switch (currentLevelType)
            {
                case "Normal":
                    return 0;

                case "Fire":
                    return 1;

                case "Moon Walker":
                    return 2;

                case "Poison":
                    return 3;

                case "PreAtlans Abyss":
                    return 4;

                case "Ice":
                    return 5;

                case "Atlans Abyss":
                    return 6;

                case "Water":
                    return 7;

                case "PreVilla Soldati":
                    return 8;

                case "Electric":
                    return 9;

                case "Villa Soldati":
                    return 10;

                case "Ghost":
                    return 11;

                case "PreRaklion":
                    return 12;

                case "Rainbow":
                    return 13;

                case "Raklion":
                    return 14;

                case "Acheron":
                    return 15;
            }
            return 0;
        }

        
        private void SpawnShips()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Spawn");
            
            float randomNumber = Random.Range(0f, 100f);
            ProjectileToSpawnConfiguration shipConfiguration;

            if (randomNumber < _levelConfiguration.SpecialProjectileCastPercentaje)
            {
                shipConfiguration = _levelConfiguration.GetRandomSpecialProgectileToSpawnConfiguration();
            }
            else
            {
                shipConfiguration = _levelConfiguration.GetRandomProgectileToSpawnConfiguration();
            }

            var shipBuilder = _projectileFactory.Create(shipConfiguration.ProjectileId.Value);

            int projectileColorAndType = FilterColorAndType(_levelConfiguration.CurrentLevelType);
            Vector3 spawnPosition = FilterSpawnPosition();
            Quaternion spawnRotation = FilterSpawnRotation();
            shipBuilder
                      .WithPosition(spawnPosition)
                      .WithRotation(spawnRotation)
                      .WithDirectionPositions(_centerDirectionPosition)
                      .WithProjectileLevel(_levelConfiguration.ProjectileLevel)
                      .WithConfiguration(shipConfiguration)
                      .WithCheckBottomDestroyLimits()
                      .WithColorAndType(projectileColorAndType)
                      .WithSpeed(_levelConfiguration.ProjectileSpeed)
                      .Build();
            ServiceLocator.Instance.GetService<EventQueue>()
                .EnqueueEvent(new EventData(EventIds.ProjectileSpawned));
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.PlayerSpamedAndSendHisTransform)
            {
                if (_alreadySent == false)
                {
                    var levelDebuffProbabilityEventData = new LevelDebuffProbabilityEventData(_levelConfiguration.DebuffProbability,
                                                                                              GetInstanceID());
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(levelDebuffProbabilityEventData);
                    _alreadySent = true;
                }
                var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
                var projectileAndMapBackgroundSpeedEventData = new ProjectileAndMapBackgroundSpeedEventData(
                                                               _levelConfiguration.ProjectileSpeed, GetInstanceID());
                eventQueue.EnqueueEvent(projectileAndMapBackgroundSpeedEventData);
            }
        }
    }
}