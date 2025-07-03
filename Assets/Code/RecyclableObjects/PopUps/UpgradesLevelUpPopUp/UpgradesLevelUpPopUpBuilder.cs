using Assets.Code.Common;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.PopUps.UpgradesLevelUpPopUp
{
    public class UpgradesLevelUpPopUpBuilder
    {
        private ObjectPool _objectPool;
        private Vector3 _position = Vector3.zero;
        private Quaternion _rotation = Quaternion.identity;
        private Transform _parentTransform;

        public UpgradesLevelUpPopUpBuilder FromObjectPool(ObjectPool objectPool)
        {
            _objectPool = objectPool;
            return this;
        }

        public UpgradesLevelUpPopUpBuilder WithParentTransform(Transform parentTransform)
        {
            _parentTransform = parentTransform;
            return this;
        }


        public UpgradesLevelUpPopUpMediator Build()
        {
            var upgradesLevelUpPopUp = _objectPool.Spawn<UpgradesLevelUpPopUpMediator>(_position, _rotation);
            upgradesLevelUpPopUp.Configure(_parentTransform);
            return upgradesLevelUpPopUp;
        }
    }
}