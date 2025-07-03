using Assets.Code.Common;
using System.Collections.Generic;

namespace Assets.Code.RecyclableObjects.PopUps.HpPopUp
{
    public class HpPopUpFactory
    {
        private readonly HpPopUpConfiguration _configuration;
        private readonly Dictionary<string, ObjectPool> _pools;

        public HpPopUpFactory(HpPopUpConfiguration configuration)
        {
            _configuration = configuration;
            var prefabs = _configuration.HpPrefabs;
            _pools = new Dictionary<string, ObjectPool>(prefabs.Length);

            foreach (var hpPopUpMediator in prefabs)
            {
                var objectPool = new ObjectPool(hpPopUpMediator);
                objectPool.Init(4);
                _pools.Add(hpPopUpMediator.Id, objectPool);
            }
        }

        public HpPopUpBuilder Create(string id)
        {
            var objectPool = _pools[id];

            return new HpPopUpBuilder().FromObjectPool(objectPool);
        }
    }
}