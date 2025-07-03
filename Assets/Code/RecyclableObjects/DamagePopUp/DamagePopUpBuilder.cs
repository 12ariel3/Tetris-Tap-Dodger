using Assets.Code.Common;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.DamagePopUp
{
    public class DamagePopUpBuilder
    {
        private ObjectPool _objectPool;
        private Vector3 _position;
        private Quaternion _rotation;
        private int _attackValue;

        public DamagePopUpBuilder FromObjectPool(ObjectPool objectPool)
        {
            _objectPool = objectPool;
            return this;
        }

        public DamagePopUpBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        }


        public DamagePopUpBuilder WithRotation(Quaternion rotation)
        {
            _rotation = rotation;
            return this;
        }

        public DamagePopUpBuilder WithAttackValue(int attackValue)
        {
            _attackValue = attackValue;
            return this;
        }


        public DamagePopUpMediator Build()
        {
            var damagePopUp = _objectPool.Spawn<DamagePopUpMediator>(_position, _rotation);
            damagePopUp.Configure(_attackValue);
            return damagePopUp;
        }
    }
}