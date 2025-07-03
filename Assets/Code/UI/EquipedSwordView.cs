using Assets.Code.Common.Events;
using Assets.Code.Common.SwordsData;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class EquipedSwordView : MonoBehaviour, EventObserver
    {

        [SerializeField] private Image _swordImage;
        [SerializeField] private TextMeshProUGUI _swordName;
        [SerializeField] private TextMeshProUGUI _swordLevel;
        [SerializeField] private Image _swordDeepBackground;
        [SerializeField] private Image _swordBackground;
        [SerializeField] private Image _swordIconBackground;

        [SerializeField] private Button _swordButton;
        [SerializeField] private SelectedSwordView _selectedSwordView;


        private Sprite _swordSpriteUnevolved;
        private Sprite _swordSpriteEvolved;
        private int _swordUpgradeValue;
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
       


        private void Awake()
        {
            _swordButton.onClick.AddListener(ShowSelectedSwordView);
        }

        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.SwordEquiped, this);
            eventQueue.Subscribe(EventIds.SwordEquippedLevelUp, this);
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.SwordEquiped, this);
            eventQueue.Unsubscribe(EventIds.SwordEquippedLevelUp, this);
        }


        private void SetEquipedSwordStats()
        {
            if (_level >= 50)
            {
                _swordImage.sprite = _swordSpriteEvolved;
            }
            else
            {
                _swordImage.sprite = _swordSpriteUnevolved;
            }
            _swordName.SetText(_id);
            _swordName.color = _nameColor;
            _swordLevel.SetText(_level.ToString());
            _swordLevel.color = _levelColor;
            _swordDeepBackground.color = _deepBackground;
            _swordBackground.color = _background;
            _swordIconBackground.color = _iconBackground;
        }


        private void ShowSelectedSwordView()
        {
            _selectedSwordView.SetStadistics(_swordSpriteUnevolved, _swordSpriteEvolved, _swordUpgradeValue, _id, _level, _hp, _fire, _poison,
                                             _ice, _water, _electric, _ghost, _rainbow,
                                             _deepBackground, _background,_iconBackground, _nameColor, _levelColor);
            _selectedSwordView.Show();
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Bloop");
        }


        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.SwordEquiped)
            {
                var swordEquipedEventData = (SwordEquipedEventData)eventData;

                _swordSpriteUnevolved = swordEquipedEventData._swordSpriteUnevolved;
                _swordSpriteEvolved = swordEquipedEventData._swordSpriteEvolved;
                _swordUpgradeValue = swordEquipedEventData._swordUpgradeValue;
                _id = swordEquipedEventData._id;
                _level = swordEquipedEventData._level;
                _hp = swordEquipedEventData._hp;
                _fire = swordEquipedEventData._fire;
                _poison = swordEquipedEventData._poison;
                _ice = swordEquipedEventData._ice;
                _water = swordEquipedEventData._water;
                _electric = swordEquipedEventData._electric;
                _ghost = swordEquipedEventData._ghost;
                _rainbow = swordEquipedEventData._rainbow;
                _deepBackground = swordEquipedEventData._deepBackground;
                _deepBackground.a = 1;
                _background = swordEquipedEventData._background;
                _background.a = 1;
                _iconBackground = swordEquipedEventData._iconBackground;
                _iconBackground.a = 1;
                _nameColor = swordEquipedEventData._nameColor;
                _nameColor.a = 1;
                _levelColor = swordEquipedEventData._levelColor;
                _levelColor.a = 1;

                SetEquipedSwordStats();

                return;
            }



            if (eventData.EventId == EventIds.SwordEquippedLevelUp)
            {
                var swordEquippedLevelUpEventData = (SwordEquippedLevelUpEventData)eventData;
                if (ServiceLocator.Instance.GetService<SwordEquippedSystem>().GetSwordEquipped() == swordEquippedLevelUpEventData.Id)
                {
                    _swordUpgradeValue = swordEquippedLevelUpEventData.TrailUpgradeValue;
                    _id = swordEquippedLevelUpEventData.Id;
                    _level = swordEquippedLevelUpEventData.Level;
                    _hp = swordEquippedLevelUpEventData.Hp;
                    _fire = swordEquippedLevelUpEventData.Fire;
                    _poison = swordEquippedLevelUpEventData.Poison;
                    _ice = swordEquippedLevelUpEventData.Ice;
                    _water = swordEquippedLevelUpEventData.Water;
                    _electric = swordEquippedLevelUpEventData.Electric;
                    _ghost = swordEquippedLevelUpEventData.Ghost;
                    _rainbow = swordEquippedLevelUpEventData.Rainbow;

                    SetEquipedSwordStats();
                }
            }
        }
    }
}