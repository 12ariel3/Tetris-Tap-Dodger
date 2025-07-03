using Assets.Code.Common.Events;
using Assets.Code.Core;
using Assets.Code.Enemies.Projectiles.Common;
using System.Collections;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerHealthController : MonoBehaviour, Damageable
    {

        private PlayerMediator _playerMediator;
        private int _maxHp;
        private int _currentHp;
        private bool _isBlooding;
        private int _bloodyPercentageToActivate = 15;

        private bool _fireDebuffIsActive; 
        private bool _poisonDebuffIsActive; 
        private bool _electricDebuffIsActive; 

        public void Configure(PlayerMediator playerMediator, int maxHp)
        {
            _playerMediator = playerMediator;
            _maxHp = maxHp;
            _currentHp = _maxHp;

            var playerMaxHealthChangedEventData = new PlayerMaxHealthChangedEventData(_maxHp, GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(playerMaxHealthChangedEventData);
        }


        public void AddDamage(int amount)
        {
            if(_electricDebuffIsActive)
            {
                amount = (int)(amount * 1.2);
            }

            _currentHp = Mathf.Max(0, _currentHp - amount);

            if (_currentHp <= (_maxHp * _bloodyPercentageToActivate) / 100)
            {
                _isBlooding = true;
            }
            else
            {
                _isBlooding = false;
            }

            var playerHealthChangedEventData = new PlayerHealthChangedEventData(_currentHp, _isBlooding, GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(playerHealthChangedEventData);

            var isDeath = _currentHp <= 0;
            _playerMediator.OnDamageReceived(isDeath);
        }


        public void AddHealing(int amount)
        {
            _currentHp = Mathf.Min(_maxHp, _currentHp + amount);

            if (_currentHp <= (_maxHp * _bloodyPercentageToActivate) / 100)
            {
                _isBlooding = true;
            }
            else
            {
                _isBlooding = false;
            }

            var playerHealthChangedEventData = new PlayerHealthChangedEventData(_currentHp, _isBlooding, GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(playerHealthChangedEventData);
        }

        public void AddGoodSpecialProjectileHealing()
        {
            int amount;
            if (_maxHp <= 300)
            {
                amount = _maxHp / 5;
            }
            else if (_maxHp > 300 && _maxHp <= 800)
            {
                amount = _maxHp / 6;
            }
            else if (_maxHp > 800 && _maxHp <= 1500)
            {
                amount = _maxHp / 7;
            }
            else
            {
                amount = _maxHp / 8;
            }

            _currentHp = Mathf.Min(_maxHp, _currentHp + amount);

            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            var hpPopUpEventData = new HpPopUpEventData(amount, GetInstanceID());
            eventQueue.EnqueueEvent(hpPopUpEventData);

            if (_currentHp <= (_maxHp * _bloodyPercentageToActivate) / 100)
            {
                _isBlooding = true;
            }
            else
            {
                _isBlooding = false;
            }

            var playerHealthChangedEventData = new PlayerHealthChangedEventData(_currentHp, _isBlooding, GetInstanceID());
            eventQueue.EnqueueEvent(playerHealthChangedEventData);
        }

        public void SetLevelUpNewHealthValues(int newMaxHealth)
        {
            _maxHp = newMaxHealth;
            _currentHp = _maxHp;
            _isBlooding = false;
        }

        IEnumerator FireDebuff()
        {
            int duration = 0;
            int amountToRest = (int)(_maxHp / 100);

            while (duration < 10)
            {
                AddDamage(amountToRest);
                duration++;
                yield return new WaitForSeconds(1);
            }
            _fireDebuffIsActive = false;
            yield return null;
        }


        IEnumerator PoisonDebuff()
        {
            int duration = 0;
            int amountToRest = (int)(_maxHp / 30);

            while (duration < 5)
            {
                AddDamage(amountToRest);
                duration++;
                yield return new WaitForSeconds(4);
            }
            _poisonDebuffIsActive = false;
            yield return null;
        }

        IEnumerator ElectricDebuff()
        {
            yield return new WaitForSeconds(18);
            _electricDebuffIsActive = false;
            yield return null;
        }

        public void StopAllDebuffCoroutines()
        {
            StopAllCoroutines();
            _fireDebuffIsActive = false;
            _poisonDebuffIsActive = false;
            _electricDebuffIsActive = false;
        }

        public void FilterAndStartCoroutine(string debuffName)
        {
            switch (debuffName)
            {
                case "Fire":
                    if (!_fireDebuffIsActive)
                    {
                        _fireDebuffIsActive = true;
                        StartCoroutine(FireDebuff());
                    }
                    return;

                case "Poison":
                    if (!_poisonDebuffIsActive)
                    {
                        _poisonDebuffIsActive = true;
                        StartCoroutine(PoisonDebuff());
                    }
                    return;

                case "Electric":
                    if (!_electricDebuffIsActive)
                    {
                        _electricDebuffIsActive = true;
                        StartCoroutine(ElectricDebuff());
                    }
                    return;
            }
        }
    }
}