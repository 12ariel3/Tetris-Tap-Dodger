namespace Assets.Code.Common.Events
{
    public class HpPopUpEventData : EventData
    {
        public readonly int HpValue;
        public readonly int InstanceId;

        public HpPopUpEventData(int hpValue, int instanceId) : base(EventIds.HpPopUpValue)
        {
            HpValue = hpValue;
            InstanceId = instanceId;
        }
    }
}