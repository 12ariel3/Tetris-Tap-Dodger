using UnityEngine;

namespace Assets.Code.Enemies
{
    [CreateAssetMenu(menuName = "Projectile/ProjectileToSpawnConfiguration", fileName = "ProjectileToSpawnConfiguration")]
    public class ProjectileToSpawnConfiguration : ScriptableObject
    {
        [SerializeField] private ProjectileId _projectileId;
        [SerializeField] private string _name;
        [SerializeField] private string _explosionName;
        [SerializeField] private int _score;
        [SerializeField] private int _gems;
        [SerializeField] private int _gemsProbability;
        [SerializeField] private int _experience;

        [SerializeField] private int _maxHp;
        [SerializeField] private int _attack;
        [SerializeField] private bool _isSpecial;


        public ProjectileId ProjectileId => _projectileId;

        public string Name => _name;
        public string ExplosionName => _explosionName;
        public int Score => _score;
        public int Gems => _gems;
        public int GemsProbability => _gemsProbability;
        public int Experience => _experience;
        public int MaxHp => _maxHp;
        public int Attack => _attack;
        public bool IsSpecial => _isSpecial;
    }
}