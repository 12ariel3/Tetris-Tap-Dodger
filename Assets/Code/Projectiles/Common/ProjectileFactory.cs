using Assets.Code.Common;
using Assets.Code.Enemies.Projectiles;
using Assets.Code.Enemies.Projectiles.Common;
using System.Collections.Generic;

namespace Assets.Code.Projectiles.Common
{
    public class ProjectileFactory
    {
        private readonly ProjectilesConfiguration _configuration;
        private readonly Dictionary<string, ObjectPool> _pools;


        public ProjectileFactory(ProjectilesConfiguration configuration)
        {
            _configuration = configuration;
            var prefabs = _configuration.ProjectilePrefabs;
            _pools = new Dictionary<string, ObjectPool>(prefabs.Length);

            foreach (var projectileMediator in prefabs)
            {
                var objectPool = new ObjectPool(projectileMediator);
                objectPool.Init(4);
                _pools.Add(projectileMediator.Id, objectPool);
            }
        }

        public ProjectileBuilder Create(string id)
        {
            var objectPool = _pools[id];

            return new ProjectileBuilder().FromObjectPool(objectPool);
        }
    }
}