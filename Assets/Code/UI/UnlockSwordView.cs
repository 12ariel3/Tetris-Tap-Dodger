using Assets.Code.Common.Events;
using Assets.Code.Common.GemsData;
using Assets.Code.Common.Level;
using Assets.Code.Common.Score;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class UnlockSwordView : MonoBehaviour
    {

        [SerializeField] private Button _closeButton;
        [SerializeField] private TextMeshProUGUI _scoreCostValue;
        [SerializeField] private TextMeshProUGUI _gemCostValue;
        [SerializeField] private Button _unlockButton;

        [SerializeField] private Image _swordImage;
        [SerializeField] private TextMeshProUGUI _swordName;
        [SerializeField] private TextMeshProUGUI _swordLevel;
        [SerializeField] private Image _swordDeepBackground;
        [SerializeField] private Image _swordBackground;
        [SerializeField] private Image _swordIconBackground;



        private Sprite _swordSprite;
        private int _unlockScoreValue;
        private int _unlockGemValue;
        private string _id;
        private int _level;
        private Color _deepBackground;
        private Color _background;
        private Color _iconBackground;
        private Color _nameColor;
        private Color _levelColor;


        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButtonPressed);
            _unlockButton.onClick.AddListener(OnUnlockButtonPressed);
        }



        private void OnUnlockButtonPressed()
        {
            var serviceLocator = ServiceLocator.Instance;
            int currentScore = serviceLocator.GetService<ScoreSystem>().GetTotalScore();
            int currentGems = serviceLocator.GetService<GemsSystem>().GetTotalGems();
            if (_unlockScoreValue <= currentScore && _unlockGemValue <= currentGems)
            {
                currentScore -= _unlockScoreValue;
                currentGems -= _unlockGemValue;


                serviceLocator.GetService<ScoreSystem>().SaveTotalScore(currentScore);
                serviceLocator.GetService<GemsSystem>().SaveTotalGems(currentGems);
                serviceLocator.GetService<ScoreView>().UpdateScore(currentScore);
                serviceLocator.GetService<GemsView>().UpdateGems(currentGems);


                serviceLocator.GetService<AudioManager>().PlayOtherSfx("Unlock");
                serviceLocator.GetService<SwordsLevelSystem>().SaveIfIsSwordUnlocked(_id, true);
                serviceLocator.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.SwordUnlocked));
                OnCloseButtonPressed();
            }
            else
            {
                if (_unlockScoreValue >= currentScore)
                {
                    ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("NotEnough");
                    var NotEnoughEventData = new NotEnoughEventData("Score", GetInstanceID());
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(NotEnoughEventData);
                    return;
                }
                if (_unlockGemValue >= currentGems)
                {
                    ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("NotEnough");
                    var NotEnoughEventData = new NotEnoughEventData("Gems", GetInstanceID());
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(NotEnoughEventData);
                    return;
                }
            }
        }



        private void OnCloseButtonPressed()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("ReverseBloop");
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        public void HideFirst()
        {
            gameObject.SetActive(false);
        }

        public void SetStadistics(Sprite swordSprite, int unlockScoreCost, int unlockGemCost, string swordName, int swordLevel, Color deepBackground,
                                  Color background, Color iconBackground, Color nameColor, Color levelColor)
        {


            _swordSprite = swordSprite;
            _unlockScoreValue = unlockScoreCost;
            _unlockGemValue = unlockGemCost;
            _id = swordName;
            _level = swordLevel;
            _deepBackground = deepBackground;
            _background = background;
            _iconBackground = iconBackground;
            _nameColor = nameColor;
            _levelColor = levelColor;


            _swordImage.sprite = _swordSprite;
            _scoreCostValue.SetText(_unlockScoreValue.ToString());
            _gemCostValue.SetText(_unlockGemValue.ToString());
            _swordName.SetText(_id);
            _nameColor.a = 1;
            _swordName.color = _nameColor;
            _swordLevel.SetText(_level.ToString());
            _levelColor.a = 1;
            _swordLevel.color = _levelColor;
            _deepBackground.a = 1;
            _swordDeepBackground.color = _deepBackground;
            _background.a = 1;
            _swordBackground.color = _background;
            _iconBackground.a = 1;
            _swordIconBackground.color = _iconBackground;

        }
    }
}