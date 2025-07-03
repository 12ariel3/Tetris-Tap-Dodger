namespace Assets.Code.Common.Events
{
    public class SwordEquippedLevelUpEventData : EventData
    {
        public readonly string Id;
        public readonly int TrailUpgradeValue;
        public readonly int Level;
        public readonly int Hp;
        public readonly float Fire;
        public readonly float Poison;
        public readonly float Ice;
        public readonly float Water;
        public readonly float Electric;
        public readonly float Ghost;
        public readonly float Rainbow;
        public readonly int InstanceId;


        public SwordEquippedLevelUpEventData(string swordName, int trailUpgradeValue, int level, int swordHp,
                                             float swordFire, float swordPoison, float swordIce,
                                             float swordWater, float swordElectric, float swordGhost, float swordRainbow,
                                             int instanceId) : base(EventIds.SwordEquippedLevelUp)
        {
            Id = swordName;
            TrailUpgradeValue = trailUpgradeValue;
            Level = level;
            Hp = swordHp;
            Fire = swordFire;
            Poison = swordPoison;
            Ice = swordIce;
            Water = swordWater;
            Electric = swordElectric;
            Ghost = swordGhost;
            Rainbow = swordRainbow;
            InstanceId = instanceId;
        }
    }
}