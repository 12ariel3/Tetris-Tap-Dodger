using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Code.Enemies
{
    [CreateAssetMenu(fileName = "MapsConfiguration", menuName = "Level/Maps Configuration")]
    public class MapsConfiguration : ScriptableObject
    {
        [SerializeField] private MapConfiguration[] _maps;
        private Dictionary<string, MapConfiguration> _idToMap;



        private void Awake()
        {
            _idToMap = new Dictionary<string, MapConfiguration>();
            foreach (MapConfiguration map in _maps)
            {
                _idToMap.Add(map.Id.Value, map);
            }
        }


        public MapConfiguration GetMapById(string id)
        {
            if (!_idToMap.TryGetValue(id, out var map))
            {
                throw new Exception($"Map {id} not found");
            }
            return map;
        }
    }
}