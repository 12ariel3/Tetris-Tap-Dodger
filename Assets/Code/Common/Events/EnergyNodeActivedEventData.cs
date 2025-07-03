namespace Assets.Code.Common.Events
{
    public class EnergyNodeActivedEventData : EventData
    {
        public readonly float EnergyAdded;
        public readonly int InstanceId;

        public EnergyNodeActivedEventData(float energyAdded, int instanceId) : base(EventIds.EnergyNodeActived)
        {
            EnergyAdded = energyAdded;
            InstanceId = instanceId;
        }
    }
}