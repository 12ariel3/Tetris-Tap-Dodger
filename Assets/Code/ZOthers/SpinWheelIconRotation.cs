using System.Collections;
using UnityEngine;

namespace Assets.Code.ZOthers
{
    public class SpinWheelIconRotation : MonoBehaviour
    {

        [SerializeField] private RectTransform Circle;

        private bool _isStarted;                    // Flag that the wheel is spinning


        private float _finalAngle;                  // The final angle is needed to calculate the reward
        private float _startAngle;                  // The first time start angle equals 0 but the next time it equals the last final angle
        private float _currentLerpRotationTime;     // Needed for spinning animation
        private float _cooldownTime;

        void Start()
        {
            SetWheel();
        }

        private void SetWheel()
        {
            _currentLerpRotationTime = 0f;
            _cooldownTime = 0f;

            int fullTurnovers = 8;
            int randomNumber = Random.Range(0, 360);

            // Set up how many turnovers our wheel should make before stop
            _finalAngle = fullTurnovers * 360 + randomNumber;

            // Stop the wheel
            _isStarted = true;

        }



        private void Update()
        {
            if (!_isStarted)
            {
                _cooldownTime += Time.deltaTime;
                if (_cooldownTime > 4f)
                {
                    SetWheel();
                }
            }
            else
            {
                StartNormalRotation();
            }
        }

        private void StartNormalRotation()
        {
            // Animation time
            float maxLerpRotationTime = 7f;

            // increment animation timer once per frame
            _currentLerpRotationTime += Time.deltaTime;

            // If the end of animation
            if (_currentLerpRotationTime > maxLerpRotationTime || Circle.transform.eulerAngles.z == _finalAngle)
            {
                _currentLerpRotationTime = maxLerpRotationTime;
                _isStarted = false;
                _startAngle = _finalAngle % 360;
            }
            else
            {
                // Calculate current position using linear interpolation
                float t = _currentLerpRotationTime / maxLerpRotationTime;

                // This formulae allows to speed up at start and speed down at the end of rotation.
                // Try to change this values to customize the speed
                t = t * t * t * (t * (6f * t - 15f) + 10f);

                float angle = Mathf.Lerp(_startAngle, _finalAngle, t);
                Circle.transform.eulerAngles = new Vector3(0, 0, angle);
            }
        }
    }
}