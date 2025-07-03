namespace Assets.Code.Common.Events
{
    public class PlayerHealthChangedEventData : EventData
    {
        public readonly int HealthChangedAmount;
        public readonly bool IsBlooding;
        public readonly int InstanceId;

        public PlayerHealthChangedEventData(int healthChangedAmount, bool isBlooding, int instanceId) : base(EventIds.PlayerHealthChanged)
        {
            HealthChangedAmount = healthChangedAmount;
            IsBlooding = isBlooding;
            InstanceId = instanceId;
        }
    }
}