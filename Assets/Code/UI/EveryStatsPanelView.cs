using Assets.Code.Common.Events;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class EveryStatsPanelView : MonoBehaviour, EventObserver
    {
        [SerializeField] RectTransform _panelTransform;
        [SerializeField] private Button _switchButton;
        [SerializeField] private Image _switchIconOpen;
        [SerializeField] private Image _switchIconClose;

        [SerializeField] private TextMeshProUGUI _characterHp;
        [SerializeField] private TextMeshProUGUI _characterFire;
        [SerializeField] private TextMeshProUGUI _characterPoison;
        [SerializeField] private TextMeshProUGUI _characterIce;
        [SerializeField] private TextMeshProUGUI _characterWater;
        [SerializeField] private TextMeshProUGUI _characterElectric;
        [SerializeField] private TextMeshProUGUI _characterGhost;
        [SerializeField] private TextMeshProUGUI _characterRainbow;


        [SerializeField] private TextMeshProUGUI _swordHp;
        [SerializeField] private TextMeshProUGUI _swordFire;
        [SerializeField] private TextMeshProUGUI _swordPoison;
        [SerializeField] private TextMeshProUGUI _swordIce;
        [SerializeField] private TextMeshProUGUI _swordWater;
        [SerializeField] private TextMeshProUGUI _swordElectric;
        [SerializeField] private TextMeshProUGUI _swordGhost;
        [SerializeField] private TextMeshProUGUI _swordRainbow;


        [SerializeField] private TextMeshProUGUI _upgradesHp;
        [SerializeField] private TextMeshProUGUI _upgradesFire;
        [SerializeField] private TextMeshProUGUI _upgradesPoison;
        [SerializeField] private TextMeshProUGUI _upgradesIce;
        [SerializeField] private TextMeshProUGUI _upgradesWater;
        [SerializeField] private TextMeshProUGUI _upgradesElectric;
        [SerializeField] private TextMeshProUGUI _upgradesGhost;
        [SerializeField] private TextMeshProUGUI _upgradesRainbow;

        private bool _isOpened;

        private void Awake()
        {
            _switchButton.onClick.AddListener(SwitchPanel);
            _switchIconClose.gameObject.SetActive(false);
        }


        private void Start()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.PlayerSendEveryStatsValue, this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.PlayerSendEveryStatsValue, this);
        }


        private void SwitchPanel()
        {
            if (_isOpened)
            {
                StartCoroutine(Move(_panelTransform, new Vector2(-700, 0)));
                _switchIconClose.gameObject.SetActive(false);
                _switchIconOpen.gameObject.SetActive(true);
                _isOpened = false;
            }
            else
            {
                StartCoroutine(Move(_panelTransform, new Vector2(0, 0)));
                _switchIconClose.gameObject.SetActive(true);
                _switchIconOpen.gameObject.SetActive(false);
                _isOpened = true;
            }
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Button");
        }


        private void SetEveryStat(int characterHpValue, float characterFire,
                                  float characterPoison, float characterIce,
                                  float characterWater, float characterElectric,
                                  float characterGhost, float characterRainbow,

                                  int swordHpValue, float swordFire, float swordPoison,
                                  float swordIce, float swordWater, float swordElectric,
                                  float swordGhost, float swordRainbow,

                                  float upgradesHpValue, float upgradesFire,
                                  float upgradesPoison, float upgradesIce,
                                  float upgradesWater, float upgradesElectric,
                                  float upgradesGhost, float upgradesRainbow)
        {
            _characterHp.SetText(characterHpValue.ToString());
            _characterFire.SetText(characterFire.ToString("f1") + "%");
            _characterPoison.SetText(characterPoison.ToString("f1") + "%");
            _characterIce.SetText(characterIce.ToString("f1") + "%");
            _characterWater.SetText(characterWater.ToString("f1") + "%");
            _characterElectric.SetText(characterElectric.ToString("f1") + "%");
            _characterGhost.SetText(characterGhost.ToString("f1") + "%");
            _characterRainbow.SetText(characterRainbow.ToString("f1") + "%");

            _swordHp.SetText(swordHpValue.ToString());
            _swordFire.SetText(swordFire.ToString("f1") +"%");
            _swordPoison.SetText(swordPoison.ToString("f1") + "%");
            _swordIce.SetText(swordIce.ToString("f1") + "%");
            _swordWater.SetText(swordWater.ToString("f1") + "%");
            _swordElectric.SetText(swordElectric.ToString("f1") + "%");
            _swordGhost.SetText(swordGhost.ToString("f1") + "%");
            _swordRainbow.SetText(swordRainbow.ToString("f1") + "%");

            _upgradesHp.SetText(upgradesHpValue.ToString());
            _upgradesFire.SetText(upgradesFire.ToString("f1") + "%");
            _upgradesPoison.SetText(upgradesPoison.ToString("f1") + "%");
            _upgradesIce.SetText(upgradesIce.ToString("f1") + "%");
            _upgradesWater.SetText(upgradesWater.ToString("f1") + "%");
            _upgradesElectric.SetText(upgradesElectric.ToString("f1") + "%");
            _upgradesGhost.SetText(upgradesGhost.ToString("f1") + "%");
            _upgradesRainbow.SetText(upgradesRainbow.ToString("f1") + "%");
        }



        IEnumerator Move(RectTransform rt, Vector2 targetPos)
        {
            float step = 0;
            while (step < 1)
            {
                rt.offsetMin = Vector2.Lerp(rt.offsetMin, targetPos, step += Time.deltaTime);
                rt.offsetMax = Vector2.Lerp(rt.offsetMax, targetPos, step += Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }


        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.PlayerSendEveryStatsValue)
            {
                var playerStat = (playerSendEveryStatsEventData)eventData;

                SetEveryStat(playerStat.CharacterHpValue, playerStat.CharacterFire,
                         playerStat.CharacterPoison, playerStat.CharacterIce, playerStat.CharacterWater,
                         playerStat.CharacterElectric, playerStat.CharacterGhost, playerStat.CharacterRainbow,
                         

                         playerStat.SwordHpValue, playerStat.SwordFire, playerStat.SwordPoison,
                         playerStat.SwordIce, playerStat.SwordWater, playerStat.SwordElectric,
                         playerStat.SwordGhost, playerStat.SwordRainbow,

                         playerStat.UpgradesHpValue, playerStat.UpgradesFire,
                         playerStat.UpgradesPoison, playerStat.UpgradesIce, playerStat.UpgradesWater,
                         playerStat.UpgradesElectric, playerStat.UpgradesGhost, playerStat.UpgradesRainbow);
            }
        }
    }
}