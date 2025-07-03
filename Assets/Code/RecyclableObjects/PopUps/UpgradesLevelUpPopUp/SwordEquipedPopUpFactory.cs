using Assets.Code.Common;
using System.Collections.Generic;

namespace Assets.Code.RecyclableObjects.PopUps.UpgradesLevelUpPopUp
{
    public class SwordEquipedPopUpFactory
    {
        private readonly SwordEquipedPopUpConfiguration _configuration;
        private readonly Dictionary<string, ObjectPool> _pools;


        public SwordEquipedPopUpFactory(SwordEquipedPopUpConfiguration configuration)
        {
            _configuration = configuration;
            var prefabs = _configuration.SwordEquipedPopUpPrefabs;
            _pools = new Dictionary<string, ObjectPool>(prefabs.Length);

            foreach (var swordEquipedPopUpMediator in prefabs)
            {
                var objectPool = new ObjectPool(swordEquipedPopUpMediator);
                objectPool.Init(2);
                _pools.Add(swordEquipedPopUpMediator.Id, objectPool);
            }
        }

        public SwordEquipedPopUpBuilder Create(string id)
        {
            var objectPool = _pools[id];

            return new SwordEquipedPopUpBuilder().FromObjectPool(objectPool);
        }
    }
}