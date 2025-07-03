using Assets.Code.Common;
using System.Collections.Generic;

namespace Assets.Code.RecyclableObjects.PopUps.LvlUpPopUp
{
    public class LvlUpPopUpFactory
    {
        private readonly LvlUpPopUpConfiguration _configuration;
        private readonly Dictionary<string, ObjectPool> _pools;

        public LvlUpPopUpFactory(LvlUpPopUpConfiguration configuration)
        {
            _configuration = configuration;
            var prefabs = _configuration.LvlUpPrefabs;
            _pools = new Dictionary<string, ObjectPool>(prefabs.Length);

            foreach (var lvlUpPopUpMediator in prefabs)
            {
                var objectPool = new ObjectPool(lvlUpPopUpMediator);
                objectPool.Init(1);
                _pools.Add(lvlUpPopUpMediator.Id, objectPool);
            }
        }

        public LvlUpPopUpBuilder Create(string id)
        {
            var objectPool = _pools[id];

            return new LvlUpPopUpBuilder().FromObjectPool(objectPool);
        }
    }
}