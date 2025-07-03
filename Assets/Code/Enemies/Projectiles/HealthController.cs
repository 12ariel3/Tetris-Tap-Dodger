using Assets.Code.Common.Events;
using Assets.Code.Core;
using Assets.Code.Enemies.Projectiles.Common;
using UnityEngine;

namespace Assets.Code.Enemies.Projectiles
{
    public class HealthController : MonoBehaviour, Damageable
    {
        private Projectile _projectile;
        private int _currentHp;

        private Vector3 _spawnPopUpPosition;
    

        public void Configure(Projectile projectile, int level, int maxHp)
        {
            _projectile = projectile;
            _currentHp = Mathf.FloorToInt((maxHp * (level / 2) + 1));
        }


        public void AddDamage(int attack)
        {
            DoNormalDamage(attack);
            return;
        }


        private void DoNormalDamage(int attack)
        {
            int finalAmount = (int)(attack * Random.Range(0.8f, 1.2f));

            var damagePopUpEventData = new DamagePopUpEventData("Normal", finalAmount, _spawnPopUpPosition, GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(damagePopUpEventData);

            ApplyDamage(finalAmount);
        }


        private void ApplyDamage(int finalAmount)
        {
            _currentHp = Mathf.Max(0, (_currentHp - finalAmount));
            var isDeath = _currentHp <= 0;
            _projectile.OnDamageReceived(isDeath);
        }


        public void SetSpawnPopUpPosition(Vector3 spawnPosition)
        {
            _spawnPopUpPosition = spawnPosition;
        }
    }
}