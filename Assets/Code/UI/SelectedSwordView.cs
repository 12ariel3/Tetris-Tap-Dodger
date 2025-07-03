using Assets.Code.Common.Events;
using Assets.Code.Common.Score;
using Assets.Code.Common.SwordsData;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class SelectedSwordView : MonoBehaviour
    {

        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private TextMeshProUGUI _upgradeButtonValue;
        [SerializeField] private Button _equipButton;

        [SerializeField] private Image _swordImage;
        [SerializeField] private TextMeshProUGUI _swordName;
        [SerializeField] private TextMeshProUGUI _swordLevel;
        [SerializeField] private TextMeshProUGUI _swordHp;
        [SerializeField] private TextMeshProUGUI _swordFire;
        [SerializeField] private TextMeshProUGUI _swordPoison;
        [SerializeField] private TextMeshProUGUI _swordIce;
        [SerializeField] private TextMeshProUGUI _swordWater;
        [SerializeField] private TextMeshProUGUI _swordElectric;
        [SerializeField] private TextMeshProUGUI _swordGhost;
        [SerializeField] private TextMeshProUGUI _swordRainbow;
        [SerializeField] private Image _swordDeepBackground;
        [SerializeField] private Image _swordBackground;
        [SerializeField] private Image _swordIconBackground;



        private Sprite _swordSpriteUnevolved;
        private Sprite _swordSpriteEvolved;
        private int _upgradeValue;
        private string _id;
        private int _level;
        private int _hp;
        private float _fire;
        private float _poison;
        private float _ice;
        private float _water;
        private float _electric;
        private float _ghost;
        private float _rainbow;
        private Color _deepBackground;
        private Color _background;
        private Color _iconBackground;
        private Color _nameColor;
        private Color _levelColor;
        private Vector2 _unevolvedFirstColliderOffset;
        private Vector2 _unevolvedFirstColliderSize;
        private Vector2 _unevolvedSecondColliderOffset;
        private Vector2 _unevolvedSecondColliderSize;
        private Vector2 _evolvedFirstColliderOffset;
        private Vector2 _evolvedFirstColliderSize;
        private Vector2 _evolvedSecondColliderOffset;
        private Vector2 _evolvedSecondColliderSize;


        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButtonPressed);
            _upgradeButton.onClick.AddListener(OnUpgradeButtonPressed);
            _equipButton.onClick.AddListener(OnEquipButtonPressed);
        }

        private void OnEquipButtonPressed()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Equip");
            ServiceLocator.Instance.GetService<SwordEquippedSystem>().SaveSwordEquipped(_id);
            SetSelectedSword();
            ActiveEquippedPopUp();
            OnCloseButtonPressed();
        }

        private void ActiveEquippedPopUp()
        {
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.ActiveSwordEquippedPopUp));
        }

        private void SetSelectedSword()
        {
            var swordEquipedEventData = new SwordEquipedEventData(_swordSpriteUnevolved, _swordSpriteEvolved, _upgradeValue, _id, _level,
                                                                  _hp, _fire, _poison, _ice, _water,
                                                                  _electric, _ghost, _rainbow,
                                                                  _deepBackground, _background, _iconBackground,
                                                                  _nameColor, _levelColor, GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(swordEquipedEventData);
        }

        private void OnUpgradeButtonPressed()
        {
            if (_level < 100)
            {
                int _totalScore = ServiceLocator.Instance.GetService<ScoreSystem>().GetTotalScore();
                if (_totalScore >= _upgradeValue)
                {
                    ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Upgrade");
                    int newScore = _totalScore - _upgradeValue;
                    ServiceLocator.Instance.GetService<ScoreSystem>().SaveTotalScore(newScore);
                    ServiceLocator.Instance.GetService<ScoreView>().UpdateScore(newScore);

                    if(_level == 49)
                    {
                        ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("SwordLvlUp50");
                        var swordLvlUpPopUp50EventData = new SwordLvlUpPopUp50EventData(_swordImage.transform.position,
                                                                                        _swordSpriteEvolved, GetInstanceID());
                        ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(swordLvlUpPopUp50EventData);
                    }

                    _level++;
                    var swordLevelUpEventData = new SwordLevelUpEventData(_id, _level, GetInstanceID());
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(swordLevelUpEventData);

                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.UpgradesLevelUpPopUpSpawn));
                    if (_level >= 100)
                    {
                        _upgradeButton.gameObject.SetActive(false);
                    }
                }
                else
                {
                    ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("NotEnough");
                    var NotEnoughEventData = new NotEnoughEventData("Score", GetInstanceID());
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(NotEnoughEventData);
                }
            }
        }

        private void OnCloseButtonPressed()
        {
            Hide();
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("ReverseBloop");
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

        public void SetStadistics(Sprite swordSpriteUnevolved, Sprite swordSpriteEvolved, int swordUpgradeValue, string swordName, int swordLevel,
                                  int swordHp, float swordFire, float swordPoison, float swordIce, float swordWater, float swordElectric,
                                  float swordGhost, float swordRainbow, Color deepBackground,
                                  Color background, Color iconBackground, Color nameColor, Color levelColor)
        {

            if (ServiceLocator.Instance.GetService<SwordEquippedSystem>().GetSwordEquipped() == swordName)
            {
                _equipButton.gameObject.SetActive(false);
            }
            else
            {
                _equipButton.gameObject.SetActive(true);
            }

            _swordSpriteUnevolved = swordSpriteUnevolved;
            _swordSpriteEvolved = swordSpriteEvolved;
            _upgradeValue = swordUpgradeValue;
            _id = swordName;
            _level = swordLevel;
            _hp = swordHp;
            _fire = swordFire;
            _poison = swordPoison;
            _ice = swordIce;
            _water = swordWater;
            _electric = swordElectric;
            _ghost = swordGhost;
            _rainbow = swordRainbow;
            _deepBackground = deepBackground;
            _background = background;
            _iconBackground = iconBackground;
            _nameColor = nameColor;
            _levelColor = levelColor;
            


            if (_level >= 50)
            {
                _swordImage.sprite = _swordSpriteEvolved;
            }
            else
            {
                _swordImage.sprite = _swordSpriteUnevolved;
            }
            _upgradeButtonValue.SetText(_upgradeValue.ToString());
            _swordName.SetText(_id);
            _nameColor.a = 1;
            _swordName.color = _nameColor;
            _swordLevel.SetText(_level.ToString());
            _levelColor.a = 1;
            _swordLevel.color = _levelColor;
            _swordHp.SetText(_hp.ToString());
            _swordFire.SetText(_fire.ToString("f1") + "%");
            _swordPoison.SetText(_poison.ToString("f1") + "%");
            _swordIce.SetText(_ice.ToString("f1") + "%");
            _swordWater.SetText(_water.ToString("f1") + "%");
            _swordElectric.SetText(_electric.ToString("f1") + "%");
            _swordGhost.SetText(_ghost.ToString("f1") + "%");
            _swordRainbow.SetText(_rainbow.ToString("f1") + "%");
            _deepBackground.a = 1;
            _swordDeepBackground.color = _deepBackground;
            _background.a = 1;
            _swordBackground.color = _background;
            _iconBackground.a = 1;
            _swordIconBackground.color = _iconBackground;

            if (_level >= 100)
            {
                _upgradeButton.gameObject.SetActive(false);
            }
            else
            {
                _upgradeButton.gameObject.SetActive(true);
            }
        }
    }
}