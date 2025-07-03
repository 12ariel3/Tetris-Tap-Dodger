namespace Assets.Code.Common.Events
{
    public class LevelDebuffProbabilityEventData : EventData
    {
        public readonly int DebuffProbability;
        public readonly int InstanceId;

        public LevelDebuffProbabilityEventData(int debuffProbability, int instanceId) : base(EventIds.LevelDebuffProbability)
        {
            DebuffProbability = debuffProbability;
            InstanceId = instanceId;
        }
    }
}