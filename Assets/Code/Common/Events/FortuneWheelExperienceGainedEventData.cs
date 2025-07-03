namespace Assets.Code.Common.Events
{
    public class FortuneWheelExperienceGainedEventData : EventData
    {
        public readonly int Amount;
        public readonly int InstanceId;

        public FortuneWheelExperienceGainedEventData(int amount, int instanceId) : base(EventIds.FortuneWheelExperienceGained)
        {
            Amount = amount;
            InstanceId = instanceId;
        }
    }
}