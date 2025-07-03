using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerSpriteAndColliderController : MonoBehaviour
    {
        [SerializeField] SpriteRenderer _spriteRenderer;
        [SerializeField] CircleCollider2D _circleCollider;

        private Sprite _unevolvedSwordSpriteValue;
        private Sprite _evolvedSwordSpriteValue;
        
        private float _swordLevel;

        public void Configuration(Sprite unevolvedSwordSpriteValue, Sprite evolvedSwordSpriteValue, float swordLevel)
        {
            _unevolvedSwordSpriteValue = unevolvedSwordSpriteValue;
            _evolvedSwordSpriteValue = evolvedSwordSpriteValue;
            
            _swordLevel = swordLevel;
            SetComponents();
        }


        private void SetComponents()
        {
            if (_swordLevel >= 50) 
            {
                _spriteRenderer.sprite = _evolvedSwordSpriteValue;
            }
            else
            {
                _spriteRenderer.sprite = _unevolvedSwordSpriteValue;
            }
        }
    }
}