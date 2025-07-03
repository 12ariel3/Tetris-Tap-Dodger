namespace Assets.Code.Common.Events
{
    public class VictorySpinWheelX3MultiplierEventData : EventData
    {
        public readonly bool IsX3Actived;
        public readonly int InstanceId;

        public VictorySpinWheelX3MultiplierEventData(bool isX3Actived, int instanceId) : base(EventIds.VictorySpinWheelX3IsActived)
        {
            IsX3Actived = isX3Actived;
            InstanceId = instanceId;
        }
    }
}