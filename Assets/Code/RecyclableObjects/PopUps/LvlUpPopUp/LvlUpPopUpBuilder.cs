using Assets.Code.Common;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.PopUps.LvlUpPopUp
{
    public class LvlUpPopUpBuilder
    {
        private ObjectPool _objectPool;
        private Vector3 _position;
        private Quaternion _rotation = Quaternion.identity;
        private Vector3 screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f));

        public LvlUpPopUpBuilder FromObjectPool(ObjectPool objectPool)
        {
            _objectPool = objectPool;
            return this;
        }

        public LvlUpPopUpBuilder WithPosition()
        {
            _position = new Vector3(screenSize.x, screenSize.y);
            return this;
        }

        public LvlUpPopUpBuilder WithPosition2( Vector3 position)
        {
            _position = position;
            return this;
        }


        public LvlUpPopUpMediator Build()
        {
            var lvlUpPopUp = _objectPool.Spawn<LvlUpPopUpMediator>(_position, _rotation);
            return lvlUpPopUp;
        }
    }
}