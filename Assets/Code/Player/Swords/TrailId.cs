using UnityEngine;

namespace Assets.Code.Player.Swords
{
    [CreateAssetMenu(menuName = "Trail/TrailId", fileName = "TrailId", order = 0)]
    public class TrailId : ScriptableObject
    {
        [SerializeField] private string _value;

        public string Value => _value;
    }
}