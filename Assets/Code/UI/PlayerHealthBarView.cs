using Assets.Code.Common.Events;
using Assets.Code.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class PlayerHealthBarView : MonoBehaviour, EventObserver
    {

        [SerializeField] private TextMeshProUGUI _health;
        [SerializeField] private Slider _healthBar;
        [SerializeField] private Image _healthBarImage;

        private Color _healthColor;
        private int _maxHp;

        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.PlayerHealthChanged, this);
            eventQueue.Subscribe(EventIds.PlayerMaxHealthChanged, this);
            eventQueue.Subscribe(EventIds.GameOver, this);
            eventQueue.Subscribe(EventIds.Victory, this);
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.PlayerHealthChanged, this);
            eventQueue.Unsubscribe(EventIds.PlayerMaxHealthChanged, this);
            eventQueue.Unsubscribe(EventIds.GameOver, this);
            eventQueue.Unsubscribe(EventIds.Victory, this);
        }



        public void UpdateMaxHealth(int newMaxHp)
        {
            _healthBar.maxValue = newMaxHp;
            _maxHp = newMaxHp;
            UpdateHealth(_maxHp);
        }

        public void UpdateHealth(int newCurrentHp)
        {
            _healthBar.value = newCurrentHp;
            _health.SetText(newCurrentHp.ToString());
            ChangeHealthColor();
        }

        public void ChangeHealthColor()
        {
            if (_healthBar.value <= (_maxHp * 15) / 100)
            {
                ChangeBarAndNumberColor(1, 0.06f, 0.003f);
                return;
            }
            else if (_healthBar.value <= ((_maxHp * 50) / 100))
            {
                ChangeBarAndNumberColor(1, 0.9529f, 0.003f);
                return;
            }
            else if (_healthBar.value < _maxHp)
            {
                ChangeBarAndNumberColor(0.06f, 1, 0);
                return;
            }
            else
            {
                ChangeBarAndNumberColor(0, 1, 0.9843f);
            }
        }

        private void ChangeBarAndNumberColor(float r, float g, float b)
        {
            _healthColor.r = r;
            _healthColor.g = g;
            _healthColor.b = b;
            _healthColor.a = 1;

            _healthBarImage.color = _healthColor;
            _health.color = _healthColor;
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.PlayerMaxHealthChanged)
            {
                var playerMaxHealthChangedEventData = (PlayerMaxHealthChangedEventData)eventData;
                UpdateMaxHealth(playerMaxHealthChangedEventData.MaxHealthChangedAmount);
            }


            if (eventData.EventId == EventIds.PlayerHealthChanged)
            {
                var playerHealthChangedEventData = (PlayerHealthChangedEventData)eventData;
                UpdateHealth(playerHealthChangedEventData.HealthChangedAmount);
            }

            if (eventData.EventId == EventIds.GameOver)
            {
                UpdateHealth(0);
            }
        }
    }
}