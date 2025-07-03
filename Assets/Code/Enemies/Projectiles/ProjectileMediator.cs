using Assets.Code.Common;
using Assets.Code.Common.Events;
using Assets.Code.Core;
using Assets.Code.Enemies.CheckDestroyLimitss;
using Assets.Code.Enemies.Projectiles.Common;
using Assets.Code.MusicAndSound;
using DG.Tweening;
using UnityEngine;

namespace Assets.Code.Enemies.Projectiles
{
    public class ProjectileMediator : RecyclableObject, Projectile, EventObserver
    {
        [SerializeField] private ProjectileMovementController _movementController;
        [SerializeField] private ProjectileColorAndTypeController _colorAndTypeController;
        [SerializeField] private HealthController _healthController;

        [SerializeField] private ProjectileId _projectileId;

        public string Id => _projectileId.Value;

        private string _explosionName;
        private int _playerAttack;
        private int _score;
        private int _gems;
        private int _gemsProbability;
        private int _experience;
        private int _attack;
        private float _speed;
        private CheckDestroyLimits _checkDestroyLimits;
        private bool _isSpecial;
        private bool _gameOver;
        private bool _pause;
        private bool _deathOnce;
        private bool _victory;
        private bool _isalreadyCollided;

        internal override void Init()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.GameOver, this);
            eventQueue.Subscribe(EventIds.Victory, this);
            eventQueue.Subscribe(EventIds.PausePressed, this);
            eventQueue.Subscribe(EventIds.PlayerDestroyed, this);
            eventQueue.Subscribe(EventIds.ContinueBattleAfterAds, this);
            eventQueue.Subscribe(EventIds.LastProjectileAlive, this);
            _deathOnce = false;
            _isalreadyCollided = false;
        }

        internal override void Release()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.GameOver, this);
            eventQueue.Unsubscribe(EventIds.Victory, this);
            eventQueue.Unsubscribe(EventIds.PausePressed, this);
            eventQueue.Unsubscribe(EventIds.PlayerDestroyed, this);
            eventQueue.Unsubscribe(EventIds.ContinueBattleAfterAds, this);
            eventQueue.Unsubscribe(EventIds.LastProjectileAlive, this);
            _deathOnce = false;
        }


        public void Configure(ProjectileConfiguration configuration)
        {
            _checkDestroyLimits = configuration.CheckDestroyLimits;
            _speed = configuration.ProjectileSpeed;
            _movementController.Configure(_speed);
            _healthController.Configure(this, configuration.Level, configuration.MaxHp);
            _score = Mathf.FloorToInt((configuration.Score * configuration.Level) / 7);
            _gems = Mathf.FloorToInt(((configuration.Gems * configuration.Level) / 7) + 1);
            _gemsProbability = configuration.GemsProbability;
            _experience = Mathf.FloorToInt((configuration.Experience * configuration.Level));
            _attack = Mathf.FloorToInt(configuration.Attack * configuration.Level); ;
            _explosionName = configuration.ExplosionName;
            _isSpecial = configuration.IsSpecial;
            _colorAndTypeController.Configure(configuration.ColorAndType);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_gameOver && !_victory)
            {
                if (!_pause)
                {
                    DoOneAttack(other);
                }
            }
        }



        private void DoOneAttack(Collider2D collider)
        {
            if (collider.tag == "Player")
            {
                if (!_isalreadyCollided)
                {
                    _isalreadyCollided = true;
                    AttackPlayer();
                }
            }
            if(collider.tag == "Bullet")
            {
                var transformPositionPlusOneOnZ = transform.position;
                transformPositionPlusOneOnZ.z = transformPositionPlusOneOnZ.z - 3;
                var projectileHittedEventData = new ProjectileHittedEventData(transformPositionPlusOneOnZ, transform.rotation,
                                                                              GetInstanceID());
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(projectileHittedEventData);
                _healthController.SetSpawnPopUpPosition(transform.position);
                _healthController.AddDamage(_playerAttack);
            }
            else
            {
                //_healthController.AddDamage(1000000);
            }
        }


        private void Update()
        {
            if (!_gameOver && !_victory)
            {
                CheckDestroyLimits();
            }
        }


        private void CheckDestroyLimits()
        {

            if (_checkDestroyLimits.IsInsideTheLimits(transform.position))
            {
                return;
            }

            Destroy();
        }

        private void FixedUpdate()
        {
            if (!_gameOver && !_victory)
            {
                if (!_pause)
                {
                    _movementController.RocketMovement();
                }
            }
        }

        private void AttackPlayer()
        {
            _deathOnce = true;
            ProjectileDestroyedEventData projectileDestroyedEventData;

            if (_isSpecial)
            {
                projectileDestroyedEventData = new ProjectileDestroyedEventData(0, 0, 0, 0, 0, Id, transform.position,
                                                                                    transform.rotation, true,
                                                                                    _colorAndTypeController._colorAndTypeString, 
                                                                                    GetInstanceID());
            }
            else
            {
                var attack = (int)(_attack * Random.Range(0.8f, 1.2f));
                projectileDestroyedEventData = new ProjectileDestroyedEventData(0, 0, 0, 0, attack, Id, transform.position,
                                                                                    transform.rotation, true,
                                                                                    _colorAndTypeController._colorAndTypeString,
                                                                                    GetInstanceID());
                //string randomString = Random.Range(1, 2).ToString();
                //ServiceLocator.Instance.GetService<AudioManager>().PlayProjectile("Damage" + randomString);
                DOTween.Sequence().Insert(0, Camera.main.DOShakePosition(0.4f, 0.6f, 2000));
            }

            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(projectileDestroyedEventData);
            ServiceLocator.Instance.GetService<AudioManager>().PlayProjectile(_explosionName);
            Recycle();
        }

        public void OnDamageReceived(bool isDeath)
        {
            if (isDeath)
            {
                if (!_deathOnce)
                {
                    Destroy();
                }
            }
        }

        public void Destroy()
        {
            _deathOnce = true;
            var projectileDestroyedEventData = new ProjectileDestroyedEventData(_score, _gems, _gemsProbability, _experience, 0, Id,
                                                                            transform.position, transform.rotation, false,
                                                                            _colorAndTypeController._colorAndTypeString,
                                                                            GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(projectileDestroyedEventData);

            if (_isSpecial)
            {
                VerifyWhichSpecialIsAndDoTheSpecialAbility();
            }

            Recycle();
        }



        public void VerifyWhichSpecialIsAndDoTheSpecialAbility()
        {
            switch (Id)
            {
                case "Good":
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.GoodSpecialProjectileDestroyed));
                    return;
                case "IceExplosion":
                    DOTween.Sequence().Insert(0, Camera.main.DOShakePosition(1f, 1f, 2000));
                    return;
                case "Bad":
                    return;
                case "Time":
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.TimeSpecialProjectileWasActivated));
                    return;
            }
        }


        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.PausePressed)
            {
                if (_pause == true)
                {
                    _pause = false;
                }
                else
                {
                    _pause = true;
                }
            }

            if (eventData.EventId == EventIds.PlayerDestroyed)
            {
                _movementController.StopProjectileMovement();
                _gameOver = true;
            }

            if (eventData.EventId == EventIds.ContinueBattleAfterAds)
            {
                _gameOver = false;
                _movementController.ContinueProjectileMovement();
            }

            if (eventData.EventId == EventIds.Victory)
            {
                _victory = true;
                Recycle();
            }

            if (eventData.EventId == EventIds.GameOver)
            {
                _gameOver = true;
            }
        }
    }
}