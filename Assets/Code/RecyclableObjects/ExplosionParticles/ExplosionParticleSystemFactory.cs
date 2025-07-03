using Assets.Code.Common;
using Assets.Code.RecyclableObjects;
using Assets.Code.RecyclableObjects.ExplosionParticles;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticleSystemFactory : MonoBehaviour
{
    private readonly ExplosionParticlesSystemConfiguration _configuration;
    private readonly Dictionary<string, ObjectPool> _pools;


    public ExplosionParticleSystemFactory(ExplosionParticlesSystemConfiguration configuration, string currentMapName)
    {
        _configuration = configuration;
        var prefabs = _configuration.GetArrayById(currentMapName);
        _pools = new Dictionary<string, ObjectPool>(prefabs.Length);

        foreach (var particleMediator in prefabs)
        {
            var objectPool = new ObjectPool(particleMediator);
            objectPool.Init(2);
            _pools.Add(particleMediator.Id, objectPool);
        }
    }

    public ParticleBuilder Create(string id)
    {
        var objectPool = _pools[id];

        return new ParticleBuilder().FromObjectPool(objectPool);
    }
}
