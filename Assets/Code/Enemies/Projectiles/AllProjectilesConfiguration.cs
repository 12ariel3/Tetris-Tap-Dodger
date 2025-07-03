using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Code.Enemies.Projectiles
{
    [CreateAssetMenu(menuName = "Projectile/AllProjectilesConfiguration", fileName = "AllProjectilesConfiguration")]
    public class AllProjectilesConfiguration : ScriptableObject
    {
        [SerializeField] private ProjectilesConfiguration[] _projectilesConfiguration;
        private Dictionary<string, ProjectilesConfiguration> _idToProjectilesConfiguration;

        public ProjectilesConfiguration[] ProjectilesConfiguration => _projectilesConfiguration;

        private void Awake()
        {
            _idToProjectilesConfiguration = new Dictionary<string, ProjectilesConfiguration>();
            foreach (var projectileConfiguration in _projectilesConfiguration)
            {
                _idToProjectilesConfiguration.Add(projectileConfiguration.Id, projectileConfiguration);
            }
        }


        public ProjectilesConfiguration GetProjectileConfigurationById(string id)
        {
            if (!_idToProjectilesConfiguration.TryGetValue(id, out var projectileConfiguration))
            {
                throw new Exception($"ProjectileConfiguration {id} not found");
            }

            return projectileConfiguration;
        }
    }
}