using Assets.Code.Common.Settings;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.ZOthers
{
    public class ToggleSwitch : MonoBehaviour
    {

        [SerializeField] private RectTransform _handleTransform;
        [SerializeField] private Image _handleImage;
        [SerializeField] private Image _switchImage;
        [SerializeField] private string _id;

        private bool _isOn;
        private Vector2 _newHandlePosition;
        private Color _backgroundColor;
        private Color _handleColor;


        void Start()
        {
            if (_id == "Vibration")
            {
                _isOn = ServiceLocator.Instance.GetService<SettingsSystem>().IsVibrationActived();
            }

            FirstToggle(_isOn);
        }

        public void FirstToggle(bool isOn)
        {
            if (isOn)
            {
                _newHandlePosition.x = 15;
                _handleTransform.anchoredPosition = _newHandlePosition;
                _backgroundColor = _switchImage.color;
                _backgroundColor.r = 0.48f;
                _backgroundColor.g = 0.79f;
                _backgroundColor.b = 0.42f;
                _backgroundColor.a = 1;
                _switchImage.color = _backgroundColor;

                _handleColor = _handleImage.color;
                _handleColor.r = 0;
                _handleColor.g = 1;
                _handleColor.b = 0;
                _handleColor.a = 1;
                _handleImage.color = _handleColor;
            }
            else
            {
                _newHandlePosition.x = -15;
                _handleTransform.anchoredPosition = _newHandlePosition;
                _backgroundColor = _switchImage.color;
                _backgroundColor.r = 0.79f;
                _backgroundColor.g = 0.52f;
                _backgroundColor.b = 0.48f;
                _backgroundColor.a = 1;
                _switchImage.color = _backgroundColor;

                _handleColor = _handleImage.color;
                _handleColor.r = 1;
                _handleColor.g = 0;
                _handleColor.b = 0;
                _handleColor.a = 1;
                _handleImage.color = _handleColor;
            }
        }



        public void Toggle(bool isOn)
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Button");
            if (isOn)
            {
                _newHandlePosition.x = 15;
                _handleTransform.anchoredPosition = _newHandlePosition;
                _backgroundColor = _switchImage.color;
                _backgroundColor.r = 0.48f;
                _backgroundColor.g = 0.79f;
                _backgroundColor.b = 0.42f;
                _backgroundColor.a = 1;
                _switchImage.color = _backgroundColor;

                _handleColor = _handleImage.color;
                _handleColor.r = 0;
                _handleColor.g = 1;
                _handleColor.b = 0;
                _handleColor.a = 1;
                _handleImage.color = _handleColor;
            }
            else
            {
                _newHandlePosition.x = -15;
                _handleTransform.anchoredPosition = _newHandlePosition;
                _backgroundColor = _switchImage.color;
                _backgroundColor.r = 0.79f;
                _backgroundColor.g = 0.52f;
                _backgroundColor.b = 0.48f;
                _backgroundColor.a = 1;
                _switchImage.color = _backgroundColor;

                _handleColor = _handleImage.color;
                _handleColor.r = 1;
                _handleColor.g = 0;
                _handleColor.b = 0;
                _handleColor.a = 1;
                _handleImage.color = _handleColor;
            }
        }
    }
}