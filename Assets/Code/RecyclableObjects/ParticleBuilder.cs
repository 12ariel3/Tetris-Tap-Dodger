using Assets.Code.Common;
using UnityEngine;

namespace Assets.Code.RecyclableObjects
{
    public class ParticleBuilder
    {
        private ObjectPool _objectPool;
        private Vector3 _position;
        private Quaternion _rotation;

        public ParticleBuilder FromObjectPool(ObjectPool objectPool)
        {
            _objectPool = objectPool;
            return this;
        }

        public ParticleBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        }


        public ParticleBuilder WithRotation(Quaternion rotation)
        {
            _rotation = rotation;
            return this;
        }


        public ParticleSystemMediator Build()
        {
            var explosionParticle = _objectPool.Spawn<ParticleSystemMediator>(_position, _rotation);
            return explosionParticle;
        }
    }
}