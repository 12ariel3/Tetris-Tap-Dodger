using Assets.Code.Common;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.BloodyOverlay
{
    public class BloodyOverlayBuilder
    {
        private ObjectPool _objectPool;
        private Vector3 _position = Vector3.zero;
        private Quaternion _rotation = Quaternion.identity;
        private bool _isActive;

        public BloodyOverlayBuilder FromObjectPool(ObjectPool objectPool)
        {
            _objectPool = objectPool;
            return this;
        }

        public BloodyOverlayBuilder WithIsActive(bool isActive)
        {
            _isActive = isActive;
            return this;
        }


        public BloodyOverlayMediator Build()
        {
            var bloodyOverlay = _objectPool.Spawn<BloodyOverlayMediator>(_position, _rotation);
            bloodyOverlay.Configure(_isActive);
            return bloodyOverlay;
        }
    }
}