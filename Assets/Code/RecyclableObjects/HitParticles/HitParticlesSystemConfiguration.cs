using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.HitParticles
{
    [CreateAssetMenu(menuName = "Projectile/HitParticlesSystemConfiguration", fileName = "HitParticlesSystemConfiguration")]
    public class HitParticlesSystemConfiguration : ScriptableObject
    {
        [SerializeField] private ParticleSystemMediator[] _hitPrefabs;
        private Dictionary<string, ParticleSystemMediator> _idToHitPrefab;

        public ParticleSystemMediator[] HitPrefabs => _hitPrefabs;



        private void Awake()
        {
            _idToHitPrefab = new Dictionary<string, ParticleSystemMediator>();
            foreach (var hit in _hitPrefabs)
            {
                _idToHitPrefab.Add(hit.Id, hit);
            }
        }


        public ParticleSystemMediator GetProjectileById(string id)
        {
            if (!_idToHitPrefab.TryGetValue(id, out var hit))
            {
                throw new Exception($"Hit {id} not found");
            }

            return hit;
        }
    }
}