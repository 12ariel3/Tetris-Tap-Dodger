using Assets.Code.Common.Events;
using Assets.Code.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.ZOthers
{
    public class MainCharacterPlatformMovement : MonoBehaviour, EventObserver
    {
        [SerializeField] float _speed;
        [SerializeField] RectTransform _limitLeft;
        [SerializeField] RectTransform _limitRight;
        [SerializeField] Image _playerSprite;

        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.SwordEquiped, this);
            eventQueue.Subscribe(EventIds.SwordLevelUp50, this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.SwordEquiped, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.SwordLevelUp50, this);
        }

        private void Update()
        {
            PlayerMovement();
        }

        private void PlayerMovement()
        {
            _playerSprite.transform.position = new Vector2(_playerSprite.transform.position.x + _speed * Time.deltaTime,
                                                           _playerSprite.transform.position.y);

            if (_playerSprite.transform.position.x >= _limitRight.position.x)
            {
                _playerSprite.transform.position = new Vector2(_limitRight.position.x, _playerSprite.transform.position.y);
                ChangeDirection();
            }

            if (_playerSprite.transform.position.x <= _limitLeft.position.x)
            {
                _playerSprite.transform.position = new Vector2(_limitLeft.position.x, _playerSprite.transform.position.y);
                ChangeDirection();
            }
        }

        private void ChangeDirection()
        {
            _speed = -_speed;
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.SwordEquiped)
            { 
                var swordEquipedEventData = (SwordEquipedEventData)eventData;
                if (swordEquipedEventData._level >= 50)
                {
                    _playerSprite.sprite = swordEquipedEventData._swordSpriteEvolved;
                }
                else
                {
                    _playerSprite.sprite = swordEquipedEventData._swordSpriteUnevolved;
                }
            }
            if (eventData.EventId == EventIds.SwordLevelUp50)
            {
                var swordLvlUpPopUp50EventData = (SwordLvlUpPopUp50EventData)eventData;
                _playerSprite.sprite = swordLvlUpPopUp50EventData.EvolvedSprite;
            }
        }
    }
}