namespace Assets.Code.Common.Events
{
    public class PlayerSendFinalStatsEventData : EventData
    {
        public readonly int HpValue;
        public readonly float Fire;
        public readonly float Poison;
        public readonly float Ice;
        public readonly float Water;
        public readonly float Electric;
        public readonly float Ghost;
        public readonly float Rainbow;
        public readonly int InstanceId;

        public PlayerSendFinalStatsEventData(int hpValue, float fire, float poison,
                                         float ice, float water, float electric,
                                         float ghost, float rainbow,
                                         int instanceId) : base(EventIds.PlayerSendFinalStatsValue)
        {
            HpValue = hpValue;
            Fire = fire;
            Poison = poison;
            Ice = ice;
            Water = water;
            Electric = electric;
            Ghost = ghost;
            Rainbow = rainbow;
            InstanceId = instanceId;
        }
    }
}