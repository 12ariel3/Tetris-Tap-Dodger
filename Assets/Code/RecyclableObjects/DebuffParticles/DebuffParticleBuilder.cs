using Assets.Code.Common;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.DebuffParticles
{
    public class DebuffParticleBuilder
    {
        private ObjectPool _objectPool;
        private Vector3 _position;
        private Quaternion _rotation;
        private Transform _transform;

        public DebuffParticleBuilder FromObjectPool(ObjectPool objectPool)
        {
            _objectPool = objectPool;
            return this;
        }

        public DebuffParticleBuilder WithPosition(Vector3 position)
        {
            _position = new Vector3(0, 0, 0);
            return this;
        }


        public DebuffParticleBuilder WithRotation(Quaternion rotation)
        {
            _rotation = new Quaternion(0, 0, 0, 0);
            return this;
        }
        
        public DebuffParticleBuilder WithTransform(Transform transform)
        {
            _transform = transform;
            return this;
        }


        public DebuffParticleSystemMediator Build()
        {
            var debuffParticle = _objectPool.Spawn<DebuffParticleSystemMediator>(_position, _rotation);
            debuffParticle.Configure(_transform);
            return debuffParticle;
        }
    }
}