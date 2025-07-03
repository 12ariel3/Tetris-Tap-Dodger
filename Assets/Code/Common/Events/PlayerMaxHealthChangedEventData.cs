namespace Assets.Code.Common.Events
{
    public class PlayerMaxHealthChangedEventData : EventData
    {
        public readonly int MaxHealthChangedAmount;
        public readonly int InstanceId;

        public PlayerMaxHealthChangedEventData(int maxHealthChangedAmount, int instanceId) : base(EventIds.PlayerMaxHealthChanged)
        {
            MaxHealthChangedAmount = maxHealthChangedAmount;
            InstanceId = instanceId;
        }
    }
}