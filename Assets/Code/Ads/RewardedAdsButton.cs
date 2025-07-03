using Assets.Code.Common.AdsData;
using Assets.Code.Common.Events;
using Assets.Code.Core;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

namespace Assets.Code.Ads
{
    public class RewardedAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener, EventObserver
    {

        [SerializeField] Button _showAdButton;
        [SerializeField] Image _iconToRemove;
        [SerializeField] string _androidAdUnitId = "Rewarded_Android";
        [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
        string _adUnitId = null; // This will remain null for unsupported platforms

        private string _spinWheelReward = "TTDodgerRewardedFortuneWheel";
        private string _rewardMultiplierX3 = "TTDodgerRewardedVictoryX3";
        private string _gameOverExtraLife = "TTDodgerRewardedGameOverExtra";

        private bool _isX3Actived;
        private bool _adsWereRemoved;

        void Awake()
        {
            // Get the Ad Unit ID for the current platform:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID || UNITY_EDITOR
            _adUnitId = _androidAdUnitId;
#endif
            // Disable the button until the ad is ready to show:
            _showAdButton.interactable = false;
        }

        private void Start()
        {
            LoadAd();
            _showAdButton.onClick.AddListener(ShowAd);
            // Enable the button for users to click:
            _showAdButton.interactable = true;
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.VictorySpinWheelX3IsActived, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.AdsWereRemoved, this);
            _adsWereRemoved = ServiceLocator.Instance.GetService<AdsSystem>().GetIfIsAdsRemoved();
            if (_adsWereRemoved)
            {
                RemoveIcon();
            }
        }

        private void RemoveIcon()
        {
            _iconToRemove.gameObject.SetActive(false);
        }

        // Call this public method when you want to get an ad ready to show.
        public void LoadAd()
        {
            // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
            Advertisement.Load(_adUnitId, this);
        }

        // If the ad successfully loads, add a listener to the button and enable it:
        public void OnUnityAdsAdLoaded(string adUnitId)
        {
            if (adUnitId.Equals(_adUnitId))
            {
                // Configure the button to call the ShowAd() method when clicked:
                //_showAdButton.onClick.AddListener(ShowAd);
                // Enable the button for users to click:
                //_showAdButton.interactable = true;
            }
        }

        // Implement a method to execute when the user clicks the button:
        public void ShowAd()
        {
            if (!_adsWereRemoved)
            {
                if (Application.internetReachability == NetworkReachability.NotReachable)
                {
                    return;
                }
                if (_adUnitId.Equals(_rewardMultiplierX3))
                {
                    if (_isX3Actived)
                    {
                        _showAdButton.interactable = false;
                        // Then show the ad:
                        Advertisement.Show(_adUnitId, this);
                        LoadAd();
                        return;
                    }
                }
                else
                {
                    _showAdButton.interactable = false;
                    // Then show the ad:
                    Advertisement.Show(_adUnitId, this);
                    LoadAd();
                }
            }
        }

        // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
        public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
        {
            if (adUnitId.Equals(_spinWheelReward) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED) ||
                (adUnitId.Equals(_spinWheelReward) && showCompletionState.Equals(UnityAdsShowCompletionState.SKIPPED)))
            {
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.AdWatched));
            }

            if (adUnitId.Equals(_rewardMultiplierX3) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED) ||
                (adUnitId.Equals(_rewardMultiplierX3) && showCompletionState.Equals(UnityAdsShowCompletionState.SKIPPED)))
            {
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.AdWatched));
            }

            if (adUnitId.Equals(_gameOverExtraLife) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED) ||
                (adUnitId.Equals(_gameOverExtraLife) && showCompletionState.Equals(UnityAdsShowCompletionState.SKIPPED)))
            {
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.AdWatched));
            }
        }

        // Implement Load and Show Listener error callbacks:
        public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
        {
            Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
            // Use the error details to determine whether to try to load another ad.
        }

        public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
        {
            Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
            // Use the error details to determine whether to try to load another ad.
        }

        public void OnUnityAdsShowStart(string adUnitId) { }
        public void OnUnityAdsShowClick(string adUnitId) { }

        void OnDestroy()
        {
            // Clean up the button listeners:
            _showAdButton.onClick.RemoveAllListeners();
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.VictorySpinWheelX3IsActived, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.AdsWereRemoved, this);
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.VictorySpinWheelX3IsActived)
            {
                var victorySpinWheelX3IsActivedEventData = (VictorySpinWheelX3MultiplierEventData)eventData;

                _isX3Actived = victorySpinWheelX3IsActivedEventData.IsX3Actived;
                return;
            }

            if (eventData.EventId == EventIds.AdsWereRemoved)
            {
                _adsWereRemoved = true;
                RemoveIcon();
            }
        }
    }
}