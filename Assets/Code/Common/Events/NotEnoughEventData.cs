namespace Assets.Code.Common.Events
{
    public class NotEnoughEventData : EventData
    {
        public readonly string Id;
        public readonly int InstanceId;

        public NotEnoughEventData(string id, int instanceId) : base(EventIds.NotEnoughEvent)
        {
            Id = id;
            InstanceId = instanceId;
        }
    }
}