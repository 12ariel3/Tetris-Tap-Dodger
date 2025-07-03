using TMPro;
using UnityEngine;

namespace Assets.Code.Enemies
{
    [CreateAssetMenu(fileName = "MapConfiguration", menuName = "Level/Map Configuration")]
    public class MapConfiguration : ScriptableObject
    {
        [SerializeField] private MapId _id;
        [SerializeField] private MapId _mapName;
        [SerializeField] private LevelConfiguration[] _levels;
        [SerializeField] private Sprite _mapBackground;
        [SerializeField] private Color _particleSystemColor;
        [SerializeField] private Color _backgroundLevelColor;
        [SerializeField] private TMP_FontAsset _titleAndLevelFont;

        public MapId Id => _id;
        public MapId MapName => _mapName;
        public LevelConfiguration[] Levels => _levels;
        public Sprite MapBackground => _mapBackground;
        public Color ParticleSystemColor => _particleSystemColor;
        public Color BackgroundLevelColor => _backgroundLevelColor;
        public TMP_FontAsset TitleAndLevelFont => _titleAndLevelFont;

        public LevelConfiguration GetCurrentLevelConfiguration(int currentLevel)
        {
            foreach (var level in _levels)
            {
                if (level.TotalLevelNumber == currentLevel)
                {
                    return level;
                }
            }
            if (currentLevel > _levels.Length)
            {
                return _levels[_levels.Length - 1];
            }
            Debug.Log("trouble with GetCurrentLevelConfiguration del MapConfiguraton");
            return null;
        }

        public LevelConfiguration GetFirstLevelConfiguration()
        {
            return _levels[0];
        }
    }
}