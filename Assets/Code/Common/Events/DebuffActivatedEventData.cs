
namespace Assets.Code.Common.Events
{
    public class DebuffActivatedEventData : EventData
    {
        public readonly string DebuffName;
        public readonly int InstanceId;

        public DebuffActivatedEventData(string debuffName, int instanceId) : base(EventIds.DebuffActivated)
        {
            DebuffName = debuffName;
            InstanceId = instanceId;
        }
    }
}