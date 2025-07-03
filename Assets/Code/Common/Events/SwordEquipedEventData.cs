using UnityEngine;

namespace Assets.Code.Common.Events
{
    public class SwordEquipedEventData : EventData
    {
        public readonly Sprite _swordSpriteUnevolved;
        public readonly Sprite _swordSpriteEvolved;
        public readonly int _swordUpgradeValue;
        public readonly string _id;
        public readonly int _level;
        public readonly int _hp;
        public readonly float _fire;
        public readonly float _poison;
        public readonly float _ice;
        public readonly float _water;
        public readonly float _electric;
        public readonly float _ghost;
        public readonly float _rainbow;
        public readonly Color _deepBackground;
        public readonly Color _background;
        public readonly Color _iconBackground;
        public readonly Color _nameColor;
        public readonly Color _levelColor;
        public readonly int InstanceId;


        public SwordEquipedEventData(Sprite swordSpriteUnevolved, Sprite swordSpriteEvolved, int swordUpgradeValue, string swordName,
                                     int swordLevel, int swordHp, float swordFire, float swordPoison, float swordIce, float swordWater,
                                     float swordElectric, float swordGhost, float swordRainbow,
                                     Color deepBackground, Color background, Color iconBackground, Color nameColor,
                                     Color levelColor, int instanceId) : base(EventIds.SwordEquiped)
        {
            _swordSpriteUnevolved = swordSpriteUnevolved;
            _swordSpriteEvolved = swordSpriteEvolved;
            _swordUpgradeValue = swordUpgradeValue;
            _id = swordName;
            _level = swordLevel;
            _hp = swordHp;
            _fire = swordFire;
            _poison = swordPoison;
            _ice = swordIce;
            _water = swordWater;
            _electric = swordElectric;
            _ghost = swordGhost;
            _rainbow = swordRainbow;
            _deepBackground = deepBackground;
            _background = background;
            _iconBackground = iconBackground;
            _nameColor = nameColor;
            _levelColor = levelColor;
            InstanceId = instanceId;
        }
    }
}