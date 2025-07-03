using UnityEngine;

namespace Assets.Code.Player
{
    [CreateAssetMenu(menuName = "Player/PlayerId", fileName = "PlayerId", order = 0)]
    public class PlayerId : ScriptableObject
    {
        [SerializeField] private string _value;

        public string Value => _value;
    }
}