using Assets.Code.Common.MapsAndLevelsData;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using Google.Play.Review;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class AboutUsView : MonoBehaviour
    {

        [SerializeField] private Button _backgroundBackToMenuButton;
        [SerializeField] private TextMeshProUGUI _versionText;
        [SerializeField] private Button _rateMeButton;
        [SerializeField] private Button _privacyPolicyButton;


        ReviewManager _reviewManager;
        PlayReviewInfo _reviewInfo;

        private void Awake()
        {
            _backgroundBackToMenuButton.onClick.AddListener(OnBackToMenuPressed);
            _rateMeButton.onClick.AddListener(CheckForInnAppReview);
            _privacyPolicyButton.onClick.AddListener(OnPrivacyPolicyButtonPressed);
        }

        private void Start()
        {
            _versionText.SetText("V-" + Application.version);
        }

        private void OnBackToMenuPressed()
        {
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("ReverseBloop");
            gameObject.SetActive(false);
        }

        public void HideFirst()
        {
            gameObject.SetActive(false);
        }

        private void OnPrivacyPolicyButtonPressed()
        {
            Application.OpenURL("https://www.privacypolicies.com/live/9b9e8636-2107-409a-8820-d1855a2a54fc");
        }

        private void CheckForInnAppReview()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                _reviewManager = new ReviewManager();
                if (!ServiceLocator.Instance.GetService<MapsAndLevelsSystem>().IsGameReviewed())
                {
                    StartCoroutine(ReviewOperation());
                }
                else
                {
                    Application.OpenURL("https://play.google.com/store/apps/details?id=com.BlueScorpioStudio.TetrisTapDodger");
                }
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
    }
}