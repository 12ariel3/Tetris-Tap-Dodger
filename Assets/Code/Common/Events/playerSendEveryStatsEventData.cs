namespace Assets.Code.Common.Events
{
    public class playerSendEveryStatsEventData : EventData
    {
        public readonly int CharacterHpValue;
        public readonly float CharacterFire;
        public readonly float CharacterPoison;
        public readonly float CharacterIce;
        public readonly float CharacterWater;
        public readonly float CharacterElectric;
        public readonly float CharacterGhost;
        public readonly float CharacterRainbow;

        public readonly int SwordHpValue;
        public readonly float SwordFire;
        public readonly float SwordPoison;
        public readonly float SwordIce;
        public readonly float SwordWater;
        public readonly float SwordElectric;
        public readonly float SwordGhost;
        public readonly float SwordRainbow;

        public readonly float UpgradesHpValue;
        public readonly float UpgradesFire;
        public readonly float UpgradesPoison;
        public readonly float UpgradesIce;
        public readonly float UpgradesWater;
        public readonly float UpgradesElectric;
        public readonly float UpgradesGhost;
        public readonly float UpgradesRainbow;
        public readonly int InstanceId;

        public playerSendEveryStatsEventData(int characterHpValue, float characterFire,
                                         float characterPoison, float characterIce,
                                         float characterWater, float characterElectric,
                                         float characterGhost, float characterRainbow,

                                         int swordHpValue, float swordFire, float swordPoison,
                                         float swordIce, float swordWater, float swordElectric,
                                         float swordGhost, float swordRainbow,

                                         float upgradesHpValue, float upgradesFire,
                                         float upgradesPoison, float upgradesIce,
                                         float upgradesWater, float upgradesElectric,
                                         float upgradesGhost, float upgradesRainbow,
                                         int instanceId) : base(EventIds.PlayerSendEveryStatsValue)
        {
            CharacterHpValue = characterHpValue;
            CharacterFire = characterFire;
            CharacterPoison = characterPoison;
            CharacterIce = characterIce;
            CharacterWater = characterWater;
            CharacterElectric = characterElectric;
            CharacterGhost = characterGhost;
            CharacterRainbow = characterRainbow;

            SwordHpValue = swordHpValue;
            SwordFire = swordFire;
            SwordPoison = swordPoison;
            SwordIce = swordIce;
            SwordWater = swordWater;
            SwordElectric = swordElectric;
            SwordGhost = swordGhost;
            SwordRainbow = swordRainbow;

            UpgradesHpValue = upgradesHpValue;
            UpgradesFire = upgradesFire;
            UpgradesPoison = upgradesPoison;
            UpgradesIce = upgradesIce;
            UpgradesWater = upgradesWater;
            UpgradesElectric = upgradesElectric;
            UpgradesGhost = upgradesGhost;
            UpgradesRainbow = upgradesRainbow;

            InstanceId = instanceId;
        }
    }
}