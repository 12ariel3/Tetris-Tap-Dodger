using Assets.Code.Common.Events;
using Assets.Code.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class BackgroundGameMovement : MonoBehaviour, EventObserver
    {

        private Vector2 _scrollSpeed = new Vector2(0.0f, 1f);
        private Image _renderer;
        private Material _material;
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");

        private int _baseWidth = 1080;
        private int _baseHeight = 1920;
        private int _currentWidth;
        private int _currentHeight;
        private float _scaleFactor;
        private float _levelSpeed;

        void Start()
        {
            _renderer = GetComponent<Image>();
            _material = _renderer.material;
            _currentWidth = Screen.currentResolution.width;
            _currentHeight = Screen.currentResolution.height;
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.ProjectileAndBackgroundSpeed, this);
        }

        private float ScaleSpeedMovementForDiferentResolutions(float levelSpeed)
        {
            float scaleFactorWidth = (float)_currentWidth / _baseWidth;
            float scaleFactorHeight = (float)_currentHeight / _baseHeight;
            _levelSpeed = levelSpeed;
            _scaleFactor = (scaleFactorWidth + scaleFactorHeight) / 2f;

            float baseSpeed = levelSpeed / 16f;
            float adjustedSpeed = baseSpeed * scaleFactorHeight;

            return adjustedSpeed;
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.ProjectileAndBackgroundSpeed, this);
        }

        void FixedUpdate()
        {
            var offset = Time.time * _scrollSpeed;
            _material.SetTextureOffset(MainTex, offset);
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ProjectileAndBackgroundSpeed)
            {
                var projectileAndBackgroundSpeed = (ProjectileAndMapBackgroundSpeedEventData)eventData;
                    
                float speedY = ScaleSpeedMovementForDiferentResolutions(projectileAndBackgroundSpeed.ProjectileAndBackgroundSpeed);

                _scrollSpeed = new Vector2(0.0f, speedY);
            }
        }
    }
}