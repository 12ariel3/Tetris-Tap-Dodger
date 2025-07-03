using UnityEngine;

namespace Assets.Code.Player.Swords
{
    [CreateAssetMenu(menuName = "Trail/TrailToSpawnConfiguration", fileName = "TrailToSpawnConfiguration")]
    public class TrailToSpawnConfiguration : ScriptableObject
    {
        [SerializeField] private TrailId _trailId;

        [SerializeField] private float _trailUpgradeBaseValue;
        [SerializeField] private int _trailUnlockScoreCost;
        [SerializeField] private int _trailUnlockGemsCost;
        [SerializeField] private int _trailBaseHp;
        [SerializeField] private float _trailFire;
        [SerializeField] private float _trailPoison;
        [SerializeField] private float _trailIce;
        [SerializeField] private float _trailWater;
        [SerializeField] private float _trailElectric;
        [SerializeField] private float _trailGhost;
        [SerializeField] private float _trailRainbow;
        [SerializeField] private ParticleSystem _unevolvedTrailParticleSystem;
        [SerializeField] private ParticleSystem _evolvedTrailParticleSystem;
        [SerializeField] private Sprite _unevolvedSwordSprite;
        [SerializeField] private Sprite _evolvedSwordSprite;
        [SerializeField] private Color _deepBackground;
        [SerializeField] private Color _background;
        [SerializeField] private Color _iconBackground;
        [SerializeField] private Color _nameColor;
        [SerializeField] private Color _levelColor;


        public TrailId TrailId => _trailId;

        public float TrailUpgradeBaseValue => _trailUpgradeBaseValue;
        public int TrailUnlockScoreCost => _trailUnlockScoreCost;
        public int TrailUnlockGemsCost => _trailUnlockGemsCost;
        public int TrailBaseHp => _trailBaseHp;
        public float TrailFire => _trailFire;
        public float TrailPoison => _trailPoison;
        public float TrailIce => _trailIce;
        public float TrailWater => _trailWater;
        public float TrailElectric => _trailElectric;
        public float TrailGhost => _trailGhost;
        public float TrailRainbow => _trailRainbow;
        public ParticleSystem UnevolvedTrailParticleSystem => _unevolvedTrailParticleSystem;
        public ParticleSystem EvolvedTrailParticleSystem => _evolvedTrailParticleSystem;
        public Sprite UnevolvedSwordSprite => _unevolvedSwordSprite;
        public Sprite EvolvedSwordSprite => _evolvedSwordSprite;
        public Color DeepBackground => _deepBackground;
        public Color Background => _background;
        public Color IconBackground => _iconBackground;
        public Color NameColor => _nameColor;
        public Color LevelColor => _levelColor;
    }
}