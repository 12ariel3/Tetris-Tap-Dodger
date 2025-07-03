using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class PlayerMovementView : MonoBehaviour
    {
        [SerializeField] float _speed;
        [SerializeField] RectTransform _limitLeft;
        [SerializeField] RectTransform _limitRight;
        [SerializeField] Image _playerSprite;



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
    }
}