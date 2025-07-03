using Assets.Code.Common;
using TMPro;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.PopUps.HpPopUp
{
    public class HpPopUpMediator : RecyclableObject
    {
        [SerializeField] private TextMeshPro _hpPopUp;
        [SerializeField] private PopUpId _popUpId;

        public string Id => _popUpId.Value;


        private float _dissapearTime = 1f;
        private float _dissapearTimeMax;

        private int _sortingOrder;
        private float _disappearSpeed = 4f;
        private Color _textColor;
        private float _increaseScaleAmount = 1.5f;
        private float _decreaseScaleAmount = 1f;
        private Vector3 _moveVector;

        internal override void Init()
        {
            _dissapearTime = 1f;
            _dissapearTimeMax = _dissapearTime;
            _textColor = _hpPopUp.color;
            _textColor.a = 1f;
            _hpPopUp.color = _textColor;


            _moveVector = new Vector3(0, 1) * 8f;
            _sortingOrder++;
            if (_sortingOrder > 100)
            {
                _sortingOrder = 20;
            }
            _hpPopUp.sortingOrder = _sortingOrder;
        }

        internal override void Release()
        {
        }

        public void Configure(int hpPopUpValue, string id)
        {
            if (id == "Damage")
            {
                _hpPopUp.SetText("-" + hpPopUpValue.ToString());
            }
            else
            {
                _hpPopUp.SetText("+" + hpPopUpValue.ToString());
            }
        }


        private void Update()
        {
            Move();
            ChangeSize();
            ChangeAlpha();
        }

        private void Move()
        {
            transform.position += _moveVector * Time.deltaTime;
            _moveVector -= _moveVector * 8f * Time.deltaTime;
            _dissapearTime -= Time.deltaTime;
        }

        private void ChangeSize()
        {
            if (_dissapearTime > _dissapearTimeMax / 2)
            {
                transform.localScale += Vector3.one * _increaseScaleAmount * Time.deltaTime;
            }
            else
            {
                transform.localScale -= Vector3.one * _decreaseScaleAmount * Time.deltaTime;
            }
        }

        private void ChangeAlpha()
        {
            if (_dissapearTime < 0)
            {
                _textColor.a -= _disappearSpeed * Time.deltaTime;
                _hpPopUp.color = _textColor;

                if (_textColor.a < 0)
                {
                    Recycle();
                }
            }
        }
    }
}