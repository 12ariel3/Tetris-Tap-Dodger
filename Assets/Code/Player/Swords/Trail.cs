using Assets.Code.Common.Level;
using Assets.Code.Core;
using UnityEngine;

namespace Assets.Code.Player.Swords
{
    public class Trail : MonoBehaviour
    {

        [SerializeField] private TrailToSpawnConfiguration _trailConfiguration;

        private int _trailUpgradeValue;
        private int _trailUnlockScoreCost;
        private int _trailUnlockGemsCost;
        private string _id;
        private int _level;
        private int _hp;
        private float _fire;
        private float _poison;
        private float _ice;
        private float _water;
        private float _electric;
        private float _ghost;
        private float _rainbow;
        private Color _deepBackground;
        private Color _background;
        private Color _iconBackground;
        private Color _nameColor;
        private Color _levelColor;
        private Sprite _swordSpriteUnevolved;
        private Sprite _swordSpriteEvolved;
        


        public int TrailUpgradeValue => _trailUpgradeValue;
        public int TrailUnlockScoreCost => _trailUnlockScoreCost;
        public int TrailUnlockGemsCost => _trailUnlockGemsCost;
        public string Id => _id;
        public int Level => _level;
        public int HP => _hp;
        public float Fire => _fire;
        public float Poison => _poison;
        public float Ice => _ice;
        public float Water => _water;
        public float Electric => _electric;
        public float Ghost => _ghost;
        public float Rainbow => _rainbow;
        public Color DeepBackground => _deepBackground;
        public Color Background => _background;
        public Color IconBackground => _iconBackground;
        public Color NameColor => _nameColor;
        public Color LevelColor => _levelColor;
        public Sprite SwordSpriteUnevolved => _swordSpriteUnevolved;
        public Sprite SwordSpriteEvolved => _swordSpriteEvolved;
        


        private void Start()
        {
            _trailUnlockScoreCost = _trailConfiguration.TrailUnlockScoreCost;
            _trailUnlockGemsCost = _trailConfiguration.TrailUnlockGemsCost;
            _id = _trailConfiguration.TrailId.Value;
            _deepBackground = _trailConfiguration.DeepBackground;
            _background = _trailConfiguration.Background;
            _iconBackground = _trailConfiguration.IconBackground;
            _nameColor = _trailConfiguration.NameColor;
            _levelColor = _trailConfiguration.LevelColor;
            _swordSpriteUnevolved = _trailConfiguration.UnevolvedSwordSprite;
            _swordSpriteEvolved = _trailConfiguration.EvolvedSwordSprite;
            
            _level = ServiceLocator.Instance.GetService<SwordsLevelSystem>().GetLevel(Id);
            SetStatsCalculation();
        }


        public void LevelUp(int level)
        {
            _level = level;
            SetStatsCalculation();
        }

        private void SetStatsCalculation()
        {
            _trailUpgradeValue = Mathf.FloorToInt((10 * _level) * (1 + (_trailConfiguration.TrailUpgradeBaseValue * (_level / 10f))));
            _hp = Mathf.FloorToInt(((_trailConfiguration.TrailBaseHp * (_level / 2f) * (_level / 4f)) / 100f) + 10);
            _fire = _trailConfiguration.TrailFire * _level;
            _poison = _trailConfiguration.TrailPoison * _level;
            _ice = _trailConfiguration.TrailIce * _level;
            _water = _trailConfiguration.TrailWater * _level;
            _electric = _trailConfiguration.TrailElectric * _level;
            _ghost = _trailConfiguration.TrailGhost * _level;
            _rainbow = _trailConfiguration.TrailRainbow * _level;
        }
    }
}