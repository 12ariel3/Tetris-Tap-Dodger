using UnityEngine;

namespace Assets.Code.Enemies.Projectiles
{
    public class ProjectileMovementController : MonoBehaviour
    {

        private float _speed;


        [SerializeField] private Rigidbody2D _rb2D;

        public void Configure(float speed)
        {
            _speed = speed;
        }

        public void RocketMovement()
        {
            _rb2D.linearVelocity = new Vector2(0, -_speed);
        }

        public void StopProjectileMovement()
        {
            if (_rb2D != null)
            {
                _rb2D.linearVelocity = Vector3.zero;
            }
        }

        public void ContinueProjectileMovement()
        {
            if (_rb2D != null)
            {
                _rb2D.isKinematic = false;
            }
        }
    }
}