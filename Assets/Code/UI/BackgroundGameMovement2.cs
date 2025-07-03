using Assets.Code.Common.Events;
using Assets.Code.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class BackgroundGameMovement2 : MonoBehaviour, EventObserver
    {

        private Vector2 _scrollSpeed = new Vector2(0.0f, 1f);
        [SerializeField] private RectTransform _firstBackground;
        [SerializeField] private RectTransform _secondBackground;


        void Start()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.ProjectileAndBackgroundSpeed, this);
            SetResolutionForAllBackgrounds();
        }

        private void SetResolutionForAllBackgrounds()
        {
            _firstBackground.sizeDelta = new Vector2(Screen.width, Screen.height);
            _secondBackground.sizeDelta = new Vector2(Screen.width, Screen.height);

            _firstBackground.position = new Vector2(0, Screen.height);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.ProjectileAndBackgroundSpeed, this);
        }

        void FixedUpdate()
        {
            var offset = Time.time * _scrollSpeed;
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ProjectileAndBackgroundSpeed)
            {
                var projectileAndBackgroundSpeed = (ProjectileAndMapBackgroundSpeedEventData)eventData;

                _scrollSpeed = new Vector2(0.0f, projectileAndBackgroundSpeed.ProjectileAndBackgroundSpeed);
            }
        }
    }
}