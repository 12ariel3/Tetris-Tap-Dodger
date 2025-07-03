using System.Collections;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.UIElements;

namespace Assets.Code.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        private RectTransform _limitLeft;
        private RectTransform _limitRight;
        private bool _rectTransformSent;
        private bool _isGoingRight;
        private bool _isGoingLeft;
        private bool _itouchedLastFrame;

        private float _speed = 5;
        private float _originalSpeed = 5;

        [SerializeField] Rigidbody2D _rb2D;

        private bool _iceDebuffIsActive;
        private bool _rainbowDebuffIsActive;
        private float _rainbowNextChangeDirection;

        private float _radius = .1f; // Radio del círculo
        private float _angle = 0f; // Ángulo actual
        private float _aspectRatio;
        private float _cameraHeight;
        private float _cameraWidth;
        private float _radiusPercentage = 0.3f; // por ejemplo, 30% del tamaño visible

        private void Start()
        {
            _isGoingRight = true;
            SetRadiusSize();
        }

        private void SetRadiusSize()
        {
            _aspectRatio = (float)Screen.width / Screen.height;
            _cameraHeight = Camera.main.orthographicSize * 2;
            _cameraWidth = _cameraHeight * _aspectRatio;
            _radius = _cameraWidth * _radiusPercentage;
        }

        public void ConfigureMovement(float currentLevelSpeed)
        {
            _originalSpeed = 5 + (currentLevelSpeed / 5);
            _speed = _originalSpeed * (_originalSpeed/10);
        }

        public void SetLimitPositions(RectTransform leftLimitTransform, RectTransform rightLimitTransform)
        {
            _limitLeft = leftLimitTransform;
            _limitRight = rightLimitTransform;
            _rectTransformSent = true;
        }

        public void PlayerMovement()
        {
            if (_iceDebuffIsActive)
            {
                return;
            }
            else
            {
                _rb2D.MovePosition(new Vector2(_rb2D.transform.position.x + _speed * Time.deltaTime,
                                                           _rb2D.transform.position.y));


                if (_rectTransformSent)
                {
                    if (_rb2D.transform.position.x >= _limitRight.transform.position.x && _isGoingRight)
                    {
                        ChangeDirection();
                    }

                    if (_rb2D.transform.position.x <= _limitLeft.transform.position.x && _isGoingLeft)
                    {
                        ChangeDirection();

                    }
                }


                if (_rainbowDebuffIsActive)
                {
                    if (_rainbowNextChangeDirection > 0)
                    {
                        _rainbowNextChangeDirection -= Time.deltaTime;
                    }
                    else
                    {
                        ChangeDirection();
                        float nextCooldownToChangeDirection = Random.Range(0.3f, 1.8f);
                        _rainbowNextChangeDirection = nextCooldownToChangeDirection;
                    }
                }
            }
        }

        public void PlayerMovement2()
        {
            if (_iceDebuffIsActive)
            {
                return;
            }
            else
            {
                //_rb2D.MovePosition(new Vector2(_rb2D.transform.position.x + _speed * Time.deltaTime,
                //                               _rb2D.transform.position.y + _speed * Time.deltaTime));
                //_currentPosition += _myTransform.up * (0 * Time.deltaTime);
                //_horizontalPosition = _myTransform.right * (_amplitude * Mathf.Sin(_currentTime * _frequency));
                //_verticalPosition = _myTransform.up * -(_amplitude * Mathf.Sin(_currentTime * _frequency));
                //_rb2D.MovePosition(_horizontalPosition + _verticalPosition);

                //_currentTime += Time.deltaTime;

                _angle += _speed * Time.fixedDeltaTime; 
                float x = 0 + _radius * Mathf.Cos(_angle);
                float y = -2 + (_radius) * Mathf.Sin(_angle);
                _rb2D.MovePosition(new Vector2(x, y));

                //if (_rectTransformSent)
                //{
                //    if (_rb2D.transform.position.x >= _limitRight.transform.position.x && _isGoingRight)
                //    {
                //        ChangeDirection();
                //    }

                //    if (_rb2D.transform.position.x <= _limitLeft.transform.position.x && _isGoingLeft)
                //    {
                //        ChangeDirection();

                //    }
                //}


                if (_rainbowDebuffIsActive)
                {
                    if (_rainbowNextChangeDirection > 0)
                    {
                        _rainbowNextChangeDirection -= Time.deltaTime;
                    }
                    else
                    {
                        ChangeDirection();
                        float nextCooldownToChangeDirection = Random.Range(0.3f, 1.8f);
                        _rainbowNextChangeDirection = nextCooldownToChangeDirection;
                    }
                }
            }
        }

        private void ChangeDirection()
        {
            _speed = -_speed;
            _isGoingRight = !_isGoingRight;
            _isGoingLeft = !_isGoingLeft;
        }


        public void GetIfTheScreenIsTouched()
        {
            if (Input.touchCount > 0)
            {

                UnityEngine.Touch touch = Input.GetTouch(0);


                if (touch.phase == TouchPhase.Began)
                {
                    ChangeDirection();
                }
            }
        }


        public void PlayerStopMovement()
        {
            _rb2D.linearVelocity = Vector2.zero;
        }

        IEnumerator IceDebuff()
        {
            yield return new WaitForSeconds(6);
            _iceDebuffIsActive = false;
            yield return null;
        }

        IEnumerator RainbowDebuff()
        {
            yield return new WaitForSeconds(15);
            _rainbowDebuffIsActive = false;
            _rainbowNextChangeDirection = 0;
            yield return null;
        }

        public void StopAllDebuffCoroutines()
        {
            StopAllCoroutines();
            _iceDebuffIsActive = false;
            _rainbowDebuffIsActive = false;
        }

        public void FilterAndStartCoroutine(string debuffName)
        {
            switch (debuffName)
            {
                case "Ice":
                    if (!_iceDebuffIsActive)
                    {
                        _iceDebuffIsActive = true;
                        StartCoroutine(IceDebuff());
                    }
                    return;

                case "Rainbow":
                    if (!_rainbowDebuffIsActive)
                    {
                        _rainbowDebuffIsActive = true;
                        StartCoroutine(RainbowDebuff());
                    }
                    return;
            }
        }
    }
}