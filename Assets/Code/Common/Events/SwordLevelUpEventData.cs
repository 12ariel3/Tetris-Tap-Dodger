namespace Assets.Code.Common.Events
{
    public class SwordLevelUpEventData : EventData
    {
        public readonly string SwordId;
        public readonly int SwordLevel;
        public readonly int InstanceId;

        public SwordLevelUpEventData(string swordId, int swordLevel, int instanceId) : base(EventIds.SwordLevelUp)
        {
            SwordId = swordId;
            SwordLevel = swordLevel;
            InstanceId = instanceId;
        }
    }
}