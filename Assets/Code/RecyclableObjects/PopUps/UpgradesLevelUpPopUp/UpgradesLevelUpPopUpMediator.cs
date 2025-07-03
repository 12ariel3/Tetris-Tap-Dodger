using Assets.Code.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.RecyclableObjects.PopUps.UpgradesLevelUpPopUp
{
    public class UpgradesLevelUpPopUpMediator : RecyclableObject
    {
        [SerializeField] private Image _image;
        [SerializeField] private PopUpId _popUpId;
        public string Id => _popUpId.Value;

        private float _dissapearTime = 1f;
        private float _dissapearTimeMax;

        private float _disappearSpeed = 4f;
        private Color _imageColor;
        private float _increaseScaleAmount = 1.5f;
        private float _decreaseScaleAmount = 1f;
        private Vector3 _moveVector;

        public void Configure(Transform parentTransform)
        {
            transform.SetParent(parentTransform, false);
        }


        internal override void Init()
        {
            _dissapearTime = 1f;
            _dissapearTimeMax = _dissapearTime;
            _imageColor = _image.color;
            _imageColor.a = 1f;
            _image.color = _imageColor;

            _moveVector = new Vector3(0, 1) * 8f;
        }

        internal override void Release()
        {
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
                _imageColor.a -= _disappearSpeed * Time.deltaTime;
                _image.color = _imageColor;

                if (_imageColor.a < 0)
                {
                    Recycle();
                }
            }
        }
    }
}