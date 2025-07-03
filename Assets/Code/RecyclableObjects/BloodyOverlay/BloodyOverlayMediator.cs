using Assets.Code.Common;
using Assets.Code.Common.Events;
using Assets.Code.Core;
using Assets.Code.RecyclableObjects.PopUps;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.RecyclableObjects.BloodyOverlay
{
    public class BloodyOverlayMediator : RecyclableObject, EventObserver
    {
        [SerializeField] private Image _image;
        [SerializeField] private PopUpId _popUpId;

        public string Id => _popUpId.Value;


        private float _beatSpeed = 2f;
        private Color _imageColor;
        private bool _isActive;
        private bool _isIncreasingAlpha;

        internal override void Init()
        {
            _imageColor.r = 233f;
            _imageColor.g = 91f;
            _imageColor.b = 91f;
            _imageColor.a = 0f;
        }

        internal override void Release()
        {
        }

        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.PlayerHealthChanged, this);
            eventQueue.Subscribe(EventIds.Victory, this);
            eventQueue.Subscribe(EventIds.GameOver, this);
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.PlayerHealthChanged, this);
            eventQueue.Unsubscribe(EventIds.Victory, this);
            eventQueue.Unsubscribe(EventIds.GameOver, this);
        }

        public void Configure(bool isActive)
        {
            _isActive = isActive;
        }


        private void Update()
        {
            if (_isActive)
            {
                Beat();
            }
        }

        private void Beat()
        {
            if (_imageColor.a <= 0 && !_isIncreasingAlpha)
            {
                _isIncreasingAlpha = true;
            }

            if (_imageColor.a < 1f && _isIncreasingAlpha)
            {
                _imageColor.a += _beatSpeed * Time.deltaTime;
                _image.color = _imageColor;
                return;
            }
            else
            {
                _isIncreasingAlpha = false;
                _imageColor.a -= _beatSpeed * Time.deltaTime;
                _image.color = _imageColor;
            }
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.PlayerHealthChanged)
            {
                var playerHealthChangedEventData = (PlayerHealthChangedEventData)eventData;
                if (_isActive != playerHealthChangedEventData.IsBlooding)
                {
                    _isActive = playerHealthChangedEventData.IsBlooding;
                    if (_isActive == false)
                    {
                        _imageColor.a = 0;
                        _image.color = _imageColor;
                    }
                }
            }
            if (eventData.EventId == EventIds.Victory || eventData.EventId == EventIds.GameOver)
            {
                _isActive = false;
                _imageColor.a = 0;
                _image.color = _imageColor;
                Recycle();
            }
        }
    }
}