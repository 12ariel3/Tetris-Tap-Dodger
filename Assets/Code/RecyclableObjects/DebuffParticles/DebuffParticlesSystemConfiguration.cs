using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.DebuffParticles
{
    [CreateAssetMenu(menuName = "Projectile/DebuffParticlesSystemConfiguration", fileName = "DebuffParticlesSystemConfiguration")]
    public class DebuffParticlesSystemConfiguration : ScriptableObject
    {
        [SerializeField] private DebuffParticleSystemMediator[] _debuffPrefabs;
        private Dictionary<string, DebuffParticleSystemMediator> _idToDebuffPrefab;

        public DebuffParticleSystemMediator[] DebuffPrefabs => _debuffPrefabs;



        private void Awake()
        {
            _idToDebuffPrefab = new Dictionary<string, DebuffParticleSystemMediator>();
            foreach (var hit in _debuffPrefabs)
            {
                _idToDebuffPrefab.Add(hit.Id, hit);
            }
        }


        public DebuffParticleSystemMediator GetProjectileById(string id)
        {
            if (!_idToDebuffPrefab.TryGetValue(id, out var hit))
            {
                throw new Exception($"Debuff {id} not found");
            }

            return hit;
        }
    }
}