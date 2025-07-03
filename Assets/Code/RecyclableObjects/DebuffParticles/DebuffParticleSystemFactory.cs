using Assets.Code.Common;
using System.Collections.Generic;

namespace Assets.Code.RecyclableObjects.DebuffParticles
{
    public class DebuffParticleSystemFactory
    {
        private readonly DebuffParticlesSystemConfiguration _configuration;
        private readonly Dictionary<string, ObjectPool> _pools;


        public DebuffParticleSystemFactory(DebuffParticlesSystemConfiguration configuration)
        {
            _configuration = configuration;
            var prefabs = _configuration.DebuffPrefabs;
            _pools = new Dictionary<string, ObjectPool>(prefabs.Length);

            foreach (var bloodyMediator in prefabs)
            {
                var objectPool = new ObjectPool(bloodyMediator);
                objectPool.Init(1);
                _pools.Add(bloodyMediator.Id, objectPool);
            }
        }

        public DebuffParticleBuilder Create(string id)
        {
            var objectPool = _pools[id];

            return new DebuffParticleBuilder().FromObjectPool(objectPool);
        }
    }
}