using UnityEngine;

namespace Assets.Code.Player
{
    [CreateAssetMenu(menuName = "Player/PlayerToSpawnConfiguration", fileName = "PlayerToSpawnConfiguration")]
    public class PlayerToSpawnConfiguration : ScriptableObject
    {
        [SerializeField] private PlayerId _playerId;

        [SerializeField] private int _baseHp;
        [SerializeField] private float _baseFire;
        [SerializeField] private float _basePoison;
        [SerializeField] private float _baseIce;
        [SerializeField] private float _baseWater;
        [SerializeField] private float _baseElectric;
        [SerializeField] private float _baseGhost;
        [SerializeField] private float _baseRainbow;


        public PlayerId PlayerId => _playerId;

        public int BaseHp => _baseHp;
        public float BaseFire => _baseFire;
        public float BasePoison => _basePoison;
        public float BaseIce => _baseIce;
        public float BaseWater => _baseWater;
        public float BaseElectric => _baseElectric;
        public float BaseGhost => _baseGhost;
        public float BaseRainbow => _baseRainbow;
    }
}
