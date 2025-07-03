using System;
using UnityEngine;

namespace Assets.Code.Enemies
{
    [Serializable]
    public class SpawnConfiguration
    {
        [SerializeField] private int _projectileNumberToSpawnConfigurations;
        [SerializeField] private float _timeToSpawn;
        [SerializeField] string _currentLevelType         
;

        public int ProjectileNumberToSpawnConfigurations => _projectileNumberToSpawnConfigurations;
        public float TimeToSpawn => _timeToSpawn;
        public string CurrentLevelType => _currentLevelType;
    }
}
