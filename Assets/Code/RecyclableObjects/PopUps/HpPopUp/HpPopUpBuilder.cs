using Assets.Code.Common;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.PopUps.HpPopUp
{
    public class HpPopUpBuilder
    {
        private ObjectPool _objectPool;
        private Vector3 _position;
        private Quaternion _rotation = Quaternion.identity;
        private int _hpPopUpValue;
        private string _id;
        private Vector3 screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 1.75f, Screen.height / 1.22f));

        public HpPopUpBuilder FromObjectPool(ObjectPool objectPool)
        {
            _objectPool = objectPool;
            return this;
        }

        public HpPopUpBuilder WithPosition()
        {
            _position = new Vector3(screenSize.x + Random.Range(0, 2.5f), screenSize.y + Random.Range(0, 0.9f));
            return this;
        }


        public HpPopUpBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public HpPopUpBuilder WithAttackValue(int hpPopUpValue)
        {
            _hpPopUpValue = hpPopUpValue;
            return this;
        }


        public HpPopUpMediator Build()
        {
            var hpPopUp = _objectPool.Spawn<HpPopUpMediator>(_position, _rotation);
            hpPopUp.Configure(_hpPopUpValue, _id);
            return hpPopUp;
        }
    }
}