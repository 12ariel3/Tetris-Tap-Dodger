using Assets.Code.Common;
using Assets.Code.Common.SwordsData;
using Assets.Code.Core;
using System.Collections.Generic;

namespace Assets.Code.RecyclableObjects.HitParticles
{
    public class HitParticleSystemFactory
    {
        private readonly HitParticlesSystemConfiguration _configuration;
        private readonly Dictionary<string, ObjectPool> _pools;


        public HitParticleSystemFactory(HitParticlesSystemConfiguration configuration)
        {
            _configuration = configuration;
            var prefabs = _configuration.HitPrefabs;
            _pools = new Dictionary<string, ObjectPool>(prefabs.Length);

            string swordEquipped = ServiceLocator.Instance.GetService<SwordEquippedSystem>().GetSwordEquipped();
            foreach (var particleMediator in prefabs)
            {
                if (swordEquipped == particleMediator.Id)
                {
                    var objectPool = new ObjectPool(particleMediator);
                    objectPool.Init(8);
                    _pools.Add(particleMediator.Id, objectPool);
                }
            }
        }

        public ParticleBuilder Create(string id)
        {
            var objectPool = _pools[id];

            return new ParticleBuilder().FromObjectPool(objectPool);
        }
    }
}