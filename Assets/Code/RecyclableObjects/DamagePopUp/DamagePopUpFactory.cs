using Assets.Code.Common;
using Assets.Code.RecyclableObjects.DamagePopUp;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopUpFactory : MonoBehaviour
{
    private readonly DamagePopUpConfiguration _configuration;
    private readonly Dictionary<string, ObjectPool> _pools;

    public DamagePopUpFactory(DamagePopUpConfiguration configuration)
    {
        _configuration = configuration;
        var prefabs = _configuration.DamagePrefabs;
        _pools = new Dictionary<string, ObjectPool>(prefabs.Length);

        foreach (var damagePopUpMediator in prefabs)
        {
            var objectPool = new ObjectPool(damagePopUpMediator);
            objectPool.Init(8);
            _pools.Add(damagePopUpMediator.Id, objectPool);
        }
    }

    public DamagePopUpBuilder Create(string id)
    {
        var objectPool = _pools[id];

        return new DamagePopUpBuilder().FromObjectPool(objectPool);
    }
}
