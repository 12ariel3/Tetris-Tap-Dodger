using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Code.Enemies.Projectiles
{
    [CreateAssetMenu(menuName = "Projectile/ProjectilesConfiguration", fileName = "ProjectilesConfiguration")]
    public class ProjectilesConfiguration : ScriptableObject
    {
        [SerializeField] private ProjectileMediator[] _projectilePrefabs;
        private Dictionary<string, ProjectileMediator> _idToProjectilePrefab;
        [SerializeField] private MapId _id;

        public string Id => _id.Value;
        public ProjectileMediator[] ProjectilePrefabs => _projectilePrefabs;

        private void Awake()
        {
            _idToProjectilePrefab = new Dictionary<string, ProjectileMediator>();
            foreach (var projectile in _projectilePrefabs)
            {
                _idToProjectilePrefab.Add(projectile.Id, projectile);
            }
        }


        public ProjectileMediator GetProjectileById(string id)
        {
            if (!_idToProjectilePrefab.TryGetValue(id, out var projectile))
            {
                throw new Exception($"Projectile {id} not found");
            }

            return projectile;
        }
    }
}