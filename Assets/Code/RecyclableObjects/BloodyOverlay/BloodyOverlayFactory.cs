using Assets.Code.Common;
using System.Collections.Generic;

namespace Assets.Code.RecyclableObjects.BloodyOverlay
{
    public class BloodyOverlayFactory
    {
        private readonly BloodyOverlayConfiguration _configuration;
        private readonly Dictionary<string, ObjectPool> _pools;


        public BloodyOverlayFactory(BloodyOverlayConfiguration configuration)
        {
            _configuration = configuration;
            var prefabs = _configuration.BloodyPrefabs;
            _pools = new Dictionary<string, ObjectPool>(prefabs.Length);

            foreach (var bloodyMediator in prefabs)
            {
                var objectPool = new ObjectPool(bloodyMediator);
                objectPool.Init(1);
                _pools.Add(bloodyMediator.Id, objectPool);
            }
        }

        public BloodyOverlayBuilder Create(string id)
        {
            var objectPool = _pools[id];

            return new BloodyOverlayBuilder().FromObjectPool(objectPool);
        }
    }
}