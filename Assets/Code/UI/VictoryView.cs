using Assets.Code.Common.AdsData;
using Assets.Code.Common.Events;
using Assets.Code.Common.GemsData;
using Assets.Code.Common.MapsAndLevelsData;
using Assets.Code.Common.Score;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using Assets.Code.ZOthers;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class VictoryView : MonoBehaviour, EventObserver
    {

        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _gemsText;
        [SerializeField] private Button _backToMenuButton;
        [SerializeField] private RectTransform _needleTransform;
        [SerializeField] private Image _firstPiece;
        [SerializeField] private Image _secondPiece;
        [SerializeField] private Image _thirdPiece;
        [SerializeField] private Image _fourthPiece;


        private Vector3 _angles;
        private float _minNeedleAngle = 275f;
        private float _maxNeedleAngle = 85f;
        private bool _isGoingRight;
        private int _currentScore;
        private int _currentGems;

        private int _finalCurrentScore;
        private int _finalCurrentGems;

        private bool _isInFirstPiece;
        private bool _isInSecondPiece;
        private bool _isInThirdPiece;
        private bool _isInFourthPiece;
        private bool _stopped;

        private InGameMenuMediator _mediator;

        private void Awake()
        {
            _backToMenuButton.onClick.AddListener(OnBackToMenuPressed);
        }

        private void Start()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.AdWatched, this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.AdWatched, this);
        }

        public void Configure(InGameMenuMediator mediator)
        {
            _mediator = mediator;
        }

        void Update()
        {
            if (!_stopped)
            {
                MoveNeedle();
                SelectCurrentlyNumberOnNeedle();
            }
        }


        private void MoveNeedle()
        {
            if (_needleTransform.localEulerAngles.z >= _minNeedleAngle)
            {
                _isGoingRight = true;
            }
            if (_needleTransform.localEulerAngles.z <= _maxNeedleAngle)
            {
                _isGoingRight = false;
            }
            if (!_isGoingRight)
            {
                _angles = _needleTransform.localEulerAngles;
                _angles.z = _angles.z + 250 * Time.deltaTime;
                _needleTransform.localEulerAngles = _angles;
            }
            else
            {
                _angles = _needleTransform.localEulerAngles;
                _angles.z = _angles.z - 250 * Time.deltaTime;
                _needleTransform.localEulerAngles = _angles;
            }
        }


        private void SelectCurrentlyNumberOnNeedle()
        {
            if (_needleTransform.localEulerAngles.z <= _minNeedleAngle
                && _needleTransform.localEulerAngles.z >= 236.6f
                && !_isInFirstPiece)
            {
                SelectCurrentPieceActive(_firstPiece);
                SetAllPieceBoolsFalse();
                _isInFirstPiece = true;
                SetNewPartialScore(0.9);
            }

            if (_needleTransform.localEulerAngles.z <= 236.5f
                && _needleTransform.localEulerAngles.z >= 162.1f
                && !_isInSecondPiece)
            {
                SelectCurrentPieceActive(_secondPiece);
                SetAllPieceBoolsFalse();
                _isInSecondPiece = true;
                SetNewPartialScore(1);
            }

            if (_needleTransform.localEulerAngles.z <= 162f
                && _needleTransform.localEulerAngles.z >= 121.1f
                && !_isInThirdPiece)
            {
                SelectCurrentPieceActive(_thirdPiece);
                SetAllPieceBoolsFalse();
                _isInThirdPiece = true;
                SetNewPartialScore(1.2);
                var victorySpinWheelX3IsActivedEventData = new VictorySpinWheelX3MultiplierEventData(false, GetInstanceID());
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(victorySpinWheelX3IsActivedEventData);
            }

            if (_needleTransform.localEulerAngles.z <= 121f
                && _needleTransform.localEulerAngles.z >= _maxNeedleAngle
                && !_isInFourthPiece)
            {
                SelectCurrentPieceActive(_fourthPiece);
                SetAllPieceBoolsFalse();
                _isInFourthPiece = true;
                SetNewPartialScore(3);
                var victorySpinWheelX3IsActivedEventData = new VictorySpinWheelX3MultiplierEventData(true, GetInstanceID());
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(victorySpinWheelX3IsActivedEventData);
            }
        }

        private void SetNewPartialScore(double multiplier)
        {
            _finalCurrentScore = (int)(_currentScore * multiplier);
            _finalCurrentGems = (int)(_currentGems * multiplier);
            _scoreText.SetText(_finalCurrentScore.ToString());
            _gemsText.SetText(_finalCurrentGems.ToString());
        }

        private void SetAllPieceBoolsFalse()
        {
            _isInFirstPiece = false;
            _isInSecondPiece = false;
            _isInThirdPiece = false;
            _isInFourthPiece = false;
        }



        private void SelectCurrentPieceActive(Image currentActivePiece)
        {
            _firstPiece.gameObject.SetActive(false);
            _secondPiece.gameObject.SetActive(false);
            _thirdPiece.gameObject.SetActive(false);
            _fourthPiece.gameObject.SetActive(false);

            currentActivePiece.gameObject.SetActive(true);
        }



        public void Show()
        {
            _currentScore = ServiceLocator.Instance.GetService<ScoreSystem>().BattleCurrentScore;
            _currentGems = ServiceLocator.Instance.GetService<GemsSystem>().BattleCurrentGems;
            _scoreText.SetText(_currentScore.ToString());
            _gemsText.SetText(_currentGems.ToString());
            gameObject.SetActive(true);
        }

        public void hide()
        {
            gameObject.SetActive(false);
        }

        private async void OnBackToMenuPressed()
        {
            if (_isInFourthPiece)
            {
                if (Application.internetReachability == NetworkReachability.NotReachable)
                {
                    ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("NotEnough");
                    var NotEnoughEventData = new NotEnoughEventData("NotConnection", GetInstanceID());
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(NotEnoughEventData);
                    return;
                }
                else
                {
                    ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Button");
                    if (ServiceLocator.Instance.GetService<AdsSystem>().GetIfIsAdsRemoved())
                    {
                        CheckIfIsLastLevelOrLastMap();

                        _stopped = true;
                        var victorySpinWheelSendEventData = new VictorySpinWheelSendEventData(_finalCurrentScore, _finalCurrentGems,
                                                                                              GetInstanceID());
                        ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(victorySpinWheelSendEventData);
                        await Task.Delay(800);
                        ServiceLocator.Instance.GetService<AudioManager>().StopGameMusic();
                        _mediator.OnBackToMenuPressed();
                        return;
                    }
                }
            }
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Button");
            CheckIfIsLastLevelOrLastMap();

            _stopped = true;
            var victorySpinWheelSendEventData2 = new VictorySpinWheelSendEventData(_finalCurrentScore, _finalCurrentGems,
                                                                                  GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(victorySpinWheelSendEventData2);
            await Task.Delay(800);
            ServiceLocator.Instance.GetService<AudioManager>().StopGameMusic();
            _mediator.OnBackToMenuPressed();
        }


        private void CheckIfIsLastLevelOrLastMap()
        {
            var serviceLocator = ServiceLocator.Instance.GetService<MapsAndLevelsSystem>();

            bool isNewLevelPlayed = serviceLocator.IsNewLevelPlayed();
            bool isLastMapLevelPlayed = serviceLocator.IsLastMapLevelPlayed();
            string lastMapPlayed = serviceLocator.GetLastMapPlayed();

            if (isNewLevelPlayed)
            {
                int maxLevelReached = serviceLocator.GetMaxLevelReached();
                maxLevelReached++;
                serviceLocator.SaveMaxLevelReached(maxLevelReached);
            }
            if (isLastMapLevelPlayed)
            {
                switch (lastMapPlayed)
                {
                    case "Moon Walker":
                        if (!serviceLocator.IsMoonWalkerPassed())
                        {
                            serviceLocator.SaveLastMapPlayed("Atlans Abyss");
                            serviceLocator.SaveMaxMapReached("Atlans Abyss");
                            serviceLocator.SaveIfIsMoonWalkerPassed(true);
                            return;
                        }
                        return;

                    case "Atlans Abyss":
                        if (!serviceLocator.IsAtlansAbyssPassed())
                        {
                            serviceLocator.SaveLastMapPlayed("Villa Soldati");
                            serviceLocator.SaveMaxMapReached("Villa Soldati");
                            serviceLocator.SaveIfIsAtlansAbyssPassed(true);
                            return;
                        }
                        return;
                    case "Villa Soldati":
                        if (!serviceLocator.IsVillaSoldatiPassed())
                        {
                            serviceLocator.SaveLastMapPlayed("Raklion");
                            serviceLocator.SaveMaxMapReached("Raklion");
                            serviceLocator.SaveIfIsVillaSoldatiPassed(true);
                            return;
                        }
                        return;
                    case "Raklion":
                        if (!serviceLocator.IsRaklionPassed())
                        {
                            serviceLocator.SaveLastMapPlayed("Acheron");
                            serviceLocator.SaveMaxMapReached("Acheron");
                            serviceLocator.SaveIfIsRaklionPassed(true);
                            return;
                        }
                        return;
                    case "Acheron":
                        {
                            serviceLocator.SaveLastMapPlayed("Acheron");
                            serviceLocator.SaveMaxMapReached("Acheron");
                            serviceLocator.SaveIfIsAcheronPassed(true);
                        }

                        return;
                }
            }
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.AdWatched)
            {
                CheckIfIsLastLevelOrLastMap();

                _stopped = true;
                var victorySpinWheelSendEventData = new VictorySpinWheelSendEventData(_finalCurrentScore, _finalCurrentGems,
                                                                                      GetInstanceID());
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(victorySpinWheelSendEventData);
                ServiceLocator.Instance.GetService<AudioManager>().StopGameMusic();
                _mediator.OnBackToMenuPressed();
            }
        }
    }
}