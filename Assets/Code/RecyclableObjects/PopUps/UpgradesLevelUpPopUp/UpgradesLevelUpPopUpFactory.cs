using Assets.Code.Common;
using System.Collections.Generic;

namespace Assets.Code.RecyclableObjects.PopUps.UpgradesLevelUpPopUp
{
    public class UpgradesLevelUpPopUpFactory
    {
        private readonly UpgradesLevelUpPopUpCpnfiguration _configuration;
        private readonly Dictionary<string, ObjectPool> _pools;


        public UpgradesLevelUpPopUpFactory(UpgradesLevelUpPopUpCpnfiguration configuration)
        {
            _configuration = configuration;
            var prefabs = _configuration.UpgradesLevelUpPopUpPrefabs;
            _pools = new Dictionary<string, ObjectPool>(prefabs.Length);

            foreach (var upgradesLevelUpPopUpMediator in prefabs)
            {
                var objectPool = new ObjectPool(upgradesLevelUpPopUpMediator);
                objectPool.Init(5);
                _pools.Add(upgradesLevelUpPopUpMediator.Id, objectPool);
            }
        }

        public UpgradesLevelUpPopUpBuilder Create(string id)
        {
            var objectPool = _pools[id];

            return new UpgradesLevelUpPopUpBuilder().FromObjectPool(objectPool);
        }
    }
}