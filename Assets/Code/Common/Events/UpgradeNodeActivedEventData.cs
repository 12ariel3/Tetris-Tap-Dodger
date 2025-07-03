namespace Assets.Code.Common.Events
{
    public class UpgradeNodeActivedEventData : EventData
    {
        public readonly string NodeName;
        public readonly int InstanceId;

        public UpgradeNodeActivedEventData(string nodeName, int instanceId) : base(EventIds.UpgradeNodeActived)
        {
            NodeName = nodeName;
            InstanceId = instanceId;
        }
    }
}