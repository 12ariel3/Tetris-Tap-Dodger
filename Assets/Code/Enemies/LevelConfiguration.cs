using UnityEngine;

namespace Assets.Code.Enemies
{
    [CreateAssetMenu(fileName = "LevelConfiguration", menuName = "Level/Level Configuration")]
    public class LevelConfiguration : ScriptableObject
    {
        [SerializeField] private string _currentLevelType;
        [SerializeField] private int _totalDurationLevel;
        [SerializeField] private float _minCooldownTime;
        [SerializeField] private float _maxCooldownTime;
        [SerializeField] private int _projectileLevel;
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private int _energyToRest;
        [SerializeField] private int _levelNumber;
        [SerializeField] private int _totalLevelNumber;
        [SerializeField] private ProjectileToSpawnConfiguration[] _projectileToSpawnConfiguration;
        [SerializeField] private int _debuffProbability;
        [SerializeField] private float _specialProjectileCastPercentaje;
        [SerializeField] private ProjectileToSpawnConfiguration[] _specialProjectileToSpawnConfiguration;


        public string CurrentLevelType => _currentLevelType;
        public int TotalDurationLevel => _totalDurationLevel;
        public float MinCooldownTime => _minCooldownTime;
        public float MaxCooldownTime => _maxCooldownTime;
        public int ProjectileLevel => _projectileLevel;
        public float ProjectileSpeed => _projectileSpeed;
        public int EnergyToRest => _energyToRest;
        public int LevelNumber => _levelNumber;
        public int TotalLevelNumber => _totalLevelNumber;
        public int DebuffProbability => _debuffProbability;
        public float SpecialProjectileCastPercentaje => _specialProjectileCastPercentaje;
        public ProjectileToSpawnConfiguration GetRandomProgectileToSpawnConfiguration()
        {
            int projectile = Random.Range(0, _projectileToSpawnConfiguration.Length);
            return _projectileToSpawnConfiguration[projectile];
        }

        public ProjectileToSpawnConfiguration GetRandomSpecialProgectileToSpawnConfiguration()
        {
            int projectile = Random.Range(0, _specialProjectileToSpawnConfiguration.Length);
            return _specialProjectileToSpawnConfiguration[projectile];
        }
    }
}