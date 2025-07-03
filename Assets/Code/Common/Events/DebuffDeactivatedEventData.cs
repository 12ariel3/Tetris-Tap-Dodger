namespace Assets.Code.Common.Events
{
    public class DebuffDeactivatedEventData : EventData
    {
        public readonly string DebuffName;
        public readonly int InstanceId;

        public DebuffDeactivatedEventData(string debuffName, int instanceId) : base(EventIds.DebuffDeactivated)
        {
            DebuffName = debuffName;
            InstanceId = instanceId;
        }
    }
}