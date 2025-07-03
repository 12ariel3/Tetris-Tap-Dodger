using Assets.Code.Common;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.PopUps.UpgradesLevelUpPopUp
{
    public class SwordEquipedPopUpBuilder
    {
        private ObjectPool _objectPool;
        private Vector3 _position = Vector3.zero;
        private Quaternion _rotation = Quaternion.identity;
        private Transform _parentTransform;

        public SwordEquipedPopUpBuilder FromObjectPool(ObjectPool objectPool)
        {
            _objectPool = objectPool;
            return this;
        }

        public SwordEquipedPopUpBuilder WithParentTransform(Transform parentTransform)
        {
            _parentTransform = parentTransform;
            return this;
        }


        public SwordEquipedPopUpMediator Build()
        {
            var swordEquipedPopUp = _objectPool.Spawn<SwordEquipedPopUpMediator>(_position, _rotation);
            swordEquipedPopUp.Configure(_parentTransform);
            return swordEquipedPopUp;
        }
    }
}