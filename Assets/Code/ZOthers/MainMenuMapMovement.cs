using UnityEngine;

namespace Assets.Code.ZOthers
{
    public class MainMenuMapMovement : MonoBehaviour
    {

        private Vector3 _platformRotation = new Vector3(0, 10, 0);
        [SerializeField] private RectTransform _rectTransform;

        private bool _isGoingUp;



        void Update()
        {
            if (_isGoingUp)
            {
                var offset = Time.deltaTime * _platformRotation;
                _rectTransform.localPosition += offset;
            }
            else
            {
                var offset = Time.deltaTime * _platformRotation;
                _rectTransform.localPosition -= offset;
            }

            CheckingAndChangingDirection();
        }


        private void CheckingAndChangingDirection()
        {
            if (_rectTransform.localPosition.y >= 298 && _isGoingUp)
            {
                _platformRotation.y = 6;
            }
            if (_rectTransform.localPosition.y <= 274 && !_isGoingUp)
            {
                _platformRotation.y = 6;
            }
            if (_rectTransform.localPosition.y >= 300)
            {
                _isGoingUp = false;
                _platformRotation.y = 10;
            }
            if (_rectTransform.localPosition.y <= 274)
            {
                _isGoingUp = true;
                _platformRotation.y = 10;
            }
        }
    }
}