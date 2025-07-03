using Assets.Code.Common.Command;
using Assets.Code.Common.EnergyData;
using Assets.Code.Common.Events;
using Assets.Code.Common.MapsAndLevelsData;
using Assets.Code.Core;
using Assets.Code.Enemies;
using Assets.Code.MusicAndSound;
using Google.Play.Review;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class PlayPanelView : MonoBehaviour, EventObserver
    {

        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _spinWheelButton;
        [SerializeField] private Button _storeButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _aboutUsButton;
        [SerializeField] private SpinWheelView _spinWheelView;
        [SerializeField] private StoreView _storeView;
        [SerializeField] private CongratulationsView _congratulationsView;
        [SerializeField] private SettingsView _settingsView;
        [SerializeField] private AboutUsView _aboutUsView;

        //map section

        [SerializeField] private MapsConfiguration _mapsConfiguration;
        [SerializeField] private SelectMapView _selectMapView;
        [SerializeField] private Image _mapBackground;
        [SerializeField] private TextMeshProUGUI _mapTitle;
        [SerializeField] private Button _currentMapButton;
        [SerializeField] private TextMeshProUGUI _currentLevelText;
        [SerializeField] private TextMeshProUGUI _currentLevelEnergyToRestText;
        [SerializeField] private Button _previousLevelButton;
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private ParticleSystem _mapParticleSystem;


        ReviewManager _reviewManager;
        PlayReviewInfo _reviewInfo;


        private MapConfiguration _mapConfiguration;
        private LevelConfiguration _currentLevelConfiguration;
        private int _maxLevelReached;
        private int _lastLevelPlayed;
        private string _maxMapReached;
        private string _lastMapPlayed;

        private int _currentLevel;
        private int _selectedLevelEnergyToRest;
        private int _currentTotalLevel;

        private void Awake()
        {
            _startGameButton.onClick.AddListener(OnStartButtonPressed);
            _spinWheelButton.onClick.AddListener(OnSpinWheelButtonPressed);
            _storeButton.onClick.AddListener(OnStoreButtonPressed);
            _settingsButton.onClick.AddListener(OnSettingsButtonPressed);
            _aboutUsButton.onClick.AddListener(OnAboutUsButtonPressed);
            _currentMapButton.onClick.AddListener(OnSelectMapButtonPressed);
            _previousLevelButton.onClick.AddListener(OnPreviousLevelButtonPressed);
            _nextLevelButton.onClick.AddListener(OnNextLevelButtonPressed);
        }

        private void Start()
        {
            StartCoroutine(LateStart());
        }
        IEnumerator LateStart()
        {
            yield return new WaitForEndOfFrame();
            var serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<EventQueue>().Subscribe(EventIds.LastMapPlayedChanged, this);
            if (serviceLocator.GetService<MapsAndLevelsSystem>().IsFirstUpdate() == true)
            {
                StartSetUpMapAndLevelVariables();
                serviceLocator.GetService<MapsAndLevelsSystem>().SaveIfIsFirstUpdate(false);
            }
            else
            {
                SetUpMapAndLevelVariables();
            }
    
            SetPlayPanelViewComponents();

            CheckForInnAppReview();

            HideAllMenus();

            CheckForCongratulationsView();

            //_settingsView.GetAndSetInitialLocaleSelector();
        }
        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.LastMapPlayedChanged, this);
        }

        private void CheckForInnAppReview()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                _reviewManager = new ReviewManager();
                if (!ServiceLocator.Instance.GetService<MapsAndLevelsSystem>().IsGameReviewed() &&
                    ServiceLocator.Instance.GetService<MapsAndLevelsSystem>().IsMoonWalkerPassed())
                {
                    StartCoroutine(ReviewOperation());
                }
            }
        }

        private void CheckForCongratulationsView()
        {
            if (ServiceLocator.Instance.GetService<MapsAndLevelsSystem>().IsAcheronPassed() &&
                !ServiceLocator.Instance.GetService<MapsAndLevelsSystem>().IsCongratulationsViewed())
            {
                _congratulationsView.Show();
                ServiceLocator.Instance.GetService<MapsAndLevelsSystem>().SaveIfIsCongratulationsViewed(true);
            }
        }


        IEnumerator ReviewOperation()
        {
            yield return new WaitForSeconds(1f);

            var requestFlowOperation = _reviewManager.RequestReviewFlow();
            yield return requestFlowOperation;
            if (requestFlowOperation.Error != ReviewErrorCode.NoError)
            {
                Debug.LogError(requestFlowOperation.Error.ToString());
                yield break;
            }

            _reviewInfo = requestFlowOperation.GetResult();
            var launchFlowOperation = _reviewManager.LaunchReviewFlow(_reviewInfo);
            yield return launchFlowOperation;
            _reviewInfo = null;

            if (launchFlowOperation.Error != ReviewErrorCode.NoError)
            {
                Debug.LogError(launchFlowOperation.Error.ToString());
                yield break;
            }

            ServiceLocator.Instance.GetService<MapsAndLevelsSystem>().SaveIfIsGameReviewed(true);
        }


        private void SetPlayPanelViewComponents()
        {
            _mapBackground.sprite = _mapConfiguration.MapBackground;
            _mapTitle.font = _mapConfiguration.TitleAndLevelFont;
            _mapTitle.SetText(_mapConfiguration.MapName.Value);
            _currentLevelText.font = _mapConfiguration.TitleAndLevelFont;
            _currentLevelText.SetText(_currentLevel.ToString() + "/" + _mapConfiguration.Levels.Length.ToString());
            var PSMain = _mapParticleSystem.main;
            PSMain.startColor = _mapConfiguration.ParticleSystemColor;
        }

        private void StartSetUpMapAndLevelVariables()
        {
            var mapsAndLevelsSystem = ServiceLocator.Instance.GetService<MapsAndLevelsSystem>();
            _maxLevelReached = mapsAndLevelsSystem.GetMaxLevelReached();
            _lastLevelPlayed = _maxLevelReached;
            mapsAndLevelsSystem.SaveLastLevelPlayed(_lastLevelPlayed);
            _maxMapReached = mapsAndLevelsSystem.GetMaxMapReached();
            _lastMapPlayed = _maxMapReached;
            mapsAndLevelsSystem.SaveLastMapPlayed(_lastMapPlayed);
            _mapConfiguration = _mapsConfiguration.GetMapById(_lastMapPlayed);
            _currentLevelConfiguration = _mapConfiguration.GetCurrentLevelConfiguration(_lastLevelPlayed);
            _currentLevelEnergyToRestText.SetText("-" + _currentLevelConfiguration.EnergyToRest.ToString());
            _selectedLevelEnergyToRest = _currentLevelConfiguration.EnergyToRest;
            _currentLevel = _currentLevelConfiguration.LevelNumber;
            _currentTotalLevel = _currentLevelConfiguration.TotalLevelNumber;
        }

        private void SetUpMapAndLevelVariables()
        {
            var mapsAndLevelsSystem = ServiceLocator.Instance.GetService<MapsAndLevelsSystem>();
            int newMaxLevelReached = mapsAndLevelsSystem.GetMaxLevelReached();

            if (_maxLevelReached < newMaxLevelReached)
            {
                _maxLevelReached = newMaxLevelReached;
                _lastLevelPlayed = _maxLevelReached;
            }
            else
            {
                _lastLevelPlayed = mapsAndLevelsSystem.GetLastLevelPlayed();
            }

            _maxMapReached = mapsAndLevelsSystem.GetMaxMapReached();
            _lastMapPlayed = mapsAndLevelsSystem.GetLastMapPlayed();
            _mapConfiguration = _mapsConfiguration.GetMapById(_lastMapPlayed);
            _currentLevelConfiguration = _mapConfiguration.GetCurrentLevelConfiguration(_lastLevelPlayed);
            _currentLevelEnergyToRestText.SetText("-" + _currentLevelConfiguration.EnergyToRest.ToString());
            _selectedLevelEnergyToRest = _currentLevelConfiguration.EnergyToRest;
            _currentLevel = _currentLevelConfiguration.LevelNumber;
            _currentTotalLevel = _currentLevelConfiguration.TotalLevelNumber;
        }


        private void SetUpChangedMapAndLevelVariables()
        {
            var mapsAndLevelsSystem = ServiceLocator.Instance.GetService<MapsAndLevelsSystem>();
            _maxLevelReached = mapsAndLevelsSystem.GetMaxLevelReached();
            _lastLevelPlayed = mapsAndLevelsSystem.GetLastLevelPlayed();
            _maxMapReached = mapsAndLevelsSystem.GetMaxMapReached();
            _lastMapPlayed = mapsAndLevelsSystem.GetLastMapPlayed();
            _mapConfiguration = _mapsConfiguration.GetMapById(_lastMapPlayed);
            _currentLevelConfiguration = _mapConfiguration.GetFirstLevelConfiguration();
            _currentLevelEnergyToRestText.SetText("-" + _currentLevelConfiguration.EnergyToRest.ToString());
            _selectedLevelEnergyToRest = _currentLevelConfiguration.EnergyToRest;
            _currentLevel = _currentLevelConfiguration.LevelNumber;
            _currentTotalLevel = _currentLevelConfiguration.TotalLevelNumber;
        }



        private void HideAllMenus()
        {
            _settingsView.HideFirst();
            _spinWheelView.HideFirst();
            _storeView.HideFirst();
            _selectMapView.HideFirst();
            _congratulationsView.HideFirst();
            _aboutUsView.HideFirst();
        }

        private void OnSettingsButtonPressed()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Bloop");
            _settingsView.Show();
        }

        private void OnAboutUsButtonPressed()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Bloop");
            _aboutUsView.Show();
        }

        private void OnSpinWheelButtonPressed()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Bloop");
            _spinWheelView.Show();
        }

        private void OnStoreButtonPressed()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Bloop");
            _storeView.Show();
        }

        private void OnSelectMapButtonPressed()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Bloop");
            _selectMapView.Show();
        }

        private void OnStartButtonPressed()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("NotEnough");
                var NotEnoughEventData = new NotEnoughEventData("NotConnection", GetInstanceID());
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(NotEnoughEventData);
            }
            else
            {
                ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Button");
                var energySystem = ServiceLocator.Instance.GetService<EnergySystem>();
                var currentEnergy = energySystem.GetActualEnergy();
                if (currentEnergy >= _selectedLevelEnergyToRest)
                {
                    currentEnergy -= _selectedLevelEnergyToRest;
                    energySystem.SaveActualEnergy(currentEnergy);
                    energySystem.SetEnergyValues();
                    SetAllParametersBeforeStartLevel();

                    ServiceLocator.Instance.GetService<AudioManager>().StopMainMenuMusic();
                    var loadGameSceneCommand = new LoadGameSceneCommand();
                    ServiceLocator.Instance.GetService<CommandQueue>()
                      .AddCommand(loadGameSceneCommand);
                }
                else
                {
                    ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("NotEnough");
                    var NotEnoughEventData = new NotEnoughEventData("Energy", GetInstanceID());
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(NotEnoughEventData);
                }
            }
        }

        private void SetAllParametersBeforeStartLevel()
        {
            var mapsAndLevelsSystem = ServiceLocator.Instance.GetService<MapsAndLevelsSystem>();
            _lastLevelPlayed = _currentTotalLevel;
            mapsAndLevelsSystem.SaveLastLevelPlayed(_lastLevelPlayed);

            if (_currentTotalLevel == _maxLevelReached)
            {
                mapsAndLevelsSystem.SaveIfIsNewLevelPlayed(true);
            }
            else
            {
                mapsAndLevelsSystem.SaveIfIsNewLevelPlayed(false);
            }

            if (_currentLevel >= _mapConfiguration.Levels.Length)
            {
                mapsAndLevelsSystem.SaveIfIsLastMapLevelPlayed(true);
            }
            else
            {
                mapsAndLevelsSystem.SaveIfIsLastMapLevelPlayed(false);
            }
        }

        private void OnPreviousLevelButtonPressed()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Button");
            if (_currentLevel > 1)
            {
                _currentLevel--;
                _currentTotalLevel--;
                _currentLevelText.SetText(_currentLevel.ToString() + "/" + _mapConfiguration.Levels.Length.ToString());
                _currentLevelConfiguration = _mapConfiguration.GetCurrentLevelConfiguration(_currentTotalLevel);
                _currentLevelEnergyToRestText.SetText("-" + _currentLevelConfiguration.EnergyToRest.ToString());
                _selectedLevelEnergyToRest = _currentLevelConfiguration.EnergyToRest;
            }
        }

        private void OnNextLevelButtonPressed()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Button");
            if (_currentLevel < _mapConfiguration.Levels.Length && _currentTotalLevel < _maxLevelReached)
            {
                _currentLevel++;
                _currentTotalLevel++;
                _currentLevelText.SetText(_currentLevel.ToString() + "/" + _mapConfiguration.Levels.Length.ToString());
                _currentLevelConfiguration = _mapConfiguration.GetCurrentLevelConfiguration(_currentTotalLevel);
                _currentLevelEnergyToRestText.SetText("-" + _currentLevelConfiguration.EnergyToRest.ToString());
                _selectedLevelEnergyToRest = _currentLevelConfiguration.EnergyToRest;
            }
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.LastMapPlayedChanged)
            {
                SetUpChangedMapAndLevelVariables();
                SetPlayPanelViewComponents();
                HideAllMenus();
                ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("ReverseBloop");
            }
        }
    }
}