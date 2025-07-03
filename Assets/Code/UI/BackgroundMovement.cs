using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class BackgroundMovement : MonoBehaviour
    {
        [SerializeField] private Vector2 _scrollSpeed = new Vector2(0.15f, 0.15f);
        private Image _renderer;
        private Material _material;
        private Material _newMaterial;
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");

        void Start()
        {
            _renderer = GetComponent<Image>();
            _material = _renderer.material;
        }


        void Update()
        {
            var offset = Time.time * _scrollSpeed;
            _material.SetTextureOffset(MainTex, offset);
        }
    }
}