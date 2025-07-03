using Assets.Code.Common;
using Assets.Code.RecyclableObjects.PopUps;
using TMPro;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.DamagePopUp
{
    public class DamagePopUpMediator : RecyclableObject
    { 
        [SerializeField] private TextMeshPro _damagePopUp;
        [SerializeField] private PopUpId _popUpId;

        public string Id => _popUpId.Value;


        private float _dissapearTime = 1f;
        private float _dissapearTimeMax;

        private int _sortingOrder;
        private float _disappearSpeed = 5f;
        private Color _textColor;
        private float _increaseScaleAmount = 2.3f;
        private float _decreaseScaleAmount = 1.2f;
        private Vector3 _moveVector;
        private float _randomXDirection;

        internal override void Init()
        {
            _dissapearTime = 1f;
            _dissapearTimeMax = _dissapearTime;
            _textColor = _damagePopUp.color;
            _textColor.a = 1f;
            _damagePopUp.color = _textColor;

            if (Random.Range(1, 10) > 5)
            {
                _randomXDirection = 1.2f;
            }
            else
            {
                _randomXDirection = -1.2f;
            }

            _moveVector = new Vector3(_randomXDirection, 2f) * 9f;
            _sortingOrder++;
            if (_sortingOrder > 100)
            {
                _sortingOrder = 0;
            }
            _damagePopUp.sortingOrder = _sortingOrder;
            transform.localScale = Vector3.one;
        }

        internal override void Release()
        {
        }

        public void Configure(int attackValue)
        {
            _damagePopUp.SetText(attackValue.ToString());
        }


        private void Update()
        {
            transform.position += _moveVector * Time.deltaTime;
            _moveVector -= _moveVector * 9f * Time.deltaTime;
            _dissapearTime -= Time.deltaTime;

            if (_dissapearTime > _dissapearTimeMax / 1.8f)
            {
                transform.localScale += Vector3.one * _increaseScaleAmount * Time.deltaTime;
            }
            else
            {
                transform.localScale -= Vector3.one * _decreaseScaleAmount * Time.deltaTime;
            }


            if (_dissapearTime < 0)
            {
                _textColor.a -= _disappearSpeed * Time.deltaTime;
                _damagePopUp.color = _textColor;

                if (_textColor.a < 0)
                {
                    Recycle();
                }
            }
        }
    }
}