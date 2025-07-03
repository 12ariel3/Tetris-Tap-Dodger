using Assets.Code.Common.Events;
using Assets.Code.Common.SwordsData;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using Assets.Code.RecyclableObjects.DebuffParticles;
using Assets.Code.RecyclableObjects.HitParticles;
using UnityEngine;

namespace Assets.Code.RecyclableObjects
{
    public class ParticleSpawner : MonoBehaviour, EventObserver
    {
        private ExplosionParticleSystemFactory _explosionFactory;
        private HitParticleSystemFactory _hitFactory;
        private DebuffParticleSystemFactory _debuffFactory;
        private string _swordEquippedId;

        private Transform _playerTransform;
        private bool _isFireActivated;
        private bool _isPoisonActivated;
        private bool _isIceActivated;
        private bool _isWaterActivated;
        private bool _isElectricActivated;
        private bool _isGhostActivated;
        private bool _isRainbowActivated;


        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.ProjectileDestroyed, this);
            eventQueue.Subscribe(EventIds.ProjectileHitted, this);
            eventQueue.Subscribe(EventIds.DebuffActivated, this);
            eventQueue.Subscribe(EventIds.DebuffDeactivated, this);
            eventQueue.Subscribe(EventIds.ContinueBattleAfterAds, this);
            eventQueue.Subscribe(EventIds.PlayerSpamedAndSendHisTransform, this);
            _explosionFactory = ServiceLocator.Instance.GetService<ExplosionParticleSystemFactory>();
            _hitFactory = ServiceLocator.Instance.GetService<HitParticleSystemFactory>();
            _debuffFactory = ServiceLocator.Instance.GetService<DebuffParticleSystemFactory>();
            _swordEquippedId = ServiceLocator.Instance.GetService<SwordEquippedSystem>().GetSwordEquipped();
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.ProjectileDestroyed, this);
            eventQueue.Unsubscribe(EventIds.ProjectileHitted, this);
            eventQueue.Unsubscribe(EventIds.DebuffActivated, this);
            eventQueue.Unsubscribe(EventIds.DebuffDeactivated, this);
            eventQueue.Unsubscribe(EventIds.ContinueBattleAfterAds, this);
            eventQueue.Unsubscribe(EventIds.PlayerSpamedAndSendHisTransform, this);
        }


        private void SpawnExplosion(string projectileId, Vector3 position, Quaternion rotation)
        {
            
            var particleBuilder = _explosionFactory.Create(projectileId);
            particleBuilder.WithPosition(position)
                           .WithRotation(rotation)
                           .Build();
        }

        private void SpawnHit(Vector3 position, Quaternion rotation)
        {
            var particleBuilder = _hitFactory.Create(_swordEquippedId);
            particleBuilder.WithPosition(position)
                           .WithRotation(rotation)
                           .Build();
        }

        private void SpawnDebuff(string debuffName)
        {
            var particleBuilder = _debuffFactory.Create(debuffName);
            particleBuilder.WithPosition(Vector3.zero)
                           .WithRotation(Quaternion.identity)
                           .WithTransform(_playerTransform)
                           .Build();
        }

        private void FilterAndSaveWhichDebuffIsActivated(string Name)
        {
            switch (Name)
            {
                case "Fire":
                    _isFireActivated = true;
                    return;

                case "Poison":
                    _isPoisonActivated = true;
                    return;

                case "Ice":
                    _isIceActivated = true;
                    return;

                case "Water":
                    _isWaterActivated = true;
                    return;

                case "Electric":
                    _isElectricActivated = true;
                    return;

                case "Ghost":
                    _isGhostActivated = true;
                    return;

                case "Rainbow":
                    _isRainbowActivated = true;
                    return;
            }
        }

        private void FilterAndSaveWhichDebuffIsDeactivated(string Name)
        {
            switch (Name)
            {
                case "Fire":
                    _isFireActivated = false;
                    return;

                case "Poison":
                    _isPoisonActivated = false;
                    return;

                case "Ice":
                    _isIceActivated = false;
                    return;

                case "Water":
                    _isWaterActivated = false;
                    return;

                case "Electric":
                    _isElectricActivated = false;
                    return;

                case "Ghost":
                    _isGhostActivated = false;
                    return;

                case "Rainbow":
                    _isRainbowActivated = false;
                    return;
            }
        }


        private bool GetIfDebuffIsActivated(string Name)
        {
            switch (Name)
            {
                case "Fire":
                    return _isFireActivated;

                case "Poison":
                    return _isPoisonActivated;

                case "Ice":
                    return _isIceActivated;

                case "Water":
                    return _isWaterActivated;

                case "Electric":
                    return _isElectricActivated;

                case "Ghost":
                    return _isGhostActivated;

                case "Rainbow":
                    return _isRainbowActivated;
            }
            return true;
        }

        private void TurnOffAllDebuffs()
        {
            _isFireActivated = false;
            _isPoisonActivated = false;
            _isIceActivated = false;
            _isWaterActivated = false;
            _isElectricActivated = false;
            _isGhostActivated = false;
            _isRainbowActivated = false;
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ProjectileDestroyed)
            {
                var projectileDestroyedEventData = (ProjectileDestroyedEventData)eventData;
                if (projectileDestroyedEventData.IsInsideCheckLimits)
                {
                    SpawnExplosion(projectileDestroyedEventData.ProjectileColorAndTypeString,
                               projectileDestroyedEventData.ProjectilePosition,
                               projectileDestroyedEventData.ProjectileRotation);
                }
                return;
            }

            if (eventData.EventId == EventIds.ProjectileHitted)
            {
                var projectileHittedEventData = (ProjectileHittedEventData)eventData;
                SpawnHit(projectileHittedEventData.Position, projectileHittedEventData.Rotation);
            }
            
            
            if (eventData.EventId == EventIds.DebuffActivated)
            {
                var debuffActivatedEventData = (DebuffActivatedEventData)eventData;
                bool isDebuffActivated = GetIfDebuffIsActivated(debuffActivatedEventData.DebuffName);
                if (!isDebuffActivated) 
                {
                    FilterAndSaveWhichDebuffIsActivated(debuffActivatedEventData.DebuffName);
                    SpawnDebuff(debuffActivatedEventData.DebuffName);
                    ServiceLocator.Instance.GetService<AudioManager>().PlayProjectile(debuffActivatedEventData.DebuffName + "Debuff");

                }
            }

            if (eventData.EventId == EventIds.DebuffDeactivated)
            {
                var debuffDeactivatedEventData = (DebuffDeactivatedEventData)eventData;
                FilterAndSaveWhichDebuffIsDeactivated(debuffDeactivatedEventData.DebuffName);
            }
            
            if (eventData.EventId == EventIds.ContinueBattleAfterAds)
            {
                TurnOffAllDebuffs();
            }

            if (eventData.EventId == EventIds.PlayerSpamedAndSendHisTransform)
            {
                var playerSpamedAndSendHisTransform = (PlayerSpamedAndSendHisTransformEventData)eventData;
                _playerTransform = playerSpamedAndSendHisTransform.PlayerTransform;
            }
            
        }
    }
}