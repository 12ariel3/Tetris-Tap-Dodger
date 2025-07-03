namespace Assets.Code.Common.Events
{
    public class PlayerDestroyedEventData : EventData
    {
        public readonly int InstanceId;

        public PlayerDestroyedEventData(int instanceId) : base(EventIds.PlayerDestroyed)
        {
            InstanceId = instanceId;
        }
    }
}