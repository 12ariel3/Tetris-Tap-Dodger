using UnityEngine;

namespace Assets.Code.Enemies
{
    [CreateAssetMenu(menuName = "Level/MapId", fileName = "MapId", order = 0)]
    public class MapId : ScriptableObject
    {
        [SerializeField] private string _value;

        public string Value => _value;
    }
}